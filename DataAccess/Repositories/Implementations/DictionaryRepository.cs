using System.Linq;
using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.DataAccess.Repositories.Implementations
{
    public class DictionaryRepository<TDictionaryTEntity> : CrudRepository<TDictionaryTEntity> , IDictionaryRepository<TDictionaryTEntity>
        where TDictionaryTEntity : DictionaryEntity
    {
        public DictionaryRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
            
        }
        public TDictionaryTEntity GetByCode(int code)
        {
            return GetAllEntities().FirstOrDefault(x => x.Code == code);
        }
    }
}