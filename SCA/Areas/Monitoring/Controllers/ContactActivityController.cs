using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SCA.Areas.Monitoring.Models;
using SCA.BussinesLogic;
using SCA.DataAccess.Repositories.Implementations;
using SCA.Domain;

namespace SCA.Areas.Monitoring.Controllers
{
    public class ContactActivityController : Controller
    {
        private readonly ActivityBusinessLogic _activityBusinessLogic = new ActivityBusinessLogic(new ActivityRepository());
        // GET: Monitoring/ContactActivity
        public List<ActivityModel> List()
        {

            return _activityBusinessLogic.GetAllEntities().Select(x => new ActivityModel
            {
                Id = x.Id,
                ActivityDate = x.CreateDate,
                UserName = x.Author.Name,
                Type = x.Type.Name
            }).ToList();
        }
    }
}