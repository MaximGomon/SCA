using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Facebook;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.Owin.Security.Facebook;
using Newtonsoft.Json.Linq;
using SCA.Areas.Monitoring.Converters;
using SCA.Areas.Monitoring.Models;
using SCA.BussinesLogic;
using SCA.DataAccess;
using SCA.DataAccess.Repositories.Implementations;
using SCA.Domain;
using SCA.Domain.Enums;

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
        private const string GroupId = "495703520632964";
        private const string Filter = "feed{from,updated_time,created_time,message,link,type,comments{message,from},likes{id,name,link}}";

        // GET: Monitoring/Contacts
        public ActionResult List()
        {
           GetInfo();
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
            var eventData = GetInfoSocialNetwork(GroupId, Filter);

            var dataJson = eventData.feed.data;

            List<SocialNetworkEvent> social = new List<SocialNetworkEvent>();

            foreach (var dtId in dataJson)
            {
                var soc = new SocialNetworkEvent()
                {
                    Id = dtId.id,
                    Link = dtId.link,
                    Type = dtId.type,
                    Avtor = null,
                    Activities = null,
                    DateCreated = dtId.created_time,
                    Message = dtId.message,
                    Tags = null
                };
                social.Add(soc);    
            }
            return social;
        }

        public void GetInfo()
        {
            var eventLike = GetInfoSocialNetwork(GroupId, Filter);
            var data = eventLike.feed.data;

            GetContactFrom(data);
            GetContactLikes(data);
            GetContactComments(data);
        }

        public dynamic GetInfoSocialNetwork(string groupId, string filter )
        {
            try
            {
                if (HttpContext.Session?["accessT"] != null)
                {
                    var cl = new FacebookClient(HttpContext.Session["accessT"].ToString());
                    var query = cl.Get(groupId + "/?fields=" + filter);
                    dynamic parsQuery = JObject.Parse(query.ToString());
                    return parsQuery;
                }
            }
            catch (Exception)
            {
                // ignored
            }
            return "Error";
        }

        public void GetContactFrom(dynamic data)
        {
            try
            {
                var dtjsFrom = new List<dynamic>();

                foreach (var dtId in data)
                {
                    dtjsFrom.Add(dtId.from);
                }

                foreach (var dtF in dtjsFrom)
                {
                    var cc = new ContactModel()
                    {
                        Id = Guid.NewGuid(),
                        ContactIp = dtF.id,
                        Name = dtF.name,
                        Email = "yourEmail@mail.ru",
                        ContactLink = "https://www.facebook.com/app_scoped_user_id/" + dtF.id + "/",
                        ReadyToBuyScore = 3,
                        Gender = GenderEnum.Unknown.ToString()
                    };

                    if (_contactBusinessLogic.GetByIp(dtF.id.ToString()) == null)
                    {
                        _contactBusinessLogic.Add(cc.ConvertToDbContact());
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void GetContactLikes(dynamic data)
        {
            try
            {
                var dtJslike = new List<dynamic>();

                foreach (var dtId in data)
                {
                    if (dtId.likes != null)
                    {
                        dtJslike.Add(dtId.likes);
                    }
                }

                foreach (var dtL in dtJslike)
                {
                    foreach (var d in dtL.data)
                    {
                        var cc = new ContactModel()
                        {
                            Id = Guid.NewGuid(),
                            ContactIp = d.id,
                            Name = d.name,
                            Email = "yourEmail@mail.ru",
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

        public void GetContactComments(dynamic data)
        {
            try
            {
           
                var dtJsComment = new List<dynamic>();
                var comentFrom = new List<dynamic>();
                foreach (var dtId in data)
                {
                    if (dtId.comments != null)
                    {
                        dtJsComment.Add(dtId.comments);
                    }
                }

                foreach (var dtC in dtJsComment)
                {
                    foreach (var d in dtC.data)
                    {
                       comentFrom.Add(d.from);
                    }
                }

                foreach (var o in comentFrom)
                {
                        var cc = new ContactModel()
                        {
                            Id = Guid.NewGuid(),
                            ContactIp = o.id,
                            Name = o.name,
                            Email = "yourEmail@mail.ru",
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
            catch (Exception)
            {

                throw;
            }
        }
    }
}