using SuperMarket.DL;
using SuperMarket.DL;
using SuperMarket.DL;
using SuperMarket.Model.Data;

namespace SuperMarket.DL
{
    public class CategoreyRepo : GenricRepository<Categorey>, ICategoreyRepo
    {
        public CategoreyRepo(AppDbContext context) : base(context) { }
    }

}
