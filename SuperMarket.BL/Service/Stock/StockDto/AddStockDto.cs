﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.BL
{
    public class AddStockDto
    {
      
        public string Name { get; set; }
        public double Quantity { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }

    }
}
