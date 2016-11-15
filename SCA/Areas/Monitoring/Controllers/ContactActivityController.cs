using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using SCA.Areas.Monitoring.Models;
using SCA.BussinesLogic;
using SCA.DataAccess.Repositories.Implementations;

namespace SCA.Areas.Monitoring.Controllers
{
    public class ContactActivityController : Controller
    {
        private readonly IActivityBusinessLogic _activityBusinessLogic;

        public ContactActivityController(IActivityBusinessLogic activityBusinessLogic)
        {
            _activityBusinessLogic = activityBusinessLogic;
        }

        // GET: Monitoring/ContactActivity
        public ActionResult List()
        {
            return View();
        }

        public JsonResult List_Read(DataSourceRequest request)
        {
            var items = _activityBusinessLogic.GetAllEntities().ToArray();//.Select(x => new ActivityModel
            //{
            //    Id = x.Id,
            //    ActivityDate = x.CreateDate,
            //    UserName = x.Author.Name,
            //    Type = x.Type.Name,
            //    UserAgent = x.UserAgent,
            //    //Tags = x.GetAllTags(),
            //}).ToList();
            items.FirstOrDefault();
            var act = new List<ActivityModel>();
            foreach (var activity in items)
            {
                act.Add(new ActivityModel
                {
                    Tags = activity.GetAllTags(),
                    Id = activity.Id,
                    UserAgent = activity.UserAgent,
                    ActivityDate = activity.CreateDate,
                    UserName = activity.Author.Name,
                    //Type = activity.Type.Name
                });
            }
            DataSourceResult result = act.ToDataSourceResult(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}