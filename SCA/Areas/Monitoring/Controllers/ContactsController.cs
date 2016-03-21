using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using SCA.Areas.Evaluation.Models;
using SCA.BussinesLogic;
using SCA.DataAccess.Repositories.Implementations;
using SCA.Domain;

namespace SCA.Areas.Monitoring.Controllers
{
    /// <summary>
    /// Контакты
    /// </summary>
    public class ContactsController : Controller
    {
        private readonly ContactBusinessLogic _contactBusinessLogic = new ContactBusinessLogic(new ContactRepository());
        private readonly DictionaryBusinessLogic<ContactType> _contactTypeBusinessLogic = new DictionaryBusinessLogic<ContactType>(new DictionaryRepository<ContactType>());
        private readonly DictionaryBusinessLogic<ContactStatus> _contactStatusBusinessLogic = new DictionaryBusinessLogic<ContactStatus>(new DictionaryRepository<ContactStatus>());
        private readonly DictionaryBusinessLogic<AgeDirection> _ageBusinessLogic = new DictionaryBusinessLogic<AgeDirection>(new DictionaryRepository<AgeDirection>());
        // GET: Monitoring/Contacts
        public ActionResult List()
        {
            return View();
        }

        public JsonResult List_Read([DataSourceRequest]DataSourceRequest request)
        {
            //var items = _contactBusinessLogic.GetAllEntities().Select(x => new ContactModel
            //{
            //    Score = x.Score,
            //    ReadyToSell = x.ReadyToSell.Name,
            //    Name = x.Name,
            //    CreateDate = x.CreateDate,
            //    Email = x.Email,
            //    Id = x.Id
            //});
            //return items.ToList();
            var items = _contactBusinessLogic.GetAllEntities().Select(x => new ContactModel
            {
                Score = x.Score,
                ReadyToSell = x.ReadyToSell.Name,
                Name = x.Name,
                CreateDate = x.CreateDate,
                Email = x.Email,
                Id = x.Id
            });
            DataSourceResult result = items.ToDataSourceResult(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetContactTypes([DataSourceRequest]DataSourceRequest request)
        {
            var items = _contactTypeBusinessLogic.GetAllEntities();
            DataSourceResult result = items.ToDataSourceResult(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetContactStatuses([DataSourceRequest]DataSourceRequest request)
        {
            var items = _contactStatusBusinessLogic.GetAllEntities();
            DataSourceResult result = items.ToDataSourceResult(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAgeDirection([DataSourceRequest]DataSourceRequest request)
        {
            var items = _ageBusinessLogic.GetAllEntities();
            DataSourceResult result = items.ToDataSourceResult(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public void Add(ContactModel contact)
        {
            var dbContact = new Contact();
            _contactBusinessLogic.Add(dbContact);
        }
    }
}