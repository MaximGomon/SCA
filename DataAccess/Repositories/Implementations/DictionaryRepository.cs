using System.Linq;
using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.DataAccess.Repositories.Implementations
{
    public class DictionaryRepository<DictionaryTEntity> : CrudRepository<DictionaryTEntity> , IDictionaryRepository<DictionaryTEntity>
        where DictionaryTEntity : DictionaryEntity
    {
        public DictionaryTEntity GetByCode(int code)
        {
            return DbContext.Set<DictionaryTEntity>().FirstOrDefault(x => x.Code == code);
        }
    }
}