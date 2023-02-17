using Mc2.CrudTest.Application.Controllers;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Service.Contract.Command;
using Mc2.CrudTest.Service.DTO;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using Xunit;

namespace Mc2.CrudTest.Test
{
    public class CustomerControllerTest
    {
        
        private readonly CustomerController _controller;
        private readonly ICustomerQueryService _queryService;
        private readonly ICustomerCommandService _commandService;
        public CustomerControllerTest()
        {
            _queryService = new CustomerQueryServiceFake();
            _commandService = new CustomerCommandServiceFake();
            _controller = new CustomerController(_commandService,_queryService);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = _controller.GetCustomers();
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
        [Fact]
        public void Get_WhenCalled_ReturnsAllItems()
        {
            // Act
            var okResult = _controller.GetCustomers() as OkObjectResult;
            // Assert
            var items = Assert.IsType<List<CustomerEntity>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }

        [Fact]
        public void GetById_UnknownIdPassed_ReturnsNotFoundResult()
        {
            // Act
            var notFoundResult = _controller.GetCustomer(9766);
            // Assert
            Assert.IsType<Microsoft.AspNetCore.Mvc.NotFoundResult>(notFoundResult);
        }
        [Fact]
        public void GetById_ExistingIdPassed_ReturnsOkResult()
        {
            // Arrange
            
            // Act
            var okResult = _controller.GetCustomer(3);
            // Assert
            Assert.IsType<OkObjectResult>(okResult as OkObjectResult);
        }
        [Fact]
        public void GetById_ExistingIdPassed_ReturnsRightItem()
        {
            // Arrange
            
            // Act
            var okResult = _controller.GetCustomer(3) as OkObjectResult;
            // Assert
            Assert.IsType<CustomerEntity>(okResult.Value);
            Assert.Equal(3, (okResult.Value as CustomerEntity).Id);
        }

        [Fact]
        public void Add_InvalidObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            var customer = new CustomerDTO()
            {

                FirstName = "AA",
                LastName = "BB",
                Email = "df",
                BankAccountNumber = "e",
                DateOfBirth = DateTime.Now,
                PhoneNumber = "dfd"
            };
            _controller.ModelState.AddModelError("Name", "Required");
            // Act
            var badResponse = _controller.AddCustomer(customer);
            // Assert
            Assert.IsType<BadRequestObjectResult>(badResponse);
        }
        [Fact]
        public void Add_ValidObjectPassed_ReturnsCreatedResponse()
        {
            // Arrange
            var customer = new CustomerDTO()
            {

                FirstName = "AA",
                LastName = "BB",
                Email = "df",
                BankAccountNumber = "e",
                DateOfBirth = DateTime.Now,
                PhoneNumber = "dfd"
            };
            // Act
            var createdResponse = _controller.AddCustomer(customer);
            // Assert
            Assert.IsType<CreatedAtActionResult>(createdResponse);
        }


        [Fact]
        public void Remove_NotExistingIdPassed_ReturnsNotFoundResponse()
        {
            // Arrange
            var existingId = 77;
            // Act
            var badResponse = _controller.DeleteCustomer(existingId);
            // Assert
            Assert.IsType<Microsoft.AspNetCore.Mvc.NotFoundResult>(badResponse);
        }
        [Fact]
        public void Remove_ExistingIdPassed_ReturnsNoContentResult()
        {
            // Arrange
            var existingId = 3;
            // Act
            var noContentResponse = _controller.DeleteCustomer(existingId);
            // Assert
            Assert.IsType<NoContentResult>(noContentResponse);
        }
        
    }
}
