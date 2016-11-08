using System;
using System.Linq;
using System.Web.Mvc;
using SCA.Areas.Monitoring.Models;
using SCA.BussinesLogic;
using SCA.DataAccess.Repositories.Implementations;

namespace SCA.Areas.Monitoring.Controllers
{
    public class TagController : Controller
    {

        private readonly TagBusinessLogic _tagBusinessLogic = new TagBusinessLogic(new TagRepository());
        // GET: Monitoring/Tag
        [HttpGet]
        public JsonResult GetTags()
        {
            var items = _tagBusinessLogic.GetAllEntities().ToList();
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Update(TagModel model)
        {
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult List()
        {
            return View();
        }

        public ActionResult Edit(Guid id)
        {
            var tag = _tagBusinessLogic.GetById(id);
            return View();
        }
    }
}