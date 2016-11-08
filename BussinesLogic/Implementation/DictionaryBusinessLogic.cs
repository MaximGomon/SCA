using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.BussinesLogic
{
    public class DictionaryBusinessLogic<TEntity> : BaseBusinessLogic<IDictionaryRepository<TEntity>, TEntity>, 
        IDictionaryBusinessLogic<TEntity> where TEntity : DictionaryEntity
    {
        private readonly IDictionaryRepository<TEntity> _repository;
        public TEntity GetByCode(int code)
        {
            return _repository.GetByCode(code);
        }

        public DictionaryBusinessLogic(IDictionaryRepository<TEntity> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}