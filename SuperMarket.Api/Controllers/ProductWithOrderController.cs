using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.BL;

namespace SuperMarket.Api.Controllers
{
    [Route("ProductWithOrder")]
    [ApiController]
    [Authorize]
    public class ProductWithOrderController : ControllerBase
    {
        private readonly IGenricService<ReadProductWithOrderDto> genricService;
        private readonly IGenricServiceAdd<AddProductWithOrderDto> genricServiceAdd;

        public ProductWithOrderController(IGenricService<ReadProductWithOrderDto> _genricService, IGenricServiceAdd<AddProductWithOrderDto> _genricServiceAdd)
        {
            genricService = _genricService;
            genricServiceAdd = _genricServiceAdd;

        }
        [HttpGet]
        public async Task<ActionResult<ReadProductWithOrderDto>> GetAll()
        {
            var get = await genricService.GetAll();
            return Ok(get);
        }
        [HttpGet("id:int")]
        public async Task<ActionResult<ReadProductWithOrderDto>> GetById(int id)
        {
            var getid = await genricService.GetById(id);
            if (getid == null) return NotFound($"Invalid Number !({id})");
            return Ok(getid);
        }
        [HttpPost]
        public async Task<ActionResult> Add(AddProductWithOrderDto Entity)
        {
            await genricServiceAdd.Insert(Entity);
            return Ok("Add Sucssfuly");
        }
        [HttpDelete]
        public async Task<ActionResult> Deleted(int id)
        {
            var delet = await genricService.GetById(id);
            if (delet == null)
                return NotFound($"Invalid Number !({id})");
            await genricService.delete(id);
            return Ok("Deleted Sucssfuly");
        }
        [HttpPut]
        public async Task<ActionResult> update(int id, AddProductWithOrderDto Entity)
        {
            var check = await genricService.GetById(id);
            if (check == null) return NotFound($"Invalid Number !({id})");
            await genricServiceAdd.update(id, Entity);
            return Ok("updated Sucssfuly");
        }
    }
}
