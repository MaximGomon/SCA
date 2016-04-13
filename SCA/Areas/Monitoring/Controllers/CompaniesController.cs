using System;
using System.Collections.Generic;
using System.Drawing;
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
    public class CompaniesController : Controller
    {
        private readonly CompanyBusinessLogic _companyBusinessLogic = new CompanyBusinessLogic(new CompanyRepository());
        private readonly ContactBusinessLogic _contactBusinessLogic = new ContactBusinessLogic(new ContactRepository());
        private readonly DictionaryBusinessLogic<CompanyType> _typeBusinessLogic = new DictionaryBusinessLogic<CompanyType>(new DictionaryRepository<CompanyType>());
        private readonly DictionaryBusinessLogic<CompanyStatus> _statusBusinessLogic = new DictionaryBusinessLogic<CompanyStatus>(new DictionaryRepository<CompanyStatus>());
        private readonly DictionaryBusinessLogic<CompanySize> _sizeBusinessLogic = new DictionaryBusinessLogic<CompanySize>(new DictionaryRepository<CompanySize>());
        private readonly DictionaryBusinessLogic<CompanySector> _sectorBusinessLogic = new DictionaryBusinessLogic<CompanySector>(new DictionaryRepository<CompanySector>());

        // GET: Monitoring/Companies
        public ActionResult List()
        {
            return View();
        }
        
        public JsonResult GetCompanies([DataSourceRequest] DataSourceRequest request)
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

        

        [HttpGet]
        public ActionResult Add()
        {
            var company = new Company();
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
            var company = model.ConvertToDbCompany();
            _companyBusinessLogic.Add(company);

            return RedirectToAction("Add", "Site", company.Id);
        }

        [HttpPost]
        public ActionResult Add(CompanyModel model)
        {
            var company = model.ConvertToDbCompany();
            //foreach (var clientSite in company.Sites)
            //{
            //    company.Sites.Add(_siteBusinessLogic.GetById(clientSite.Id));
            //}

            _companyBusinessLogic.Add(company);
            return RedirectToAction("List");
        }

        

        public JsonResult GetCompanyTypes()
        {
            var items = _typeBusinessLogic.GetAllEntities().ToList();
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        

        public JsonResult GetCompanySize()
        {
            var items = _sizeBusinessLogic.GetAllEntities().ToList();
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCompanySector()
        {
            var items = _sectorBusinessLogic.GetAllEntities().ToList();
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCompanyStatus()
        {
            var items = _statusBusinessLogic.GetAllEntities().ToList();
            return Json(items, JsonRequestBehavior.AllowGet);
        }
    }
}