

using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Service.DTO;
using System.Collections.Generic;

namespace Mc2.CrudTest.Service.Contract.Command
{
    public interface ICustomerQueryService 
    {
        CustomerEntity GetCustomer(int id);
        IEnumerable<CustomerEntity> GetCustomers();
    }
}
