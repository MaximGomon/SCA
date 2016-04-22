using System;
using System.Collections.Generic;
using System.Linq;
using SCA.Areas.Monitoring.Models;
using SCA.BussinesLogic;
using SCA.DataAccess.Repositories.Implementations;
using SCA.Domain;

namespace SCA.Areas.Monitoring.Converters
{
    public static class SiteConverter
    {
        public static ClientSite ConvertToDbSite(this SiteModel model)
        {
            //var sitePagesBusinessLogic = new ClientSitePagesBusinessLogic(new ClientSitePageRepository());
            var siteBusinessLogic = new ClientSiteBusinessLogic(new ClientSiteRepository());
            //var companyBusinessLogic = new CompanyBusinessLogic(new CompanyRepository());

            var dbSite = siteBusinessLogic.GetById(model.Id);
            dbSite.Url = model.Url;
            dbSite.Name = model.Name;
            dbSite.Domains.AddRangeIfNoExist(model.Domains.Split(',').AsEnumerable());

            //foreach (var sitePageModel in model.Pages)
            //{
            //    dbSite.Pages.Add(sitePagesBusinessLogic.GetById(sitePageModel.Id));
            //}
            return dbSite; ;
        }

        public static SiteModel ConvertToSiteModel(this ClientSite x)
        {
            var model = new SiteModel
            {
                Id = x.Id,
                Name = x.Name,
                Company = x.Owner == null ? String.Empty : x.Owner.Name,
                PagesCount = x.Pages == null ? 0 : x.Pages.Count,
                //Domains = x.Domains == null ? String.Empty : x.Domains.Aggregate((a, b) => a + ";" + b),
                Url = x.Url,
                CompanyId = x.Owner == null ? Guid.Empty : x.Owner.Id,
            };
            if (x.Domains != null)
            {
                foreach (var domain in x.Domains)
                {
                    model.Domains += domain + "; ";
                }
                model.Domains.Remove(model.Domains.Length - 1);
            }
            return model;
        }

        public static void AddRangeIfNoExist(this ICollection<string> source, IEnumerable<string> newItems)
        {
            if (source == null)
            {
                source = new List<string>();
            }
            foreach (var newItem in newItems)
            {
                if (!source.Contains(newItem.Trim()))
                {
                   source.Add(newItem.Trim()); 
                }
            }
        }

    }
}