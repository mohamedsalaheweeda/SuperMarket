using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.BL;

namespace SuperMarket.Api.Controllers
{
    [Route("Product")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IGenricService<ReadProductDto> genricService;
        private readonly IGenricServiceAdd<AddProductDto> genricServiceAdd;

        public ProductController(IGenricService<ReadProductDto> _genricService, IGenricServiceAdd<AddProductDto> _genricServiceAdd)
        {
            genricService = _genricService;
            genricServiceAdd = _genricServiceAdd;
           
        }
        [HttpGet]
        public async Task<ActionResult<ReadProductDto>> GetAll()
        {
            var get = await genricService.GetAll();
            return Ok(get);
        }
        [HttpGet("id:int")]
        public async Task<ActionResult<ReadProductDto>> GetById(int id)
        {
            var getid = await genricService.GetById(id);
            if (getid == null) return NotFound($"Invalid Number !({id})");
            return Ok(getid);
        }
        [HttpPost]
        [Authorize(policy: "Manager")]
        public async Task<ActionResult> Add(AddProductDto Entity)
        {
            await genricServiceAdd.Insert(Entity);
            return Ok("Add Sucssfuly");
        }
        [HttpDelete]
        [Authorize(policy: "Manager")]
        public async Task<ActionResult> Deleted(int id)
        {
            var delet = await genricService.GetById(id);
            if (delet == null)
                return NotFound($"Invalid Number !({id})");
            await genricService.delete(id);
            return Ok("Deleted Sucssfuly");
        }
        [HttpPut]
        [Authorize(policy: "Manager")]
        public async Task<ActionResult> update(int id, AddProductDto Entity)
        {
            var check = await genricService.GetById(id);
            if (check == null) return NotFound($"Invalid Number !({id})");
            await genricServiceAdd.update(id, Entity);
            return Ok("updated Sucssfuly");
        }
    }
}
