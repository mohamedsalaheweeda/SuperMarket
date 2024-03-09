using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.BL;

namespace SuperMarket.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(policy: "Manager")]
    public class StockController : ControllerBase
    {
        private readonly IGenricService<ReadStockDto> genricService;
        private readonly IGenricServiceAdd<AddStockDto> genricServiceAdd;

        public StockController(IGenricService<ReadStockDto> _genricService, IGenricServiceAdd<AddStockDto> _genricServiceAdd)
        {
            genricService = _genricService;
            genricServiceAdd = _genricServiceAdd;
        }
        [HttpGet]
        public async Task<ActionResult<ReadStockDto>> GetAll()
        {
            var get = await genricService.GetAll();
            return Ok(get);
        }
        [HttpGet("id:int")]
        public async Task<ActionResult<ReadStockDto>> GetById(int id)
        {
            var getid = await genricService.GetById(id);
            if (getid == null) return NotFound($"Invalid Number !({id})");
            return Ok(getid);
        }
        [HttpPost]
        public async Task<ActionResult> Add(AddStockDto Entity)
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
        public async Task<ActionResult> update(int id, AddStockDto Entity)
        {
            var check = await genricService.GetById(id);
            if (check == null) return NotFound($"Invalid Number !({id})");
            await genricServiceAdd.update(id, Entity);
            return Ok("updated Sucssfuly");
        }
    }
}
