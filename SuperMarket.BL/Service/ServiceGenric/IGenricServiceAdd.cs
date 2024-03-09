using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.BL
{
    public interface IGenricServiceAdd<TEntity> where TEntity : class
    {
         Task Insert (TEntity entity);
         Task update (int id, TEntity entity);
    }
}
