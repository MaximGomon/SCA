using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using SCA.Areas.Evaluation.Models;
using SCA.BussinesLogic;
using SCA.DataAccess.Repositories.Implementations;

namespace SCA.Areas.Evaluation.Controllers
{
    /// <summary>
    /// Контакты
    /// </summary>
    public class ContactsController : Controller
    {
        private readonly IContactBusinessLogic _contactBusinessLogic;

        public ContactsController(IContactBusinessLogic contactBusinessLogic)
        {
            _contactBusinessLogic = contactBusinessLogic;
        }

        // GET: Monitoring/Contacts

        public ActionResult List()
        {
            return View();
        }
        
        public ActionResult List_Read(DataSourceRequest request)
        {
            var items = _contactBusinessLogic.GetAllEntities().Select(x => new ContactModel
            {
                Score = x.Score,
                ReadyToSell = x.ReadyToSell.Name,
                Name = x.Name,
                CreateDate = x.CreateDate,
                Email = x.Email,
                Id = x.Id
            });
            DataSourceResult result = items.ToDataSourceResult(request);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}