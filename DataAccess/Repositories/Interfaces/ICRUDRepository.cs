using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SCA.Domain;

namespace DataAccess.Repositories.Interfaces
{
    public interface ICRUDRepository<TEntity> where TEntity : IdentityEntity
    {
        TEntity Add(TEntity entity);
        IEnumerable<TEntity> Add(IEnumerable<TEntity> range);
        void Delete(Guid id);
        void Delete(TEntity entity);
        void Delete(Expression<Func<TEntity, bool>> filter = null);
        void Update(TEntity entity);
        void UpdateAny(TEntity entity);
        void SaveChanges();
    }
}
