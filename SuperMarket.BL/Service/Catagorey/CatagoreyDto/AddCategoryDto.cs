using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.BL
{
    public class AddCategoryDto
    {
        public string Name { get; set; }
        public string? Image { get; set; }
        public int BrandId { get; set; }
        public int UserId { get; set; }
    }
}
