using Grocery.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Core.DTOs
{
    public class Register
    {
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string AgentName { get; set; }
        public string Password { get; set; }
        public List<ProductDTO> Products { get; set; }
    }
}
