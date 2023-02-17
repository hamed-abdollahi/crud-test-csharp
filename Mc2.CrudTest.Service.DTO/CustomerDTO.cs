using Mc2.CrudTest.Shared.Base;
using System;

namespace Mc2.CrudTest.Service.DTO
{
    public class CustomerDTO : MainDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BankAccountNumber { get; set; }
    }
}
