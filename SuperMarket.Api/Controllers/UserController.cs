using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.BL;


namespace SuperMarket.Api.Controllers
{
    [Route("User")]
    [ApiController]
    [Authorize(policy:"Manager")]
    public class UserController : ControllerBase
    {

        private readonly IGenricService<ReadUserDto> _adminService;
        private readonly IGenricServiceAdd<AddUserDto> _adminGenericsService;

        public UserController(
              IGenricServiceAdd<AddUserDto> adminGenericsService
            , IGenricService<ReadUserDto> adminService
           )
        {
            _adminService = adminService;
            _adminGenericsService = adminGenericsService;

        }

        [HttpGet]
        public async Task<ActionResult<ReadUserDto>> GetAll()
        {
            var GetAllAdmin = await _adminService.GetAll();
            return Ok(GetAllAdmin);
        }
        [HttpGet("id:int")]
        public async Task<ActionResult<ReadUserDto>> GetById(int id)
        {
            var Admin = await _adminService.GetById(id);
            if (Admin == null) return NotFound($"Invalid Number !({id})");
            return Ok(Admin);
        }
        [HttpPost]
        public async Task<ActionResult> Add(AddUserDto Entity)
        {
           await _adminGenericsService.Insert(Entity);
            return Ok("Add Successful");
        }
        [HttpPut]
        public async Task<ActionResult> update(int id , AddUserDto Entity)
        {
            var check = await _adminService.GetById( id );
            if (check == null) return NotFound($"Invalid Number !({id})");
            await _adminGenericsService.update(id,Entity);
            return Ok("updated Successful");
        }
        [HttpDelete]
        public async Task<ActionResult> Deleted(int id)
        {
            var delete = await _adminService.GetById(id);
            if (delete == null) 
                return NotFound($"Invalid Number !({id})");
            await _adminService.delete(id);
            return Ok("Deleted Successful");
        }

        
    }
}
