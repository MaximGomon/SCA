using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.BussinesLogic
{
    public class DictionaryBusinessLogic<TEntity> : BaseBusinessLogic<IDictionaryRepository<TEntity>, TEntity>, 
        IDictionaryBusinessLogic<TEntity> where TEntity : DictionaryEntity
    {
        public TEntity GetByCode(int code)
        {
            return Repository.GetByCode(code);
        }

        public DictionaryBusinessLogic(IDictionaryRepository<TEntity> repository) : base(repository)
        {
        }
    }
}