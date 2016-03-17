using System;
using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.BussinesLogic
{
    public abstract class BaseBusinessLogic<TRepository, TEntity>
    where TEntity : IdentityEntity
    where TRepository : class, ICRUDRepository<TEntity>
    {
        protected BaseBusinessLogic(TRepository repository)
        {
            if (repository == null)
            {
                throw new ArgumentNullException("repository");
            }

            Repository = repository;
        }

        protected TRepository Repository { get; private set; }
    }
}