using SCA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SCA.Controllers
{
    /// <summary>
    /// Для роботи з Kendo Grid
    /// </summary>
    public class GridController : Controller
    {
        /// <summary>
        /// Верхнє меню гріда
        /// </summary>
        /// <param name="partial"></param>
        /// <returns></returns>
        public ActionResult TopMenu(GridTopMenu model = null, bool partial = true)
        {
            if (model == null)
                model = new GridTopMenu();

            if(partial)
                return PartialView(model);

            return View(model);
        }
    }
}