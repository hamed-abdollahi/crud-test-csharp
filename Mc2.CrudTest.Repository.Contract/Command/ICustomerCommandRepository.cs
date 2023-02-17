using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Shared.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Repository.Contract.Command
{
    public interface ICustomerCommandRepository : IMainCommandRepository<CustomerEntity>
    {

    }
}
