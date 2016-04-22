using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using SCA.Areas.Monitoring.Models;
using SCA.BussinesLogic;
using SCA.DataAccess.Repositories.Implementations;
using SCA.Domain;

namespace SCA.Areas.Monitoring.Controllers
{
    public class LeadController : Controller
    {
        private readonly LeadBusinessLogic _leadBusinessLogic = new LeadBusinessLogic(new LeadRepository());
        private readonly LeadTypeBusinessLogic _leadTypeBusinessLogic  = new LeadTypeBusinessLogic(new LeadTypeRepository());
        // GET: Monitoring/Lead
        public ActionResult List()
        {
            return View();
        }

        [HttpPost]
        public JsonResult List_Read([DataSourceRequest]DataSourceRequest request)
        {
            var items = _leadBusinessLogic.GetAllEntities();//.Select(x => ConvertToSiteModel(x));
            var models = new List<LeadModel>();
            foreach (var clientSite in items)
            {
                models.Add(ConvertToLeadModel(clientSite));
            }
            DataSourceResult result = models.ToDataSourceResult(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private LeadModel ConvertToLeadModel(Lead lead)
        {
            return new LeadModel
            {
                Id = lead.Id,
                Name = lead.Type.Name,
                ContactName = lead.Buyer.Name
            };
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View(new LeadModel
            {
                Id = Guid.NewGuid()
            });
        }

        

        [HttpPost]
        public void Add(LeadModel model)
        {
            //var leadType = new Lead();
            //leadType.Name = model.Name;
            //leadType.IsDeleted = false;
            //leadType.LeadTags.AddRange(model.Tags);
            //_leadTypeBusinessLogic.Add(leadType);
        }
    }
}