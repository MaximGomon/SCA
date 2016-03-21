using System.Linq;
using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.DataAccess.Repositories.Implementations
{
    public class TagRepository : CrudRepository<Tag>, ITagRepository
    {
        public Tag GetByName(string name)
        {
            return DbContext.Tags.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}