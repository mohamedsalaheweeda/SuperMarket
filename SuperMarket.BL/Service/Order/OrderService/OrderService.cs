using AutoMapper;
using SuperMarket.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.BL
{
    public class OrderService : IGenricService<ReadOrderDto>, IGenricServiceAdd<AddOrderDto>
    {
        private readonly IOrderRepo orderRepo;
        private readonly IMapper mapper;

        public OrderService(IOrderRepo _orderRepo, IMapper _mapper)
        {
            orderRepo = _orderRepo;
            mapper = _mapper;
        }
        public async Task delete(int id)
        {
            await orderRepo.Delete(id);
            await orderRepo.SaveChangeAsync();
        }

        public async Task<IEnumerable<ReadOrderDto>> GetAll()
        {
            var order = await orderRepo.GetAllAsync();
            var data = mapper.Map<IEnumerable<ReadOrderDto>>(order);
            return data;
        }

        public async Task<ReadOrderDto> GetById(int id)
        {
            var order = await orderRepo.GetByIdAsync(id);
            if (order == null) return null;
            var data = mapper.Map<ReadOrderDto>(order);
            return data;
        }

        public async Task Insert(AddOrderDto entity)
        {
            var order = mapper.Map<Order>(entity);
            await orderRepo.Insert(order);
            await orderRepo.SaveChangeAsync();
        }

        public async Task update(int id, AddOrderDto entity)
        {
            var Entity =  await orderRepo.GetByIdAsync(id);
            if (Entity == null) return;
              Entity.OrderStatus = entity.OrderStatus;
              Entity.Date = entity.Date;
              Entity.Time = entity.Time;
              Entity.List_Price = entity.List_Price;
              Entity.CustomerId = entity.CustomerId;
              Entity.PaymentId = entity.PaymentId;
              Entity.UserId = entity.UserId;
            await orderRepo.update(Entity);
            await orderRepo.SaveChangeAsync();
        }
    }
}
