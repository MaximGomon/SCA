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
    public class CompaniesController : Controller
    {
        private readonly ICompanyBusinessLogic _companyBusinessLogic;
        private readonly IContactBusinessLogic _contactBusinessLogic;
        
        public CompaniesController(ICompanyBusinessLogic companyBusinessLogic, 
            IContactBusinessLogic contactBusinessLogic)
        {
            _companyBusinessLogic = companyBusinessLogic;
            _contactBusinessLogic = contactBusinessLogic;
        }

        // GET: Monitoring/Companies
        public ActionResult List()
        {
            return View();
        }

        public JsonResult GetCompanies(DataSourceRequest request)
        {
            var items = _companyBusinessLogic.GetAllEntities().ToList();
            var models = new List<CompanyModel>();
            foreach (var company in items)
            {
                models.Add(company.ConvertToCompanyModel());
            }
            var result = models.ToDataSourceResult(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public void AddSite(Guid id, Guid siteId)
        {
            _companyBusinessLogic.AddSiteToCompany(id, siteId);
        }

        public JsonResult GetCompanySites(DataSourceRequest request, Guid id)
        {
            var items = _companyBusinessLogic.GetAllEntities().Where(x => x.Id == id).SelectMany(x => x.Sites).ToList();
            var models = new List<SiteModel>();
            foreach (var site in items)
            {
                models.Add(site.ConvertToSiteModel());
            }
            var result = models.ToDataSourceResult(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        

        [HttpGet]
        public ActionResult Add()
        {
            var company = new Company();
            //company.Id = Guid.NewGuid();
            company.Name = "Draft";
            _companyBusinessLogic.Add(company);
            return View(company.ConvertToCompanyModel());
        }

        [HttpGet]
        public ActionResult Details(Guid id)
        {
            var company = _companyBusinessLogic.GetById(id);

            return View(company.ConvertToCompanyModel());
        }

        public ActionResult Create(CompanyModel model)
        {
            var company = model.ConvertToDbCompany(_companyBusinessLogic, _contactBusinessLogic);
            _companyBusinessLogic.Add(company);

            return RedirectToAction("Add", "Site", company.Id);
        }

        [HttpPost]
        public ActionResult Add(CompanyModel model)
        {
            var company = model.ConvertToDbCompany(_companyBusinessLogic, _contactBusinessLogic);
            //foreach (var clientSite in company.Sites)
            //{
            //    company.Sites.Add(_siteBusinessLogic.GetById(clientSite.Id));
            //}

            _companyBusinessLogic.Update(company);
            return RedirectToAction("List");
        }

        public JsonResult GetCompanyTypes()
        {
            var items = _companyBusinessLogic.GetAllTypes().ToList();
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCompanySize()
        {
            var items = _companyBusinessLogic.GetAllSizes().ToList();
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCompanySector()
        {
            var items = _companyBusinessLogic.GetAllSectors().ToList();
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCompanyStatus()
        {
            var items = _companyBusinessLogic.GetAllStatuses().ToList();
            return Json(items, JsonRequestBehavior.AllowGet);
        }
    }
}