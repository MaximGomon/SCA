using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCA.Areas.Monitoring.Models;
using SCA.BussinesLogic;
using SCA.DataAccess.Repositories.Implementations;
using SCA.Domain;

namespace SCA.Areas.Monitoring.Controllers
{
    public class SitePagesController : Controller
    {
        private readonly TagBusinessLogic _tagBusinessLogic = new TagBusinessLogic(new TagRepository());
        private readonly ClientSitePagesBusinessLogic _sitePagesBusinessLogic = new ClientSitePagesBusinessLogic(new ClientSitePageRepository());
        // GET: Monitoring/SitePages
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        public JsonResult GetTags()
        {
            var items = _sitePagesBusinessLogic.GetAllEntities().SelectMany(x => x.Tags);
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void Add(SitePageModel model)
        {
            var dbSitePage = new ClientSitePage
            {
                Name = model.Name,
                IsDeleted = false,
                RelatedUrl = model.RelatedUrl
            };
            _sitePagesBusinessLogic.Add(dbSitePage);
        }
    }
}