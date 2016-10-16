using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SCA.Areas.Monitoring.Models;
using SCA.BussinesLogic;
using SCA.DataAccess.Repositories.Implementations;
using SCA.Domain;

namespace SCA.Areas.Monitoring.Controllers
{
    public class SitePagesController : Controller
    {
        //private readonly TagBusinessLogic _tagBusinessLogic = new TagBusinessLogic(new TagRepository());
        private readonly ClientSitePagesBusinessLogic _sitePagesBusinessLogic = new ClientSitePagesBusinessLogic(new ClientSitePageRepository());
        private readonly ClientSiteBusinessLogic _siteBusinessLogic = new ClientSiteBusinessLogic(new ClientSiteRepository());
        // GET: Monitoring/SitePages
        [HttpGet]
        public ActionResult Add(Guid id)
        {
            //ClientSitePage csp = new ClientSitePage();
            var model = new SitePageModel
            {
                //Id = csp.Id,
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
                //ToDo Сделать серверную валидацию на существования тега
            };

            

            var site = _siteBusinessLogic.GetById(model.SiteId);
            if (site.Pages == null)
            {
                site.Pages = new List<ClientSitePage>();
            }
            site.Pages.Add(dbSitePage);
            _siteBusinessLogic.Update(site);
            //var tags = model.Tag.Split(',').ToList();
            //foreach (var tag in tags)
            //{
            //    var t1 = _tagBusinessLogic.GetAllEntities().FirstOrDefault(x => x.Name == tag);
            //    if (t1 == null) //Сделать серверную валидацию на существования тега
            //    {
            //        dbSitePage.Tags.Add(new Tag
            //        {
            //            Name = tag,
            //            IsDeleted = false
            //        });
            //    }
            //}
            
        }
    }
}