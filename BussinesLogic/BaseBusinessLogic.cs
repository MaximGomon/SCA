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

        public TEntity GetById(Guid id)
        {
            return Repository.GetById(id);
        }

        public void Update(TEntity entity)
        {
            Repository.Update(entity);
        }

        public void Add(TEntity entity)
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