using System.Linq;
using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.DataAccess.Repositories.Implementations
{
    public class TagRepository : CrudRepository<Tag>, ITagRepository
    {
        public TagRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            
        }
        public Tag GetByName(string name)
        {
            return GetAllEntities().Where(x => x.Name == name).FirstOrDefault();
        }
    }
}