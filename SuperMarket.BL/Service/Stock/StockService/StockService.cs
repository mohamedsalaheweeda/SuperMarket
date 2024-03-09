using AutoMapper;
using SuperMarket.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.BL
{
    public class StockService : IGenricService<ReadStockDto>, IGenricServiceAdd<AddStockDto>
    {
        private readonly IStockRepo stockRepo;
        private readonly IMapper mapper;

        public StockService(IStockRepo _stockRepo , IMapper _mapper)
        {
            stockRepo = _stockRepo;
            mapper = _mapper;
        }
        public async Task delete(int id)
        {
            await stockRepo.Delete(id);
            await stockRepo.SaveChangeAsync();
        }
        public async Task<IEnumerable<ReadStockDto>> GetAll()
        {
            var getall = await stockRepo.GetAllAsync();
            var data = mapper.Map<IEnumerable<ReadStockDto>>(getall);
            return data;
        }
        public async Task<ReadStockDto> GetById(int id)
        {
            var getbyid = await stockRepo.GetByIdAsync(id);
            if (getbyid == null) return null;
            var data = mapper.Map<ReadStockDto>(getbyid);
            return data;
        }
        public async Task Insert(AddStockDto entity)
        {
            var add = mapper.Map<Stock>(entity);
            await stockRepo.Insert(add);
            await stockRepo.SaveChangeAsync();
           
        }
        public async Task update(int id, AddStockDto entity)
        {
            var Entity = await stockRepo.GetByIdAsync(id);
            if (Entity == null) return ;
             Entity.Name = entity.Name;
             Entity.ProductId = entity.ProductId;
             Entity.Quantity = entity.Quantity;
             Entity.UserId = entity.UserId;
            await stockRepo.update(Entity);
            await stockRepo.SaveChangeAsync();
        }

    }
}
