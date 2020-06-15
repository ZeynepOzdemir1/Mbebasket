using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mbe.Models
{
    public class CustomerEntity 
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerMail { get; set; }

    }
}
