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
    }
}