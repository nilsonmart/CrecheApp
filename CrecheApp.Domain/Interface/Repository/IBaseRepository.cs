using System;
using System.Collections.Generic;
using System.Linq;

namespace CrecheApp.Domain.Interface.Repository
{
    public interface IBaseRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity entity);
        TEntity GetById(int id);
        TEntity GetByGlobalId(Guid globalId);
        IQueryable<TEntity> GetAll();
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
