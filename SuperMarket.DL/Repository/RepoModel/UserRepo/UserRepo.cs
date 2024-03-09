using SuperMarket.DL;
using SuperMarket.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.DL
{
    public class UserRepo : GenricRepository<User>, IUserRepo
    {
        public UserRepo(AppDbContext context) : base(context) { }

    }
}
