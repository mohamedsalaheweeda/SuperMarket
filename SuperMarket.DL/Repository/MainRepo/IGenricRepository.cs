using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.DL
{
    public interface IGenricRepository<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task Insert(TEntity entity);
        Task update( TEntity entity);
        Task Delete(int id);
        Task SaveChangeAsync();
    }
}
