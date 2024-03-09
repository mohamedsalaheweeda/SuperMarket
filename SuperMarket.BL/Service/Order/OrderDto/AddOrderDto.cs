using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.BL
{
    public class AddOrderDto
    {
        public bool OrderStatus { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public double List_Price { get; set; }
        public int CustomerId { get; set; }
        public int PaymentId { get; set; }
        public int UserId { get; set; }

    }
}
