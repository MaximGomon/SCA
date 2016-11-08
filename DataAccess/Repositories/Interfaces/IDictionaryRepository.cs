using SCA.Domain;

namespace SCA.DataAccess.Repositories.Interfaces
{
    public interface IDictionaryRepository<TDictionaryTEntity> : ICRUDRepository<TDictionaryTEntity>
        where TDictionaryTEntity : DictionaryEntity
    {
        TDictionaryTEntity GetByCode(int code);
    }
}