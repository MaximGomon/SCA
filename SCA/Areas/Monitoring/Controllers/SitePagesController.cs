using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCA.Areas.Monitoring.Controllers
{
    public class SitePagesController : Controller
    {
        // GET: Monitoring/SitePages
        public ActionResult Add()
        {
            return View();
        }
    }
}