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
    public class SiteController : Controller
    {
        private readonly ClientSitePagesBusinessLogic _sitePagesBusinessLogic = new ClientSitePagesBusinessLogic(new ClientSitePageRepository());
        private readonly ClientSiteBusinessLogic _siteBusinessLogic = new ClientSiteBusinessLogic(new ClientSiteRepository());
        // GET: Monitoring/Site
        [HttpGet]
        public ActionResult Add()
        {
            return View();
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
    }
}