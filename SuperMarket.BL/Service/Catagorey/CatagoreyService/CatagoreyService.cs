using AutoMapper;
using SuperMarket.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.BL
{
    public class CatagoreyService : IGenricService<ReadCategoryDto>, IGenricServiceAdd<AddCategoryDto>
    {
        private readonly ICategoreyRepo categoreyRepo;
        private readonly IMapper mapper;

        public CatagoreyService(ICategoreyRepo _categoreyRepo , IMapper _mapper)
        {
            categoreyRepo = _categoreyRepo;
            mapper = _mapper;
        }
        public async Task delete(int id)
        {
            await categoreyRepo.Delete(id);
            await categoreyRepo.SaveChangeAsync();
        }

        public async Task<IEnumerable<ReadCategoryDto>> GetAll()
        {
            var category = await categoreyRepo.GetAllAsync();
            var data = mapper.Map<IEnumerable<ReadCategoryDto>>(category);
            return data;

        }

        public async Task<ReadCategoryDto> GetById(int id)
        {
            var category = await categoreyRepo.GetByIdAsync(id);
            if (category == null) return null;
            var data = mapper.Map<ReadCategoryDto>(category);
            return data;
        }

        public async Task Insert(AddCategoryDto entity)
        {
            var category = mapper.Map<Categorey>(entity);
            await categoreyRepo.Insert(category);
            await categoreyRepo.SaveChangeAsync();
        }

        public async Task update(int id, AddCategoryDto Entity)
        {
            var entity = await categoreyRepo.GetByIdAsync(id);
            if(entity == null) return;
            entity.Name = Entity.Name;
            entity.Image = Entity.Image;
            entity.BrandId = entity.BrandId;
            entity.UserId = Entity.UserId;
            await categoreyRepo.update(entity);
            await categoreyRepo.SaveChangeAsync();
        }
    }
}
