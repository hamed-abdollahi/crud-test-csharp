using Mapster;
using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Service.Contract.Command;
using Mc2.CrudTest.Service.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerCommandService _customerCommandService;
        private readonly ICustomerQueryService _customerQueryService;


        private readonly ILogger<CustomerController> _logger;

        public CustomerController(
            ICustomerCommandService customerCommandService ,
            ICustomerQueryService customerQueryService)
        {
            _customerCommandService = customerCommandService;
            _customerQueryService = customerQueryService;
        }

        [HttpPost("AddCustomer")]
        public ActionResult<CustomerEntity> AddCustomer([FromBody] CustomerDTO customer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var result = _customerCommandService.AddCustomer(customer);
                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpDelete("DeleteCustomer/{id}")]
        public ActionResult DeleteCustomer(int id)
        {
            try
            {
                Boolean result = _customerCommandService.DeleteCustomer(id);
                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpGet("GetCustomer/{id}")]
        public IActionResult GetCustomer(int id)
        {
            try
            { 
                var result = _customerQueryService.GetCustomer(id);
                if (result is null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpGet("GetCustomers")]
        public IActionResult GetCustomers()
        {
            try
            {
                
                var result = _customerQueryService.GetCustomers();
                if (result.Count() == 0)
                {
                    return NotFound();
                }
                return Ok(result.ToList());
            }
            catch
            {
                return StatusCode(500);
            }
        }
        [HttpPut("UpdateCustomer")]
        public ActionResult UpdateCustomer([FromBody] CustomerEntity customer)
        {
            try
            {
                var result =  _customerCommandService.UpdateCustomer(customer);
                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }

    }
}
