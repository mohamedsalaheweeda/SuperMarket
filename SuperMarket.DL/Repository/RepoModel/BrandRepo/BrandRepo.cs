using SuperMarket.DL;
using SuperMarket.DL;
using SuperMarket.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.DL
{
    public class BrandRepo : GenricRepository<Brand>, IBrandRepo
    {
        public BrandRepo(AppDbContext context) : base(context) { }
    }

}
