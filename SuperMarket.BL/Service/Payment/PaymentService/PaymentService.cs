using AutoMapper;
using SuperMarket.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.BL
{
    public class PaymentService : IGenricService<ReadPaymentDto> , IGenricServiceAdd<AddPaymentDto>
    {
        private readonly IPaymentRepo paymentRepo;
        private readonly IMapper mapper;

        public PaymentService(IPaymentRepo _paymentRepo, IMapper _mapper)
        {
            paymentRepo = _paymentRepo;
            mapper = _mapper;
        }
        public async Task delete(int id)
        {
            await paymentRepo.Delete(id);
            await paymentRepo.SaveChangeAsync();
        }

        public async Task<IEnumerable<ReadPaymentDto>> GetAll()
        {
            var payment = await paymentRepo.GetAllAsync();
            var data = mapper.Map<IEnumerable<ReadPaymentDto>>(payment);
            return data;
        }

        public async Task<ReadPaymentDto> GetById(int id)
        {
            var payment = await paymentRepo.GetByIdAsync(id);
            if (payment == null) return null;
            var data = mapper.Map<ReadPaymentDto>(payment);
            return data;
        }

        public async Task Insert(AddPaymentDto entity)
        {
            var payment = mapper.Map<Payment>(entity);
            await paymentRepo.Insert(payment);
            await paymentRepo.SaveChangeAsync();
        }



        public async Task update(int id, AddPaymentDto entity)
        {
            var Entity = await paymentRepo.GetByIdAsync(id);
            if (Entity == null) return;
             Entity.Amount = entity.Amount;
             Entity.Type_Amount = entity.Type_Amount;
             Entity.CustomerId = entity.CustomerId;
            Entity.UserId = entity.UserId;
            await paymentRepo.update(Entity);
            await paymentRepo.SaveChangeAsync();
        }
    }
}
