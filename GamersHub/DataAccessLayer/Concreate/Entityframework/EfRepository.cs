using Core.DataAccessLayer;
using Core.Entity;
using DataAccessLayer.DBContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Concreate.Entityframework
{
    public class EfRepository<TEntity> : IRepository<TEntity>
        where TEntity : class, IBaseEntity, new()
    {
        readonly GamersHubContext db = new GamersHubContext();
        public bool Add(TEntity entity)
        {
            db.Add(entity);

            //int result = db.SaveChanges();
            //if (result>0)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            return db.SaveChanges() > 0 ? true : false;
        }

        public bool Delete(TEntity entity)
        {
            db.Update(entity);
            return db.SaveChanges() > 0 ? true : false;
        }

        public TEntity Get(int id)
        {
           return db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> Get()
        {
            return db.Set<TEntity>();
        }

        public bool Update(TEntity entity)
        {
            db.Update(entity);
            return db.SaveChanges() > 0 ? true : false;
        }
    }
}
