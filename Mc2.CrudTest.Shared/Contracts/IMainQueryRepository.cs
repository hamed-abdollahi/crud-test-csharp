using Mc2.CrudTest.Shared.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;


namespace Mc2.CrudTest.Shared.Contracts
{
    public interface IMainQueryRepository<TEntity> where TEntity : MainEntity
    {
        MainDbContext DAO { get; set; }
        TEntity Get(Expression<Func<TEntity, bool>>? expression = null);
        IEnumerable<TEntity> GetAll();
    }
}
