﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using SCA.DataAccess.Repositories.Interfaces;
using SCA.Domain;

namespace SCA.DataAccess.Repositories.Implementations
{
    public class CrudRepository<TEntity> : ICRUDRepository<TEntity>, IDisposable
        where TEntity : IdentityEntity
    {

        private ScaDbContext _context;

        public CrudRepository (IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        protected IDatabaseFactory DatabaseFactory
        {
            get; private set;
        }

        protected ScaDbContext DbContext
        {
            get { return _context ?? (_context = DatabaseFactory.Get()); }
        }

        public virtual void Add(TEntity entity)
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
            Delete(GetById(id));
            SaveChanges();
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
            //if (DbContext.ChangeTracker.Entries<TEntity>().All(e => e.Entity != entity))
            //{
            //    DbContext.Set<TEntity>().Attach(entity);
            //}
            //DbContext.Entry(entity).State = EntityState.Modified;
            DbContext.Set<TEntity>().AddOrUpdate<TEntity>(entity);
            SaveChanges();
        }

        public void UpdateAny(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAllEntities()
        {
            var type = typeof (TEntity);
            return DbContext.Set<TEntity>().Select(x => x);
        }

        public void SaveChanges()
        {
            DbContext.SaveChanges();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
