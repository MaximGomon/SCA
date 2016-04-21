using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using SCA.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SCA.Controllers
{
    public class HomeController : Controller
    {
        private ICollection<GridData> _list;

        #region ctr

        public HomeController()
        {
            _list = new List<GridData>();
        }

        #endregion

        public ActionResult Index()
        {
            return RedirectToAction("List", "Companies", new { area = "Monitoring"});
        }

        public JsonResult Test([DataSourceRequest]DataSourceRequest request)
        {
            var response = _list.ToDataSourceResult(request);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

    }
}