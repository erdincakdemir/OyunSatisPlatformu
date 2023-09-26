using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DataAccessLayer
{
    public interface IRepository<TEntity> 
        where TEntity : class,IBaseEntity,new()
    {
        bool Add(TEntity entity);
        bool Delete(TEntity entity);
        TEntity Get(int id);
        IEnumerable<TEntity> Get();
        bool Update(TEntity entity);
    }
}
