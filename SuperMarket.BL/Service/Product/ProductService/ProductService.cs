using AutoMapper;
using SuperMarket.DL;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.BL
{
    public class ProductService : IGenricService<ReadProductDto>, IGenricServiceAdd<AddProductDto>
    {
        private readonly IProductRepo productRepo;
        private readonly IMapper mapper;

        public ProductService(IProductRepo _productRepo, IMapper _mapper)
        {
            productRepo = _productRepo;
            mapper = _mapper;
        }
        public async Task delete(int id)
        {
            await productRepo.Delete(id);
            await productRepo.SaveChangeAsync();
        }

        public async Task<IEnumerable<ReadProductDto>> GetAll()
        {
            var getall = await productRepo.GetAllAsync();
            var data = mapper.Map<IEnumerable<ReadProductDto>>(getall);
            return data;
        }




        public async Task<ReadProductDto> GetById(int id)
        {
            var getbyid = await productRepo.GetByIdAsync(id);
            if (getbyid == null) return null;
            var data = mapper.Map<ReadProductDto>(getbyid);
            return data;
        }

        public async Task Insert(AddProductDto entity)
        {
            var add = mapper.Map<Product>(entity);
            await productRepo.Insert(add);
            await productRepo.SaveChangeAsync();
        }

        public async Task update(int id, AddProductDto entity)
        {
            var Entity = await productRepo.GetByIdAsync(id);
            if (Entity == null) return;
            Entity.Name = entity.Name;
            Entity.Description = entity.Description;
            Entity.Model_Year = entity.Model_Year;
            Entity.Price = entity.Price;
            Entity.Discount = entity.Discount;
            Entity.Quantity = entity.Quantity;
            Entity.BrandId = entity.BrandId;
            Entity.Categoreyid = entity.CategoreyId;
            Entity.UserId = entity.UserId;

            await productRepo.update(Entity);
            await productRepo.SaveChangeAsync();
        }
    }
}
