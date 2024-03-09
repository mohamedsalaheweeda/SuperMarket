using Microsoft.EntityFrameworkCore;
using SuperMarket.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.DL
{
    public class GenricRepository<TEntity> : IGenricRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;

        public GenricRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _context.Set<TEntity>().ToListAsync();
        public async Task<TEntity> GetByIdAsync(int id)
        {

            var Get = await _context.Set<TEntity>().FindAsync(id);
            if (Get == null) return null;
            return Get;
        }
        public async Task Insert(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);      
        }
        public async Task update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
           
        }
        public async Task Delete (int id)
        {
            var delet = await _context.Set<TEntity>().FindAsync(id);
              _context.Set<TEntity>().Remove(delet);
        }
        public async Task SaveChangeAsync() => await _context.SaveChangesAsync();

       
    }
}
