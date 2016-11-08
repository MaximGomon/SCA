using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Text.RegularExpressions;
using Facebook;
using SCA.BussinesLogic;
using SCA.DataAccess.Repositories.Implementations;
using SCA.Domain;
using SCA.Domain.Enums;
using SCA.Models.Facebook;

namespace SCA.Helpers
{
    public static class FbHelper
    {
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
            var settingBusinessLogic = new SettingBusinessLogic(new SystemSettingRepository());
            settingBusinessLogic.Add(new SystemSetting
            {
                Key = SettingKeyEnum.AccessToken.ToString(),
                Value = fb.AccessToken
            });
        }

        //public static List<SocialNetworkEvent> InfoEvents()
        //{
        //    var eventData = GetInfoSocialNetwork();

        //    List<SocialNetworkEvent> social = new List<SocialNetworkEvent>();

        //    foreach (var socialEvent in eventData.data)
        //    {
        //        var soc = new SocialNetworkEvent()
        //        {
        //            EventId = socialEvent.id,
        //            Link = socialEvent.link,
        //            Type = socialEvent.type,
        //            Avtor = null,
        //            Activities = null,
        //            //DateCreated = socialEvent.created_time,
        //            Message = socialEvent.message,
        //            Tags = null
        //        };
        //        social.Add(soc);
        //    }
        //    return social;
        //}

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
                var settingBusinessLogic = new SettingBusinessLogic(new SystemSettingRepository());
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
            catch (Exception)
            {
                throw; // ignored
            }
        }

        public static void GetContactFrom(FbFeed[] data)
        {
            try
            {
                foreach (var fbFeed in data)
                {
                    var socialEvent = new SocialNetworkEvent();
                    var contact = TryAddContact(fbFeed.@from.id, fbFeed.@from.name);
                    socialEvent.Avtor = contact;
                    socialEvent.CreateDate = DateTime.Parse(fbFeed.created_time);
                    socialEvent.EventId = fbFeed.id;
                    socialEvent.Message = fbFeed.message ?? String.Empty;
                    socialEvent.Link = fbFeed.link;
                    socialEvent.Type = fbFeed.type;
                    socialEvent.Tags = TryGetTags(fbFeed.message);
                    socialEvent.Activities = new List<Activity>();
                    GetContactFromLikes(data.Select(x => x.likes).Where(x => x != null).ToArray(), socialEvent);
                    GetContactFromComments(data.Select(x => x.comments).Where(x => x != null).ToArray(), socialEvent);
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
            var tagBusinessLogic = new TagBusinessLogic(new TagRepository());
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

        private static Contact TryAddContact(string id, string name)
        {
            var contact = new Contact()
            {
                Ip = id,
                Name = name,
                Link = "https://www.facebook.com/app_scoped_user_id/" + id + "/",
                Gender = GenderEnum.Unknown
            };
            var contactBusinessLogic = new ContactBusinessLogic(new ContactRepository());
            if (contactBusinessLogic.GetByIp(contact.Ip) == null)
            {
                contactBusinessLogic.Add(contact);
            }
            return contact;
        }

        public static void GetContactFromLikes(FbLikes[] data, SocialNetworkEvent socialEvent)
        {
            try
            {
                var activityTypeBusinessLogic = new DictionaryBusinessLogic<ActivityType>(new DictionaryRepository<ActivityType>());
                var activityBusinessLogic = new ActivityBusinessLogic(new ActivityRepository());
                foreach (var likes in data)
                {
                    foreach (var like in likes.data)
                    {
                        var contact = TryAddContact(like.id, like.name);
                        var activity = new Activity
                        {
                            Author = contact,
                            CreateDate = DateTime.Now,
                            Type = activityTypeBusinessLogic.GetByCode(int.Parse(ActivityEnum.Like.ToString("D")))
                        };
                        activityBusinessLogic.Add(activity);
                        socialEvent.Activities.Add(activity);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public static void GetContactFromComments(FbComments[] data, SocialNetworkEvent socialEvent)
        {
            try
            {
                var activityTypeBusinessLogic = new DictionaryBusinessLogic<ActivityType>(new DictionaryRepository<ActivityType>());
                var activityBusinessLogic = new ActivityBusinessLogic(new ActivityRepository());
                foreach (var comments in data)
                {
                    foreach (var fbFrom in comments.data.Select(x => x.@from))
                    {
                        var contact = TryAddContact(fbFrom.id, fbFrom.name);
                        var activity = new Activity
                        {
                            Author = contact,
                            CreateDate = DateTime.Now,
                            Type = activityTypeBusinessLogic.GetByCode(int.Parse(ActivityEnum.Comment.ToString("D")))
                        };
                        activityBusinessLogic.Add(activity);
                        socialEvent.Activities.Add(activity);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}