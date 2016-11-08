using SCA.Domain;

namespace SCA.BussinesLogic
{
    public interface IDictionaryBusinessLogic<TEntity> : IBaseBusinessLogic<TEntity>
        where TEntity : DictionaryEntity
    {
        TEntity GetByCode(int code);
    }
}