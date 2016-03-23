using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCA.Areas.Monitoring.Controllers
{
    public class SiteController : Controller
    {
        // GET: Monitoring/Site
        public ActionResult Add()
        {
            return View();
        }
    }
}