using System;
using System.Linq;

namespace SCA.BussinesLogic
{
    public interface IBaseBusinessLogic<TEntity>
    {
        TEntity GetById(Guid id);

        void Update(TEntity entity);

        void Add(TEntity entity);

        IQueryable<TEntity> GetAllEntities();
    }
}