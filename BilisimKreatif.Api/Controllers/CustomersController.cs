using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BilisimKreatif.Model;
using BilisimKreatif.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BilisimKreatif.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService customerService;
        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await customerService.GetAllAsync();
        }

        [HttpPost]
        public async Task Post([FromBody] Customer customer)
        {
            await customerService.InsertAsync(customer);
        }
    }
}