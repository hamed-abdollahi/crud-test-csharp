using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Service.Contract.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Test
{
    public class CustomerQueryServiceFake : ICustomerQueryService
    {
        List<CustomerEntity> _customers;
        public CustomerQueryServiceFake()
        {
            _customers = new List<CustomerEntity>()
            {
                new CustomerEntity() { Id = 1,
                    FirstName = "AA", LastName="BB", Email ="df" , BankAccountNumber ="e" ,
                    DateOfBirth = DateTime.Now , PhoneNumber = "dfd" },
                new CustomerEntity() { Id = 2,
                    FirstName = "AA", LastName="BB", Email ="df" , BankAccountNumber ="e" ,
                    DateOfBirth = DateTime.Now , PhoneNumber = "dfd" },
                new CustomerEntity() { Id = 3,
                    FirstName = "AA", LastName="BB", Email ="df" , BankAccountNumber ="e" ,
                    DateOfBirth = DateTime.Now , PhoneNumber = "dfd" }
            };
        }
        public CustomerEntity GetCustomer(int id)
        {
            return _customers.Where(a => a.Id == id)
            .FirstOrDefault();
        }

        public IEnumerable<CustomerEntity> GetCustomers()
        {
            return _customers;
        }
    }
}
