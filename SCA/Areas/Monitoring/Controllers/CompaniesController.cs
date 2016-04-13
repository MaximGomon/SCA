using System;
using System.Collections.Generic;
using System.Drawing;
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
                models.Add(ConvertToCompanyModel(company));
            }
            var result = models.ToDataSourceResult(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        private static CompanyModel ConvertToCompanyModel(Company company)
        {
            //return new CompanyModel
            //{
            //    Id = company.Id,
            //    Name = company.Name ?? String.Empty,
            //    CreateDate = company.CreateDate,
            //    Comment = company.Comment ?? String.Empty,
            //    OwnerName = company.Owner.Name ?? String.Empty,
            //    Sector = company.Sector.Name ?? String.Empty,
            //    Size = company.Size.Name ?? String.Empty,
            //    Status = company.Status.Name ?? String.Empty,
            //    Type = company.Type.Name ?? String.Empty,
            //};
            var result = new CompanyModel();
            result.Id = company.Id;
            result.Name = company.Name;
            result.CreateDate = company.CreateDate;
            result.Comment = company.Comment;
            result.OwnerName = company.Owner != null ?  company.Owner.Name : String.Empty;
            result.Sector = company.Sector != null ? company.Sector.Name : String.Empty;
            result.Size = company.Size != null ? company.Size.Name : String.Empty;
            result.Status = company.Status != null ? company.Status.Name : String.Empty;
            result.Type = company.Type != null ? company.Type.Name : String.Empty;
            return result;
        }

        [HttpGet]
        public ActionResult Add()
        {
            var company = new Company();
            return View(ConvertToCompanyModel(company));
        }

        [HttpGet]
        public ActionResult Details()
        {
            return View();
        }

        public ActionResult Create(CompanyModel model)
        {
            var company = ConvertToDbCompany(model);
            _companyBusinessLogic.Add(company);

            return RedirectToAction("Add", "Site", company.Id);
        }

        [HttpPost]
        public ActionResult Add(CompanyModel model)
        {
            var company = ConvertToDbCompany(model);
            //foreach (var clientSite in company.Sites)
            //{
            //    company.Sites.Add(_siteBusinessLogic.GetById(clientSite.Id));
            //}

            _companyBusinessLogic.Add(company);
            return RedirectToAction("List");
        }

        private Company ConvertToDbCompany(CompanyModel model)
        {
            var company = new Company
            {
                Comment = model.Comment,
                CreateDate = DateTime.Now,
                Name = model.Name,
                IsDeleted = false,
                Type = _typeBusinessLogic.GetById(model.TypeId),
                Size = _sizeBusinessLogic.GetById(model.SizeId),
                Sector = _sectorBusinessLogic.GetById(model.SectorId),
                Status = _statusBusinessLogic.GetById(model.StatusId),
                Owner = _contactBusinessLogic.GetById(model.OwnerId), 
                Id = model.Id,
            };
            return company;
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

        public JsonResult GetCompanyStatus()
        {
            var items = _statusBusinessLogic.GetAllEntities().ToList();
            return Json(items, JsonRequestBehavior.AllowGet);
        }
    }
}