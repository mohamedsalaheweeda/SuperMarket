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
    public class CustomerRepo : GenricRepository<Customer>, ICustomerRepo
    {
        public CustomerRepo(AppDbContext context) : base(context) { }
    }
}
