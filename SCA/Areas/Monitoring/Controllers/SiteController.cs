﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using SCA.Areas.Monitoring.Converters;
using SCA.Areas.Monitoring.Models;
using SCA.BussinesLogic;
using SCA.DataAccess.Repositories.Implementations;
using SCA.Domain;

namespace SCA.Areas.Monitoring.Controllers
{
    public class SiteController : Controller
    {
        private readonly IClientSiteBusinessLogic _siteBusinessLogic;

        public SiteController(IClientSiteBusinessLogic siteBusinessLogic)
        {
            _siteBusinessLogic = siteBusinessLogic;
        }

        // GET: Monitoring/Site
        [System.Web.Mvc.HttpGet]
        public ActionResult Add()
        {
            var site = new ClientSite {Name = "Draft"};
            _siteBusinessLogic.Add(site);
            return View(new SiteModel {Id = site.Id});
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Add(SiteModel model)
        {
            var dbSite = model.ConvertToDbSite();
            _siteBusinessLogic.Update(dbSite);
            return RedirectToAction("List");
        }

        
        public JsonResult PagesList(DataSourceRequest request, Guid id)
        {
            var items = _siteBusinessLogic.GetAllEntities().Where(x => x.Id == id).SelectMany(x => x.Pages).ToList();
            var pages = new List<SitePageModel>();
            foreach (var item in items)
            {
                pages.Add(new SitePageModel
                {
                    PageName = item.Name,
                    RelatedUrl = item.RelatedUrl,
                    Id = item.Id,
                    Tag = string.Join(", ", item.Tags.Select(x => x.Name)),
                    SiteId = id

                });
            }
            DataSourceResult result = pages.ToDataSourceResult(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Details(Guid id)
        {
            var site = _siteBusinessLogic.GetById(id);
            return View(site.ConvertToSiteModel());
        }

        public ActionResult List()
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public JsonResult List_Read(DataSourceRequest request, Guid id)
        {
            var items = _siteBusinessLogic.GetAllEntities().Where(x => x.Owner.Id == id);//.Select(x => ConvertToSiteModel(x));
            var models = new List<SiteModel>();
            foreach (var clientSite in items)
            {
                models.Add(clientSite.ConvertToSiteModel());
            }
            DataSourceResult result = models.ToDataSourceResult(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        

        public JsonResult GetSitesContains(string contains)
        {
            var items = _siteBusinessLogic.GetAllEntities().Where(x => x.Name.Contains(contains) && x.Owner == null).ToList();
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search()
        {
            return PartialView();
        }
    }
}