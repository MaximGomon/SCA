using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using SCA.Areas.Monitoring.Models;
using SCA.BussinesLogic;
using SCA.DataAccess.Repositories.Implementations;
using SCA.Domain;

namespace SCA.Areas.Monitoring.Controllers
{
    public class ContactActivityController : Controller
    {
        private readonly ActivityBusinessLogic _activityBusinessLogic = new ActivityBusinessLogic(new ActivityRepository());
        // GET: Monitoring/ContactActivity
        public ActionResult List()
        {
            return View();
        }

        public JsonResult List_Read([DataSourceRequest]DataSourceRequest request)
        {
            var items = _activityBusinessLogic.GetAllEntities().Select(x => new ActivityModel
            {
                Id = x.Id,
                ActivityDate = x.CreateDate,
                UserName = x.Author.Name,
                Type = x.Type.Name,
                UserAgent = x.UserAgent,
                //Tags = x.GetAllTags(),
            }).ToList();
            DataSourceResult result = items.ToDataSourceResult(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}