using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mbe.Models.BasketResult
{
    public interface IBasketResultRepositorty : IRepository<BasketResultEntity>
    {
        List<BasketResultEntity> GetCustomerBasket(int id);
    }
}
