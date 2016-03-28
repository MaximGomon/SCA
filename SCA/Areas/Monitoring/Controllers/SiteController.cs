using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
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
            var dbSite = new ClientSite
            {
                Name = model.Name,
                IsDeleted = false,
                //Pages = model.
            };
            foreach (var sitePageModel in model.Pages)
            {
                dbSite.Pages.Add(_sitePagesBusinessLogic.GetById(sitePageModel.Id));
            }
            _siteBusinessLogic.Add(dbSite);
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
                PagesCount = x.Pages.Count
            };
        }
    }
}