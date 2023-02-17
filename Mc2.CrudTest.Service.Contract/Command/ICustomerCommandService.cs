

using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Service.DTO;
using System.Collections.Generic;

namespace Mc2.CrudTest.Service.Contract.Command
{
    public interface ICustomerCommandService 
    {
        CustomerEntity AddCustomer(CustomerDTO entity);
        CustomerEntity UpdateCustomer(CustomerEntity entity);
        bool DeleteCustomer(int id);
    }
}
