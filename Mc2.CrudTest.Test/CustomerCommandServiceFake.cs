using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Service.Contract.Command;
using Mc2.CrudTest.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Test
{
    public class CustomerCommandServiceFake : ICustomerCommandService
    {
        List<CustomerEntity> _customers;
        public CustomerCommandServiceFake()
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

        public CustomerEntity AddCustomer(CustomerDTO entity)
        {
            var customer = new CustomerEntity()
            {
                Id = 5,
                FirstName = "AA",
                LastName = "BB",
                Email = "df",
                BankAccountNumber = "e",
                DateOfBirth = DateTime.Now,
                PhoneNumber = "dfd"
            };

            _customers.Add(customer);
            return customer;
        }

        public bool DeleteCustomer(int id)
        {
            throw new NotImplementedException();
        }

        public CustomerEntity UpdateCustomer(CustomerEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
