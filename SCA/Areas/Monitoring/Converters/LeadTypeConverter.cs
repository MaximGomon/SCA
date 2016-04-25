using System.Linq;
using SCA.Areas.Monitoring.Models;
using SCA.Domain;

namespace SCA.Areas.Monitoring.Converters
{
    public static class LeadTypeConverter
    {
        public static LeadTypeModel ConvertToModel(this LeadType source)
        {
            var model = new LeadTypeModel
            {
                Id = source.Id,
                Name = source.Name,
                //Tags = source.LeadTags.Aggregate((a, b) => a.Name + ", " + b.Name)
            };
            foreach (var leadTag in source.LeadTags)
            {
                model.Tags += leadTag.Name + ", ";
            }
            model.Tags.Remove(model.Tags.Length - 2);
            return model;
        }
    }
}