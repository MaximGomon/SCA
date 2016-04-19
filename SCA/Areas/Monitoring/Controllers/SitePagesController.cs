﻿using System;
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
        public ActionResult Add(Guid id)
        {
            ClientSitePage csp = new ClientSitePage();
            var model = new SitePageModel
            {
                Id = csp.Id,
                SiteId = id,
            };
            return PartialView(model);
        }

        public JsonResult GetTags()
        {
            var items = _sitePagesBusinessLogic.GetAllEntities().SelectMany(x => x.Tags);
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public void Save(SitePageModel model)
        {
            var dbSitePage = new ClientSitePage
            {
                Name = model.PageName,
                IsDeleted = false,
                RelatedUrl = model.RelatedUrl,
                Tags = model.Tag.Split(',').Select(x => new Tag
                {
                    Name = x,
                    IsDeleted = false
                }).ToList(),
                
            };
            _sitePagesBusinessLogic.Add(dbSitePage);
        }
    }
}