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
    public class CompaniesController : Controller
    {
        private readonly CompanyBusinessLogic _companyBusinessLogic = new CompanyBusinessLogic(new CompanyRepository());
        private readonly ClientSiteBusinessLogic _siteBusinessLogic = new ClientSiteBusinessLogic(new ClientSiteRepository());
        private readonly ContactBusinessLogic _contactBusinessLogic = new ContactBusinessLogic(new ContactRepository());
        private readonly DictionaryBusinessLogic<CompanyType> _typeBusinessLogic = new DictionaryBusinessLogic<CompanyType>(new DictionaryRepository<CompanyType>());
        private readonly DictionaryBusinessLogic<CompanyStatus> _statusBusinessLogic = new DictionaryBusinessLogic<CompanyStatus>(new DictionaryRepository<CompanyStatus>());
        private readonly DictionaryBusinessLogic<CompanyRelation> _relationBusinessLogic = new DictionaryBusinessLogic<CompanyRelation>(new DictionaryRepository<CompanyRelation>());
        private readonly DictionaryBusinessLogic<CompanySize> _sizeBusinessLogic = new DictionaryBusinessLogic<CompanySize>(new DictionaryRepository<CompanySize>());
        private readonly DictionaryBusinessLogic<CompanySector> _sectorBusinessLogic = new DictionaryBusinessLogic<CompanySector>(new DictionaryRepository<CompanySector>());

        public CompaniesController()
        {

        }

        // GET: Monitoring/Companies
        public ActionResult List()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetCompanies([DataSourceRequest] DataSourceRequest request)
        {
            var items = _companyBusinessLogic.GetAllEntities();
            var result = items.ToDataSourceResult(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Details()
        {
            return View();
        }

        [HttpPost]
        public void Add(CompanyModel model)
        {
            
            var company = new Company
            {
                Comment = model.Comment,
                CreateDate = DateTime.Now,
                Name = model.Name,
                IsDeleted = false,
                
            };
            foreach (var clientSite in company.Sites)
            {
                company.Sites.Add(_siteBusinessLogic.GetById(clientSite.Id));
            }

            _companyBusinessLogic.Add(company);
        }

        public JsonResult GetCompanyTypes()
        {
            var items = _typeBusinessLogic.GetAllEntities().ToList();
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetOwnersContains(string contains)
        {
            var items = _contactBusinessLogic.GetAllEntities().Where(x => x.Name.Contains(contains)).ToList();
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

        public JsonResult GetCompanyRelation()
        {
            var items = _relationBusinessLogic.GetAllEntities().ToList();
            return Json(items, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCompanyStatus()
        {
            var items = _statusBusinessLogic.GetAllEntities().ToList();
            return Json(items, JsonRequestBehavior.AllowGet);
        }
    }
}