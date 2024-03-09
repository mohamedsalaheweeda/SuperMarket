using SuperMarket.DL;
using SuperMarket;
using SuperMarket.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.DL
{
    public class ProductWithOrderRepo : GenricRepository<ProductWithOrder>, IProductWithOrderRepo
    {
        public ProductWithOrderRepo(AppDbContext context) : base(context) { }
    }
}
