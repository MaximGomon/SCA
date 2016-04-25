using System;
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
    public class LeadTypeController : Controller
    {
        private readonly LeadTypeBusinessLogic _leadTypeBusinessLogic  = new LeadTypeBusinessLogic(new LeadTypeRepository());
        private readonly TagBusinessLogic _tagBusinessLogic = new TagBusinessLogic(new TagRepository());
        // GET: Monitoring/Lead
        public ActionResult List()
        {
            return View();
        }

        [HttpPost]
        public JsonResult List_Read([DataSourceRequest]DataSourceRequest request)
        {
            var items = _leadTypeBusinessLogic.GetAllEntities();//.Select(x => ConvertToSiteModel(x));
            var models = new List<LeadTypeModel>();
            foreach (var clientSite in items)
            {
                //models.Add(ConvertToLeadModel(clientSite));
            }
            DataSourceResult result = models.ToDataSourceResult(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var leadType = new LeadType();
            return View(new LeadTypeModel
            {
                Id = leadType.Id,
            });
        }
        [HttpPost]
        public void Add(LeadTypeModel model)
        {
            var leadType = new LeadType();
            leadType.Name = model.Name;
            leadType.IsDeleted = false;
            foreach (var tag in model.TagsId)
            {
                leadType.LeadTags.Add(_tagBusinessLogic.GetById(tag));
            }
            //leadType.LeadTags.AddRange(model.Tags);
            _leadTypeBusinessLogic.Add(leadType);
        }

        [HttpPost]
        public JsonResult GetLeadTypes(string contains)
        {
            var items =_leadTypeBusinessLogic.GetAllEntities().Where(x => x.Name == contains);
            var models = new List<LeadTypeModel>();
            foreach (var leadType in items)
            {
                models.Add(leadType.ConvertToModel());
            }
            return Json(items, JsonRequestBehavior.AllowGet);
        }
    }
}