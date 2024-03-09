using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.BL
{
    public class ReadCustomerDto
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Mid_Name { get; set; }
        public string Last_Name { get; set; }
        public string? Country { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? Email { get; set; }
        public string Phone { get; set; }
        public int UserId { get; set; }

    }
}
