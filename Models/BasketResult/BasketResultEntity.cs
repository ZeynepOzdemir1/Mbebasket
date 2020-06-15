using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mbe.Models.BasketResult
{
    public class BasketResultEntity
    {
        public int BasketId { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public int Quantity { get; set; }
    }
}
