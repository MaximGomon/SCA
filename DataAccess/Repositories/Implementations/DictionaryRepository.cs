using System.Linq;
using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.DataAccess.Repositories.Implementations
{
    public class DictionaryRepository<TDictionaryTEntity> : CrudRepository<TDictionaryTEntity> , IDictionaryRepository<TDictionaryTEntity>
        where TDictionaryTEntity : DictionaryEntity
    {
        public TDictionaryTEntity GetByCode(int code)
        {
            return DbContext.Set<TDictionaryTEntity>().FirstOrDefault(x => x.Code == code);
        }
    }
}