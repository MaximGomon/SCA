using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using SCA.Areas.Monitoring.Converters;
using SCA.Areas.Monitoring.Models;
using SCA.BussinesLogic;
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
            return Json(result, JsonRequestBehavior.AllowGet);
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
    }
}