

using Mapster;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Repository.Contract.Command;
using Mc2.CrudTest.Service.Contract.Command;
using Mc2.CrudTest.Service.DTO;
using Mc2.CrudTest.Shared.Base;
using System.Collections.Generic;

namespace Mc2.CrudTest.Service.Query
{
    public class CustomerQueryService : MainService, ICustomerQueryService
    {
        private readonly ICustomerQueryRepository customerRepository;
        
        public CustomerQueryService(ICustomerQueryRepository customerRepository) :base(customerRepository.DAO)
        {
            this.customerRepository = customerRepository;
        }

        public CustomerEntity GetCustomer(int id)
        {
            var result = customerRepository.Get(a => a.Id == id);
            return result;
        }

        public IEnumerable<CustomerEntity> GetCustomers()
        {
            var allCustomers = customerRepository.GetAll();
            if (allCustomers is null)
            {
                return null ;
            }
            return allCustomers;
        }

        
    }
}