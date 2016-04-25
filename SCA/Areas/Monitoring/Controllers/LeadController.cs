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
        private readonly ContactBusinessLogic _contactBusinessLogic = new ContactBusinessLogic(new ContactRepository());
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
            foreach (var lead in items)
            {
                models.Add(new LeadModel
                {
                    Id = lead.Id,
                    LeadType = lead.Type.Name,
                    ContactName = lead.Buyer.Name,
                    Name = lead.Name,
                });
            }
            DataSourceResult result = models.ToDataSourceResult(request);
            return Json(result, JsonRequestBehavior.AllowGet);
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
            var lead = new Lead();
            lead.Name = model.Name;
            lead.Buyer = _contactBusinessLogic.GetById(model.ContactId);
            lead.Type = _leadTypeBusinessLogic.GetById(model.LeadTypeId);
            _leadBusinessLogic.Add(lead);
        }
    }
}