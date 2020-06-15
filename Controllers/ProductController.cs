using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mbe.Models;
using mbe.Models.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mbe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productProvider;
        public ProductController(IProductRepository productProvider)
        {
            this.productProvider = productProvider;
        }


        // GET: api/Student

        [HttpGet("{id}", Name = "GetProduct")]
        public IActionResult Get(int id)
        {
            return Ok(productProvider.Get(id));
        }

        [HttpGet("save-test")]
        public IActionResult Test()
        {
            return Ok();
        }

        [HttpPost("save")]
        public IActionResult Create(ProductEntity entity)
        {
            productProvider.Create(entity);
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult Update(ProductEntity entity)
        {
            productProvider.Update(entity);
            return Ok();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            productProvider.Delete(id);
        }
    }
}