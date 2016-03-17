using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using SCA.Domain;

namespace SCA.DataAccess.Repositories.Interfaces
{
    public interface ICRUDRepository<TEntity> where TEntity : IdentityEntity
    {
        void Add(TEntity entity);
        TEntity GetById(Guid id);
        IEnumerable<TEntity> Add(IEnumerable<TEntity> range);
        void Delete(Guid id);
        void Delete(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> filter = null);
        void Update(TEntity entity);
        void UpdateAny(TEntity entity);
        void SaveChanges();
    }
}
