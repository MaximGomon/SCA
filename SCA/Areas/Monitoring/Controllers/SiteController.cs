using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        private readonly ClientSitePagesBusinessLogic _sitePagesBusinessLogic = new ClientSitePagesBusinessLogic(new ClientSitePageRepository());
        private readonly ClientSiteBusinessLogic _siteBusinessLogic = new ClientSiteBusinessLogic(new ClientSiteRepository());
        // GET: Monitoring/Site
        [System.Web.Mvc.HttpGet]
        public ActionResult Add()
        {
            var site = new ClientSite {Name = "Draft"};
            _siteBusinessLogic.Add(site);
            return View(new SiteModel {Id = site.Id});
        }

        [System.Web.Mvc.HttpPost]
        public void Add(SiteModel model)
        {
            var dbSite = model.ConvertToDbSite();
            _siteBusinessLogic.Add(dbSite);
        }

        
        [HttpPost]
        public JsonResult PagesList([DataSourceRequest]DataSourceRequest request, Guid id)
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
            DataSourceResult result = items.ToDataSourceResult(request);
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
        public JsonResult List_Read([DataSourceRequest]DataSourceRequest request)
        {
            var items = _siteBusinessLogic.GetAllEntities();//.Select(x => ConvertToSiteModel(x));
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
            var items = _siteBusinessLogic.GetAllEntities().Where(x => x.Name.Contains(contains)).ToList();
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Search()
        {
            return PartialView();
        }
    }
}