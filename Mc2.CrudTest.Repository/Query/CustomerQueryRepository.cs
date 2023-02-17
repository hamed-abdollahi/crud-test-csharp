using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Repository.Contract.Command;
using Mc2.CrudTest.Repository.DAO;
using Mc2.CrudTest.Shared.Base;


namespace Mc2.CrudTest.Repository.Query
{
    public class CustomerQueryRepository : MainQueryRepository<CustomerEntity> , ICustomerQueryRepository
    {
        public CustomerQueryRepository(ApplicationContext dao) : base(dao)
        {

        }
    }
}
