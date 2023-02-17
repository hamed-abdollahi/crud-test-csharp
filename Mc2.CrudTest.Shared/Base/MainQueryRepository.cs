using Mc2.CrudTest.Shared.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Mc2.CrudTest.Shared.Base
{
    public abstract class MainQueryRepository<TEntity> : IMainQueryRepository<TEntity> where TEntity : MainEntity
    {
        public MainDbContext DAO { get; set; }

        protected MainQueryRepository(MainDbContext dao)
        {
            this.DAO = dao;
            this.DAO.Database.EnsureCreated();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expression = null)
        {
            if (expression != null)
                return DAO.Set<TEntity>().Where(expression).FirstOrDefault();
            else return null;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return DAO.Set<TEntity>().ToList();
        }
    }
}