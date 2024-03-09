using AutoMapper;
using SuperMarket.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarket.BL
{
    public class CustomerService : IGenricService<ReadCustomerDto>, IGenricServiceAdd<AddCustomerDto>
    {
        private readonly ICustomerRepo customerRepo;
        private readonly IMapper mapper;

        public CustomerService(ICustomerRepo _customerRepo , IMapper _mapper)
        {
            customerRepo = _customerRepo;
            mapper = _mapper;
        }
        public async Task delete(int id)
        {

            await customerRepo.Delete(id);
            await customerRepo.SaveChangeAsync();
        }

        public async Task<IEnumerable<ReadCustomerDto>> GetAll()
        {
            var customer = await customerRepo.GetAllAsync();
            var data = mapper.Map<IEnumerable<ReadCustomerDto>>(customer);
            return data;
        }

        public async Task<ReadCustomerDto> GetById(int id)
        {
            var customer = await customerRepo.GetByIdAsync(id);
            if (customer == null) return null;
            var data = mapper.Map<ReadCustomerDto>(customer);
            return data;
        }

        public async Task Insert(AddCustomerDto entity)
        {
            var customer = mapper.Map<Customer>(entity);
            await customerRepo.Insert(customer);
            await customerRepo.SaveChangeAsync();
        }

        public async Task update(int id, AddCustomerDto Entity)
        {
            var entity = await customerRepo.GetByIdAsync(id);
            if(entity == null) return;
            entity.First_Name = Entity.First_Name;
            entity.Mid_Name = Entity.Mid_Name;
            entity.Last_Name = Entity.Last_Name;
            entity.Phone = Entity.Phone;
            entity.Email = Entity.Email;
            entity.Country = Entity.Country;
            entity.City = Entity.City;
            entity.Street = Entity.Street;
            entity.UserId = Entity.UserId;
            await customerRepo.update(entity);
            await customerRepo.SaveChangeAsync();
        }
    }
}
