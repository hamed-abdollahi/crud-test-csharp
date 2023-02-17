using Mc2.CrudTest.Shared.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Shared.Contracts
{
    public interface IMainCommandRepository<TEntity> where TEntity : MainEntity
    {
        MainDbContext DAO { get; set; }
        TEntity Add(TEntity entity);
        IEnumerable<TEntity> AddAll(IEnumerable<TEntity> entities);
        TEntity Edit(TEntity entity);
        bool Delete(TEntity entity);
        
    }
}
