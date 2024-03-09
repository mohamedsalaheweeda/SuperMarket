using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.BL
{
    public class AddPaymentDto
    {
        public double Type_Amount { get; set; }
        public double Amount { get; set; }
        public int CustomerId { get; set; }
        public int UserId { get; set; }

    }
}
