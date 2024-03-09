using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.BL
{
    public class ReadProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Model_Year { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
        public double Quantity { get; set; }
        public int BrandId { get; set; }
        public int CategoreyId { get; set; }
        public int UserId { get; set; }

    }
}
