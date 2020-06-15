using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mbe.Models;
using mbe.Models.Customer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mbe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository customerProvider;
        public CustomerController(ICustomerRepository customerProvider)
        {
            this.customerProvider = customerProvider;
        }


        // GET: api/Student
        
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
          return Ok(customerProvider.Get(id));
        }

        [HttpPost("save")]
        public IActionResult Create(CustomerEntity entity)
        {
            customerProvider.Create(entity);
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult Update(CustomerEntity entity)
        {
            customerProvider.Update(entity);
            return Ok();
        }


        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            customerProvider.Delete(id);
        }





    }
}