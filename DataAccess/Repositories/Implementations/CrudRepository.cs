using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.DataAccess.Repositories.Implementations
{
    public class CrudRepository<TEntity> : ICRUDRepository<TEntity>
        where TEntity : IdentityEntity
    {

        public ScaDbContext DbContext = new ScaDbContext();
        
        public void Add(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
            DbContext.SaveChanges();
        }

        public TEntity GetById(Guid id)
        {
            return DbContext.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> Add(IEnumerable<TEntity> range)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<TEntity, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateAny(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAllEntities()
        {
            return DbContext.Set<TEntity>().Select(x => x);
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
