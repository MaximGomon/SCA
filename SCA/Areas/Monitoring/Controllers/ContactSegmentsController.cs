using System.Web.Mvc;

namespace SCA.Areas.Monitoring.Controllers
{
    /// <summary>
    /// Сегментация клиентов
    /// </summary>
    public class ContactSegmentsController : Controller
    {
        // GET: Monitoring/ContactSegments
        public ActionResult List()
        {
            return View();
        }
    }
}