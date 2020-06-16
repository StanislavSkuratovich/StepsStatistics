using System;
using System.Collections.Generic;
using System.Text;

namespace JoggingTrackerCore.Models.DAL
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
        //TEntity Get(string name);
        IEnumerable<TEntity> GetAll();
        void Add(TEntity entity);
        void Add(List<TEntity>entities);
        void Remove(TEntity entity);
    }
}
