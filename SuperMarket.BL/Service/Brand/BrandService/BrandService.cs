
using AutoMapper;
using SuperMarket.BL;
using SuperMarket.DL;

namespace SuperMarket.BL
{
    public class BrandService : IGenricService<ReadBrandDto>, IGenricServiceAdd<AddBrandDto>
    {
        private readonly IBrandRepo brandRepo;
        private readonly IMapper mapper;

        public BrandService(IBrandRepo _brandRepo , IMapper _mapper)
        {
            brandRepo = _brandRepo;
            mapper = _mapper;
        }
        public async Task delete(int id)
        {
            await brandRepo.Delete(id);
            await brandRepo.SaveChangeAsync();
        }

        public async Task<IEnumerable<ReadBrandDto>> GetAll()
        {
            var brand = await brandRepo.GetAllAsync();
            var data = mapper.Map<IEnumerable<ReadBrandDto>>(brand);
            return data;

        }

        public async Task<ReadBrandDto> GetById(int id)
        {
            var brand = await brandRepo.GetByIdAsync(id);
            if (brand == null) return null;
            var data = mapper.Map<ReadBrandDto>(brand);
            return data;
        }

        public async Task Insert(AddBrandDto entity)
        {
            var brand = mapper.Map<Brand>(entity);
            await brandRepo.Insert(brand);
            await brandRepo.SaveChangeAsync();
        }

        public async Task update(int id, AddBrandDto Entity)
        {
            var entity = await brandRepo.GetByIdAsync(id);
            if (entity == null) return;
            entity.Name = Entity.name;
            entity.UserId= Entity.UserId;
            await brandRepo.update(entity);
            await brandRepo.SaveChangeAsync();
        }
    

    }
}
