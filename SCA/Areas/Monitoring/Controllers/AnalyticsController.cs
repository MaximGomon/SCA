using System.Web.Mvc;

namespace SCA.Areas.Monitoring.Controllers
{
    /// <summary>
    /// Аналитика
    /// </summary>
    public class AnalyticsController : Controller
    {
        // GET: Monitoring/Analytics
        public ActionResult List()
        {
            return View();
        }
    }
}