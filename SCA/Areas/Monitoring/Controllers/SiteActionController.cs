using System.Web.Mvc;

namespace SCA.Areas.Monitoring.Controllers
{
    /// <summary>
    /// Сообщения
    /// </summary>
    public class SiteActionController : Controller
    {
        // GET: Monitoring/SiteAction
        public ActionResult List()
        {
            return View();
        }
    }
}