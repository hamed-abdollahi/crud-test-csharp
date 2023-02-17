using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Repository.Contract.Command;
using Mc2.CrudTest.Repository.DAO;
using Mc2.CrudTest.Shared.Base;


namespace Mc2.CrudTest.Repository.Command
{
    public class CustomerCommandRepository : MainCommandRepository<CustomerEntity> , ICustomerCommandRepository
    {
        public CustomerCommandRepository(ApplicationContext dao) : base(dao)
        {

        }
    }
}
