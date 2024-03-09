using AutoMapper;
using SuperMarket.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.BL
{
    public class ReviewService : IGenricService<ReadReviewDto>, IGenricServiceAdd<AddReviewDto>
    {
        private readonly IReviewRepo reviewRepo;
        private readonly IMapper mapper;

        public ReviewService(IReviewRepo _reviewRepo, IMapper _mapper)
        {
            reviewRepo = _reviewRepo;
            mapper = _mapper;

        }
        public async Task delete(int id)
        {
            await reviewRepo.Delete(id);
            await reviewRepo.SaveChangeAsync();
        }

        public async Task<IEnumerable<ReadReviewDto>> GetAll()
        {
            var getall = await reviewRepo.GetAllAsync();
            var data = mapper.Map<IEnumerable<ReadReviewDto>>(getall);
            return data;
        }

        public async Task<ReadReviewDto> GetById(int id)
        {
            var getbyid = await reviewRepo.GetByIdAsync(id);
            if (getbyid == null) return null;
            var data = mapper.Map<ReadReviewDto>(getbyid);
            return data;
        }

        public async Task Insert(AddReviewDto entity)
        {
            var data = mapper.Map<Review>(entity);
            await reviewRepo.Insert(data);
            await reviewRepo.SaveChangeAsync();
        }

        public async Task update(int id, AddReviewDto entity)
        {
            var Entity = await reviewRepo.GetByIdAsync(id);
            if (Entity == null) return;
             Entity.Name = entity.Name;
             Entity.CustomerId= entity.CustomerId;
             Entity.UserId = entity.UserId;
            await reviewRepo.update(Entity);
            await reviewRepo.SaveChangeAsync();
        }
    }
}
