
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SuperMarket.DL;
using SuperMarket.Model.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Channels;

namespace SuperMarket.BL
{
    public class UserService : IGenricServiceAdd<AddUserDto> , IGenricService<ReadUserDto> 
    {
        private readonly UserManager<User> _userManager;
        private readonly IUserRepo _userRepo;
        private readonly IMapper mapper;
        private readonly AppDbContext _context;
        private readonly JwtOption _jwt;

        public UserService(IUserRepo userRepo , IMapper _mapper
            , UserManager<User> userManager , AppDbContext context 
            , IOptions< JwtOption> jwt)
        {
            _userRepo = userRepo;
            mapper = _mapper;
            _userManager = userManager;
            _context = context;
            _jwt = jwt.Value;
        }
        public async Task delete(int id)
        {
            await _userRepo.Delete(id);
            await _userRepo.SaveChangeAsync();
        }
        public async Task<IEnumerable<ReadUserDto>> GetAll()
        {
            var admin = await _userRepo.GetAllAsync();
            var data = mapper.Map<IEnumerable<ReadUserDto>>(admin);
            return data;
        }
        public async Task<ReadUserDto> GetById(int id)
        {
            var get = await _userRepo.GetByIdAsync(id);
            if (get == null) return null;
            var data = mapper.Map<ReadUserDto>(get);
            return data;
        }
        public async Task Insert(AddUserDto Entity)
        {
            var admin = mapper.Map<User>(Entity);
            await _userRepo.Insert(admin);
            await _userRepo.SaveChangeAsync();
        }

      
        public async Task update(int id , AddUserDto Entity)
        {
            
                var entity = await _userRepo.GetByIdAsync(id);
                if (entity == null) return;
                 entity.Name = Entity.Name;
                 entity.Password = Entity.Password;
                await _userRepo.update(entity);
                await _userRepo.SaveChangeAsync();
           
        }


    }
}
