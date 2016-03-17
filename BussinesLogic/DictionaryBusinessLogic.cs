using SCA.DataAccess.Repositories.Implementations;
using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.BussinesLogic
{
    public class DictionaryBusinessLogic<TEntity> : BaseBusinessLogic<DictionaryRepository<TEntity>, TEntity>, 
        IDictionaryRepository<TEntity> where TEntity : DictionaryEntity
    {
        private readonly DictionaryRepository<TEntity> _repository;
        public TEntity GetByCode(int code)
        {
            return _repository.GetByCode(code);
        }

        public DictionaryBusinessLogic(DictionaryRepository<TEntity> repository) : base(repository)
        {
            _repository = repository;
        }
    }
}