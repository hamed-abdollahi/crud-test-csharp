

using Mapster;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Repository.Contract.Command;
using Mc2.CrudTest.Service.Contract.Command;
using Mc2.CrudTest.Service.DTO;
using Mc2.CrudTest.Shared.Base;

namespace Mc2.CrudTest.Service.Command
{
    public class CustomerCommandService : MainService, ICustomerCommandService
    {
        private readonly ICustomerCommandRepository customerRepository;
        
        public CustomerCommandService(ICustomerCommandRepository customerRepository) :base(customerRepository.DAO)
        {
            this.customerRepository = customerRepository;
        }
        public CustomerEntity AddCustomer(CustomerDTO entity)
        {
            var customer = entity.Adapt<CustomerEntity>();
            var result = customerRepository.Add(customer);
            return result;
        }
        public bool DeleteCustomer(int id)
        {
            return customerRepository.Delete(new CustomerEntity() { Id = id });
        }

        public CustomerEntity UpdateCustomer(CustomerEntity entity)
        {
            return customerRepository.Edit(entity);
        }
    }
}