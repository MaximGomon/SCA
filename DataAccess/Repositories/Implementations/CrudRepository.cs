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

        public ScaDbContext DbContext = DbContextSingle.Instance;


        public void Add(TEntity entity)
        {
            DbContext.Set<TEntity>().Add(entity);
            SaveChanges();
        }

        public TEntity GetById(Guid id)
        {
            return DbContext.Set<TEntity>().Find(id);
        }

        public void Add(IEnumerable<TEntity> range)
        {
            DbContext.Set<TEntity>().AddRange(range);
            SaveChanges();
        }

        public void Delete(Guid id)
        {
            //DbContext.
        }

        public void Delete(TEntity entity)
        {
            DbContext.Set<TEntity>().Remove(entity);
            SaveChanges();
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
            //var type = typeof (TEntity);
            return DbContext.Set<TEntity>().Select(x => x);
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }
    }
}
