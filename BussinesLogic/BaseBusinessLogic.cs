using System;
using System.Linq;
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

        protected TEntity GetById(Guid id)
        {
            return Repository.GetById(id);
        }

        protected void Update(TEntity entity)
        {
            Repository.Update(entity);
        }

        protected void Add(TEntity entity)
        {
            Repository.Add(entity);
        }

        protected TRepository Repository { get; private set; }

        public IQueryable<TEntity> GetAllEntities()
        {
            return Repository.GetAllEntities();
        } 
    }
}