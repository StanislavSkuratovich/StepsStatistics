using JoggingTrackerCore.Models.Persistance;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace JoggingTrackerCore.Models.DAL.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext dbContext)// todo di or const field
        {
            Context = dbContext;
        }

        public TEntity Get(int id)
        {
            //throw new NotImplementedException();
            return Context.Set<TEntity>().Find(id);
        }

        //public TEntity Get(string name)
        //{
        //    var result = Context.Set<TEntity>().Find(name);
        //    return result;

        //}

        public IEnumerable<TEntity> GetAll()//instead of using IQueryable (there should be just a collection) 
        {
            return Context.Set<TEntity>().ToList();
        }

        public virtual void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public virtual void Add(List<TEntity> entities)
        {
            foreach (var item in entities)
            {
                Context.Set<TEntity>().Add(item);
            }            
        }

        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }


    }
}
