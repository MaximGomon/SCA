using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCA.Areas.Evaluation.Controllers
{
    public class WorkflowsController : Controller
    {
        // GET: Evaluation/Workflows
        public ActionResult List()
        {
            return View();
        }
    }
}