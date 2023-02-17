using Mc2.CrudTest.Shared.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Mc2.CrudTest.Shared.Base
{
    public abstract class MainCommandRepository<TEntity> : IMainCommandRepository<TEntity> where TEntity : MainEntity
    {
        public MainDbContext DAO { get; set; }

        protected MainCommandRepository(MainDbContext dao)
        {
            this.DAO = dao;
            this.DAO.Database.EnsureCreated();
        }
        public virtual TEntity Add(TEntity entity)
        {
            DAO.Set<TEntity>().Add(entity);
            if (DAO.SaveChanges() > 0)
                return entity;
            else throw new Exception("Add is missing");
        }
        public virtual IEnumerable<TEntity> AddAll(IEnumerable<TEntity> entities)
        {
          var addEntities = entities as TEntity[] ?? entities.ToArray();
            DAO.Set<TEntity>().AddRange(addEntities);
            if (DAO.SaveChanges() > 0)
                return addEntities;
            else throw new Exception("AddAll is missing");
        }
        public virtual TEntity Edit(TEntity entity)
        {
           DAO.Entry(entity).State = EntityState.Modified;
            if (DAO.SaveChanges() <= 0)
                throw new Exception("Edit is missing");
            else
                return entity;
        }
        public virtual bool Delete(TEntity entity)
        {
            DAO.Set<TEntity>().Remove(entity);
            if (DAO.SaveChanges() <= 0)
                return false;
            return true;
        }
        

    }
}