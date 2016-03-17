using SCA.Domain;

namespace SCA.DataAccess.Repositories.Interfaces
{
    public interface IDictionaryRepository<DictionaryTEntity>
        where DictionaryTEntity : DictionaryEntity
    {
        DictionaryTEntity GetByCode(int code);
    }
}