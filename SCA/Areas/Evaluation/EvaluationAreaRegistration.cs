using System.Web.Mvc;

namespace SCA.Areas.Evaluation
{
    public class EvaluationAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Evaluation";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Evaluation_default",
                "Evaluation/{controller}/{action}/{id}",
                new { controller = "Companies", action = "List", id = UrlParameter.Optional }
            );
        }
    }
}