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

namespace SCA.Areas.Evaluation.Controllers
{
    /// <summary>
    /// Контакты
    /// </summary>
    public class ContactsController : Controller
    {
        private readonly ContactBusinessLogic _contactBusinessLogic = new ContactBusinessLogic(new ContactRepository());
        // GET: Monitoring/Contacts

        public ActionResult List()
        {
            return View();
        }
        
        public ActionResult List_Read([DataSourceRequest]DataSourceRequest request)
        {
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
    }
}