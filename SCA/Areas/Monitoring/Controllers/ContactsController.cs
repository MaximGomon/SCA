using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using SCA.Areas.Monitoring.Converters;
using SCA.Areas.Monitoring.Models;
using SCA.BussinesLogic;
using SCA.Domain;
using SCA.Domain.Enums;

namespace SCA.Areas.Monitoring.Controllers
{
    /// <summary>
    /// Контакты
    /// </summary>
    public class ContactsController : Controller
    {
        private readonly IContactBusinessLogic _contactBusinessLogic;
        private readonly ICompanyBusinessLogic _companyBusinessLogic;

        public ContactsController(IContactBusinessLogic contactBusinessLogic, ICompanyBusinessLogic companyBusinessLogic)
        {
            _contactBusinessLogic = contactBusinessLogic;
            _companyBusinessLogic = companyBusinessLogic;
        }


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

        public JsonResult List_Read(DataSourceRequest request)
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
            var items = _contactBusinessLogic.GetAllTypes().ToList();
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
            var items = _contactBusinessLogic.GetAllStatuses().ToList();
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAgeDirection()
        {
            var items = _contactBusinessLogic.GetAllAges().ToList();
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSellStatus()
        {
            var items = _contactBusinessLogic.GetAllSellStatuses().ToList();
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
            var dbContact = _contactBusinessLogic.GetById(contact.Id);
            if (dbContact == null)
            {
                dbContact = new Contact();
            }
            dbContact.Age = _contactBusinessLogic.GetAllAges().First(x => x.Id == contact.AgeDirectionId);
            dbContact.BirthDate = contact.BirthDate;
            dbContact.Comment = contact.Comment;
            dbContact.CreateDate = DateTime.Now;
            dbContact.Email = contact.Email;
            dbContact.Ip = contact.ContactIp;
            dbContact.Gender = (GenderEnum)Enum.Parse(typeof(GenderEnum), contact.Gender);
            dbContact.Link = contact.ContactLink;
            dbContact.IsNameChecked = true;
            dbContact.ReadyToBuyScore = contact.ReadyToBuyScore;
            dbContact.ReadyToSell = _contactBusinessLogic.GetAllSellStatuses().First(x => x.Id == contact.ReadyToSellId);
            //dbContact.Telephones = contact.Telephones.Split(';').ToList();
            dbContact.Status = _contactBusinessLogic.GetAllStatuses().First(x => x.Id == contact.StatusId);
            dbContact.Type = _contactBusinessLogic.GetAllTypes().First(x => x.Id == contact.ContactTypeId);
            dbContact.Name = contact.Name;
            _contactBusinessLogic.Add(dbContact);
            return RedirectToAction("List");
        }


    }
}