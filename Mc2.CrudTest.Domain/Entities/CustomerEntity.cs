using Mc2.CrudTest.Shared.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mc2.CrudTest.Domain.Entities
{
    [Table("tblCustomer")]
    public class CustomerEntity : MainEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long? Id { get; set; }
        [Required(ErrorMessage ="This field is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "This field is required")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Please Enter only Numbers")]
        [StringLength(8, ErrorMessage = "The BankAccountNo must be 8 numbers only.", MinimumLength = 8)]
        public string BankAccountNumber { get; set; }
    }
}
