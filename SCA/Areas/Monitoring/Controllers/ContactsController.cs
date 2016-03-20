using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCA.Areas.Monitoring.Controllers
{
    /// <summary>
    /// Контакты
    /// </summary>
    public class ContactsController : Controller
    {
        // GET: Monitoring/Contacts
        public ActionResult List()
        {
            return View();
        }
    }
}