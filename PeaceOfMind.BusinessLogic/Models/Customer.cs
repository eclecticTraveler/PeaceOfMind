using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PeaceOfMind.Service.Models
{
    public class Customer : ICustomer
    {
        public long CustomerID { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
    }
}
