using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCA.Areas.Evaluation.Controllers
{
    public class CompaniesController : Controller
    {

        public CompaniesController()
        {
            
        }

        // GET: Monitoring/Companies
        public ActionResult List()
        {
            return View();
        }
    }
}