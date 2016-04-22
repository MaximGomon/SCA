﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Mvc;
using Facebook;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using SCA.Areas.Monitoring.Converters;
using SCA.Areas.Monitoring.Models;
using SCA.BussinesLogic;
using SCA.DataAccess.Repositories.Implementations;
using SCA.Domain;
using SCA.Domain.Enums;
using SCA.Models.Facebook;

namespace SCA.Areas.Monitoring.Controllers
{
    /// <summary>
    /// Контакты
    /// </summary>
    public class ContactsController : Controller
    {
        private readonly ContactBusinessLogic _contactBusinessLogic = new ContactBusinessLogic(new ContactRepository());
        private readonly CompanyBusinessLogic _companyBusinessLogic = new CompanyBusinessLogic(new CompanyRepository());
        private readonly DictionaryBusinessLogic<ContactType> _contactTypeBusinessLogic = new DictionaryBusinessLogic<ContactType>(new DictionaryRepository<ContactType>());
        private readonly DictionaryBusinessLogic<ContactStatus> _contactStatusBusinessLogic = new DictionaryBusinessLogic<ContactStatus>(new DictionaryRepository<ContactStatus>());
        private readonly DictionaryBusinessLogic<AgeDirection> _ageBusinessLogic = new DictionaryBusinessLogic<AgeDirection>(new DictionaryRepository<AgeDirection>());
        private readonly DictionaryBusinessLogic<ReadyToSellState> _sellBusinessLogic = new DictionaryBusinessLogic<ReadyToSellState>(new DictionaryRepository<ReadyToSellState>());
        private readonly SettingBusinessLogic _settingBusinessLogic = new SettingBusinessLogic(new SystemSettingRepository());

        // GET: Monitoring/Contacts
        public ActionResult List()
        {
           return View();
        }

        public ActionResult Details(Guid id)
        {
            var contact = _contactBusinessLogic.GetById(id);

            return View(contact.ConvertToContactModel());
        }


        public JsonResult GetContactsContains(string contains)
        {
            var items = _contactBusinessLogic.GetAllEntities().Where(x => x.Name.Contains(contains)).ToList();
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public JsonResult List_Read([DataSourceRequest]DataSourceRequest request)
        {
            var items = _contactBusinessLogic.GetAllEntities().ToList();//.Select(x => x.ConvertToContactModel());

            var models = new List<ContactModel>();

            foreach (var contact in items)
            {
                models.Add(contact.ConvertToContactModel());
            }

            DataSourceResult result = models.ToDataSourceResult(request);
            return Json(result);
        }
     

        public JsonResult GetContactTypes()
        {
            var items = _contactTypeBusinessLogic.GetAllEntities().ToList();
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCompanies()
        {
            var items = _companyBusinessLogic.GetAllEntities().ToList();
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetGender()
        {
            var items = new List<DictionaryEntity>
            {
                new DictionaryEntity {Code = int.Parse(GenderEnum.Unknown.ToString("D")), Name = GenderEnum.Unknown.ToString()},
                new DictionaryEntity {Code = int.Parse(GenderEnum.Man.ToString("D")), Name = GenderEnum.Man.ToString()},
                new DictionaryEntity {Code = int.Parse(GenderEnum.Woman.ToString("D")), Name = GenderEnum.Woman.ToString()},
            };
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetContactStatuses()
        {
            var items = _contactStatusBusinessLogic.GetAllEntities().ToList();
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAgeDirection()
        {
            var items = _ageBusinessLogic.GetAllEntities().ToList();
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSellStatus()
        {
            var items = _sellBusinessLogic.GetAllEntities().ToList();
            return Json(items, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(ContactModel contact)
        {
            _contactBusinessLogic.Add(contact.ConvertToDbContact());
            return RedirectToAction("List");
        }

        public List<SocialNetworkEvent> InfoEvents()
        {
            var eventData = GetInfoSocialNetwork();

            List<SocialNetworkEvent> social = new List<SocialNetworkEvent>();

            foreach (var socialEvent in eventData.data)
            {
                var soc = new SocialNetworkEvent()
                {
                    EventId = socialEvent.id,
                    Link = socialEvent.link,
                    Type = socialEvent.type,
                    Avtor = null,
                    Activities = null,
                    //DateCreated = socialEvent.created_time,
                    Message = socialEvent.message,
                    Tags = null
                };
                social.Add(soc);    
            }
            return social;
        }

        public void GetInfo()
        {
            var eventLike = GetInfoSocialNetwork();
            var data = eventLike.data;

            GetContactFrom(data);
            GetContactLikes(data.Select(x => x.likes).Where(x => x != null).ToArray());
            GetContactComments(data.Select(x => x.comments).Where(x => x != null).ToArray());
        }

        public FbFeeds GetInfoSocialNetwork()
        {
            try
            {
                var groupId = ConfigurationManager.AppSettings["GroupId"];
                var filter = ConfigurationManager.AppSettings["FacebookFilter"];
                var accessToken = _settingBusinessLogic.GetByKey(SettingKeyEnum.AccessToken.ToString());
                var cl = new FacebookClient(accessToken.Value);
                var query = cl.Get(groupId + "/?fields=" + filter);
                var ser = new DataContractJsonSerializer(typeof (FbData));
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

        public void GetContactFrom(FbFeed[] data)
        {
            try
            {
                var fbfrom = data.Select(dtId => dtId.@from).ToList();

                foreach (var dtF in fbfrom)
                {
                    var cc = new ContactModel()
                    {
                        Id = Guid.NewGuid(),
                        ContactIp = dtF.id,
                        Name = dtF.name,
                        //Email = "yourEmail@mail.ru",
                        ContactLink = "https://www.facebook.com/app_scoped_user_id/" + dtF.id + "/",
                        ReadyToBuyScore = 3,
                        Gender = GenderEnum.Unknown.ToString()
                    };

                    if (_contactBusinessLogic.GetByIp(dtF.id) == null)
                    {
                        _contactBusinessLogic.Add(cc.ConvertToDbContact());
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void GetContactLikes(FbLikes[] data)
        {
            try
            {
                foreach (var dtL in data)
                {
                    foreach (var d in dtL.data)
                    {
                        var cc = new ContactModel()
                        {
                            Id = Guid.NewGuid(),
                            ContactIp = d.id,
                            Name = d.name,
                            //Email = "yourEmail@mail.ru",
                            ContactLink = d.link,
                            ReadyToBuyScore = 3,
                            Gender = GenderEnum.Unknown.ToString()
                        };

                        if (_contactBusinessLogic.GetByIp(d.id.ToString()) == null)
                        {
                            _contactBusinessLogic.Add(cc.ConvertToDbContact());
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GetContactComments(FbComments[] data)
        {
            try
            {
                foreach (var dtC in data)
                {
                    foreach (var o in dtC.data.Select(x => x.@from))
                    {
                        var cc = new ContactModel()
                        {
                            Id = Guid.NewGuid(),
                            ContactIp = o.id,
                            Name = o.name,
                            //Email = "yourEmail@mail.ru",
                            ContactLink = "https://www.facebook.com/app_scoped_user_id/" + o.id + "/",
                            ReadyToBuyScore = 3,
                            Gender = GenderEnum.Unknown.ToString()
                        };

                        if (_contactBusinessLogic.GetByIp(o.id.ToString()) == null)
                        {
                            _contactBusinessLogic.Add(cc.ConvertToDbContact());
                        }
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