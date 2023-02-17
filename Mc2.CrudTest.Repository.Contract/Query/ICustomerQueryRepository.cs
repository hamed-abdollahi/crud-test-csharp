using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Shared.Contracts;

namespace Mc2.CrudTest.Repository.Contract.Command
{
    public interface ICustomerQueryRepository : IMainQueryRepository<CustomerEntity>
    {

    }
}
