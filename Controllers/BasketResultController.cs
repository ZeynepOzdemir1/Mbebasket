using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mbe.Models.BasketResult;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mbe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketResultController : ControllerBase
    {

        private readonly IBasketResultRepositorty basketResultProvider;
        public BasketResultController(IBasketResultRepositorty basketResultProvider)
        {
            this.basketResultProvider = basketResultProvider;
        }

        [HttpGet("basket/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(basketResultProvider.Get(id));
        }

        [HttpGet("customer/{id}")]
        public IActionResult GetByCustomerId(int id)
        {
            return Ok(basketResultProvider.GetCustomerBasket(id));
        }


        [HttpPost("save")]
        public IActionResult Create(BasketResultEntity entity)
        {
            basketResultProvider.Create(entity);
            return Ok();
        }

        [HttpPut("update")]
        public IActionResult Update(BasketResultEntity entity)
        {
            basketResultProvider.Update(entity);
            return Ok();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            basketResultProvider.Delete(id);
        }


    }
}