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
        [HttpGet]
        public ActionResult Add()
        {
            return View(new SiteModel {Id = Guid.NewGuid()});
        }

        [HttpPost]
        public void Add(SiteModel model)
        {
            var dbSite = model.ConvertToDbSite();
            
            _siteBusinessLogic.Add(dbSite);
        }

        

        public JsonResult PagesList([DataSourceRequest]DataSourceRequest request, Guid id)
        {
            var items = _siteBusinessLogic.GetAllEntities().Where(x => x.Id == id).SelectMany(x => x.Pages).ToList();
            var pages = new List<SitePageModel>();
            foreach (var item in items)
            {
                pages.Add(new SitePageModel
                {
                    Name = item.Name,
                    RelatedUrl = item.RelatedUrl,
                    Id = item.Id,
                    Tag = string.Join(", ", item.Tags.Select(x => x.Name)),
                    SiteId = id

                });
            }
            DataSourceResult result = items.ToDataSourceResult(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            var site = _siteBusinessLogic.GetById(id);
            var model = ConvertToSiteModel(site);
            return View(model);
        }

        public ActionResult List()
        {
            return View();
        }

        [HttpPost]
        public JsonResult List_Read([DataSourceRequest]DataSourceRequest request)
        {
            var items = _siteBusinessLogic.GetAllEntities();//.Select(x => ConvertToSiteModel(x));
            var models = new List<SiteModel>();
            foreach (var clientSite in items)
            {
                models.Add(ConvertToSiteModel(clientSite));
            }
            DataSourceResult result = models.ToDataSourceResult(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private static SiteModel ConvertToSiteModel(ClientSite x)
        {
            return new SiteModel
            {
                Id = x.Id,
                Name = x.Name,
                Company = x.Owner.Name,
                PagesCount = x.Pages.Count,
                Domains = x.Domains.Aggregate((a, b) => a + ";" + b)
            };
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