using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.BL
{
    public class ReadProductWithOrderDto
    {
        public int Id { get; set; }
        public double Discount_AllTotal { get; set; }
        public double Quantity { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int UserId { get; set; }

    }
}
