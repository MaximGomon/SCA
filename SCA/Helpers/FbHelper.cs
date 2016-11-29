using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using Facebook;
using SCA.BussinesLogic;
using SCA.DataAccess;
using SCA.DataAccess.Repositories.Implementations;
using SCA.Domain;
using SCA.Domain.Enums;
using SCA.Models.Facebook;

namespace SCA.Helpers
{
    public static class FbHelper
    {
        static DatabaseFactory _factory = new DatabaseFactory();
        public static void Authorize()
        {
            var fb = new FacebookClient();
            var appId = ConfigurationManager.AppSettings["AppId"];
            var appSecret = ConfigurationManager.AppSettings["AppSecret"];
            dynamic result = fb.Get("oauth/access_token", new
            {
                client_id = appId,
                client_secret = appSecret,
                grant_type = "client_credentials"
            });
            fb.AccessToken = result.access_token;
            var settingBusinessLogic = new SettingBusinessLogic(new SystemSettingRepository(new DatabaseFactory()));
            settingBusinessLogic.Add(new SystemSetting
            {
                Key = SettingKeyEnum.AccessToken.ToString(),
                Value = fb.AccessToken
            });
        }

        public static void GetSocialInfo()
        {
            var eventLike = GetInfoSocialNetwork();
            var data = eventLike.data;

            GetContactFrom(data);
            
        }

        public static FbFeeds GetInfoSocialNetwork()
        {
            try
            {
                var settingBusinessLogic = new SettingBusinessLogic(new SystemSettingRepository(new DatabaseFactory()));
                var groupId = ConfigurationManager.AppSettings["GroupId"];
                var filter = ConfigurationManager.AppSettings["FacebookFilter"];
                var accessToken = settingBusinessLogic.GetByKey(SettingKeyEnum.AccessToken.ToString());
                var cl = new FacebookClient(accessToken.Value);
                var query = cl.Get(groupId + "/?fields=" + filter);
                var ser = new DataContractJsonSerializer(typeof(FbData));
                using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(query.ToString())))
                {
                    FbData parsQuery = (FbData)ser.ReadObject(ms);
                    return parsQuery.feed;
                }
            }
            catch (Exception ex)
            {
                throw; // ignored
            }
        }

        public static void GetContactFrom(FbFeed[] data)
        {
            try
            {
                var activityBusinessLogic = new ActivityBusinessLogic(new ActivityRepository(_factory), new TagBusinessLogic(new TagRepository(_factory)),
                new DictionaryBusinessLogic<ActivityType>(new DictionaryRepository<ActivityType>(_factory)));
                var socialNetworkLogic = new SocialNetworkBusinessLogic(new SocialNetworkRepository(_factory));

                foreach (var fbFeed in data)
                {
                    var socialEvent = socialNetworkLogic.GetEventByEventId(fbFeed.id);

                    if (socialEvent == null)
                    {
                        socialEvent = new SocialNetworkEvent();
                        var contact = TryAddContact(fbFeed.@from.id, fbFeed.@from.name);
                        socialEvent.Avtor = contact;
                        socialEvent.CreateDate = DateTime.Parse(fbFeed.created_time);
                        socialEvent.EventId = fbFeed.id;
                        socialEvent.Message = fbFeed.message ?? String.Empty;
                        socialEvent.Link = fbFeed.link;
                        socialEvent.Type = fbFeed.type;
                        socialEvent.Tags = TryGetTags(fbFeed.message);
                        socialEvent.Activities = new List<Activity>();
                    }

                    if (fbFeed.likes != null)
                    {
                        GetContactFromLikes(fbFeed.likes.data, socialEvent, activityBusinessLogic);
                    }

                    if (fbFeed.comments != null)
                    {
                        GetContactFromComments(fbFeed.comments.data, socialEvent, activityBusinessLogic);
                    }

                    socialNetworkLogic.Add(socialEvent);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private static ICollection<Tag> TryGetTags(string message)
        {
            if (message == null)
            {
                return null;
            }
            var tagBusinessLogic = new TagBusinessLogic(new TagRepository(_factory));
            Regex r = new Regex(@"#\S+(\s|)");
            var result = new List<Tag>();
            var matc = r.Matches(message);
            if (matc != null)
            {
                foreach (var match in matc)
                {
                    result.Add(tagBusinessLogic.GetByNameOrCreate(match.ToString()));
                }
            }
            return result;
        }

        private static Contact TryAddContact(string id, string name )
        {
            try
            {
                var contactBusinessLogic = new ContactBusinessLogic(new ContactRepository(_factory),
                    new DictionaryBusinessLogic<ContactType>(new DictionaryRepository<ContactType>(_factory)),
                    new DictionaryBusinessLogic<ContactStatus>(new DictionaryRepository<ContactStatus>(_factory)),
                    new DictionaryBusinessLogic<AgeDirection>(new DictionaryRepository<AgeDirection>(_factory)),
                    new DictionaryBusinessLogic<ReadyToSellState>(new DictionaryRepository<ReadyToSellState>(_factory)));


                var contact = new Contact()
                {
                    Ip = id,
                    Name = name,
                    Link = "https://www.facebook.com/app_scoped_user_id/" + id + "/",
                    Gender = GenderEnum.Unknown
                };

                var existContact = contactBusinessLogic.GetByIp(id);
                if (existContact == null)
                {
                    contactBusinessLogic.Add(contact);
                    return contact;
                }
                return existContact;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static void GetContactFromLikes(FbLike[] data, SocialNetworkEvent socialEvent, ActivityBusinessLogic activityBusinessLogic)
        {
            try
            {
                foreach (var like in data)
                {
                    if(socialEvent.Activities == null)
                    {
                        socialEvent.Activities = new List<Activity>();
                    }
                    
                    if (socialEvent.Activities.Any(x => x.ExternalId == like.id))
                    {
                        continue;
                    }

                    var contact = TryAddContact(like.id, like.name);
                    var activity = new Activity
                    {
                        Author = contact,
                        ExternalId = like.id,
                        CreateDate = DateTime.Now,
                        Type = activityBusinessLogic.GetActivityType(int.Parse(ActivityEnum.Like.ToString("D"))),
                    };
                    //activityBusinessLogic.Add(activity);
                    //если к этой записи еще нет лайка этого чувака - добавляем
                    socialEvent.Activities.Add(activity);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void GetContactFromComments(FbComment[] data, SocialNetworkEvent socialEvent, ActivityBusinessLogic activityBusinessLogic)
        {
            try
            {
                foreach (var comment in data)
                {
                    if (socialEvent.Activities == null)
                    {
                        socialEvent.Activities = new List<Activity>();
                    }

                    if (socialEvent.Activities.Any(x => x.ExternalId == comment.id))
                    {
                        continue;
                    }

                    var contact = TryAddContact(comment.id, comment.@from.name);

                    var activity = new Activity
                    {
                        CreateDate = DateTime.Parse(comment.CreateTime, CultureInfo.InvariantCulture),
                        ExternalId = comment.id,
                        Author = contact,
                        Type = activityBusinessLogic.GetActivityType(int.Parse(ActivityEnum.Comment.ToString("D"))),
                    };
                    socialEvent.Activities.Add(activity);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}