using CrecheApp.Domain.Interface.Repository;
using CrecheApp.Infrastructure.Context;
using System;
using System.Linq;

namespace CrecheApp.Infrastructure.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly CrecheAppContext _crecheAppContext;

        public BaseRepository( CrecheAppContext crecheAppContext)
        {
            _crecheAppContext = crecheAppContext;
        }

        public void Add(TEntity entity)
        {
            _crecheAppContext.Set<TEntity>().Add(entity);
            _crecheAppContext.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _crecheAppContext.Set<TEntity>().Remove(entity);
            _crecheAppContext.SaveChanges();
        }

        public void Dispose()
        {
            _crecheAppContext.Dispose();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _crecheAppContext.Set<TEntity>();
        }

        public TEntity GetById(int id)
        {
            return _crecheAppContext.Set<TEntity>().Find(id);
        }

        public TEntity GetByGlobalId(Guid globalId)
        {
            return _crecheAppContext.Set<TEntity>().Find(globalId);
        }

        public void Update(TEntity entity)
        {
            _crecheAppContext.Set<TEntity>().Update(entity);
            _crecheAppContext.SaveChanges();
        }
    }
}
