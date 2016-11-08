using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SCA.Areas.Monitoring.Models;
using SCA.BussinesLogic;
using SCA.Domain;

namespace SCA.Areas.Monitoring.Controllers
{
    public class SitePagesController : Controller
    {
        public SitePagesController(IClientSitePagesBusinessLogic pagesBusinessLogic, IClientSiteBusinessLogic siteBusinessLogic)
        {
            _pagesBusinessLogic = pagesBusinessLogic;
            _siteBusinessLogic = siteBusinessLogic;
        }

        //private readonly TagBusinessLogic _tagBusinessLogic = new TagBusinessLogic(new TagRepository());
        private readonly IClientSitePagesBusinessLogic _pagesBusinessLogic;
        private readonly IClientSiteBusinessLogic _siteBusinessLogic;
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
            var items = _pagesBusinessLogic.GetAllEntities().SelectMany(x => x.Tags);
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