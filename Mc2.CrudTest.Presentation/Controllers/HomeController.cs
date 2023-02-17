using Mc2.CrudTest.Domain.Entities;
using Mc2.CrudTest.Presentation.Models;
using Mc2.CrudTest.WebApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace Mc2.CrudTest.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // get list of customers
        public IActionResult Index()
        {
            List<CustomerEntity> result = WebApi.WebApi.CallMethod<List<CustomerEntity>>("/api/Customer/GetCustomers", null, "", HttpMethod.Get);
            return View(result);
        }

        public IActionResult CustomerEdit(int? id)
        {
            if (id is null)
            {
                return View(new CustomerEntity());
            }
            CustomerEntity result = WebApi.WebApi.CallMethod<CustomerEntity>("/api/Customer/GetCustomer/" + id, null, "", HttpMethod.Get);
            return View(result);
        }

        [HttpPost]
        public IActionResult CustomerEdit(CustomerEntity customer)
        {
            if (customer.Id is null)
            {
                var res = WebApi.WebApi.CallMethod<CustomerEntity>("/api/Customer/AddCustomer", customer, "", HttpMethod.Post);

            }
            else
                WebApi.WebApi.CallMethod<CustomerEntity>("/api/Customer/UpdateCustomer", customer, "", HttpMethod.Put);
            return RedirectToAction("index");
        }

        public IActionResult CustomerDelete(int id)
        {
            WebApi.WebApi.CallMethod<bool>("/api/Customer/DeleteCustomer/" + id, null, "", HttpMethod.Delete);
            return RedirectToAction("index");
        }

    }
}
