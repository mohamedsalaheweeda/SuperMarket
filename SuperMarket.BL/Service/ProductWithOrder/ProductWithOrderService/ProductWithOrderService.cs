using AutoMapper;
using SuperMarket.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.BL
{
    public class ProductWithOrderService : IGenricService<ReadProductWithOrderDto>, IGenricServiceAdd<AddProductWithOrderDto>
    {
        private readonly IProductWithOrderRepo productWithOrderRepo;
        private readonly IMapper mapper;

        public ProductWithOrderService(IProductWithOrderRepo _productWithOrderRepo, IMapper _mapper)
        {
            productWithOrderRepo = _productWithOrderRepo;
            mapper = _mapper;
        }
        public async Task delete(int id)
        {
            await productWithOrderRepo.Delete(id);
            await productWithOrderRepo.SaveChangeAsync();
        }

        public async Task<IEnumerable<ReadProductWithOrderDto>> GetAll()
        {
            var getall = await productWithOrderRepo.GetAllAsync();
            var data = mapper.Map<IEnumerable<ReadProductWithOrderDto>>(getall);
            return data;
        }

        public async Task<ReadProductWithOrderDto> GetById(int id)
        {
            var getbyid = await productWithOrderRepo.GetByIdAsync(id);
            if (getbyid == null) return null;
            var data = mapper.Map<ReadProductWithOrderDto>(getbyid);
            return data;
        }

        public async Task Insert(AddProductWithOrderDto entity)
        {
            var add = mapper.Map<ProductWithOrder>(entity);
            await productWithOrderRepo.Insert(add);
            await productWithOrderRepo.SaveChangeAsync();
        }

        public async Task update(int id, AddProductWithOrderDto entity)
        {
            var Entity = await productWithOrderRepo.GetByIdAsync(id);
            if (Entity == null) return;
            Entity.Quantity = entity.Quantity;
            Entity.Discount_AllTotal = entity.Discount_AllTotal;
            Entity.OrderId = entity.OrderId;
            Entity.ProductId = entity.ProductId;
            Entity.UserId = entity.UserId;
            await productWithOrderRepo.update(Entity);
            await productWithOrderRepo.SaveChangeAsync();
        }
    }
}
