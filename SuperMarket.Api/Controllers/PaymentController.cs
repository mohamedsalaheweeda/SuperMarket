using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperMarket.BL;

namespace SuperMarket.Api.Controllers
{
    [Route("Payment")]
    [ApiController]
    [Authorize]
    public class PaymentController : ControllerBase
    {
        private readonly IGenricService<ReadPaymentDto> genricService;
        private readonly IGenricServiceAdd<AddPaymentDto> genricServiceAdd;

        public PaymentController(IGenricService<ReadPaymentDto> _genricService, IGenricServiceAdd<AddPaymentDto> _genricServiceAdd)
        {
            genricService = _genricService;
            genricServiceAdd = _genricServiceAdd;
        }
        [HttpGet]
        public async Task<ActionResult<ReadPaymentDto>> GetAll()
        {
            var get = await genricService.GetAll();
            return Ok(get);
        }
        [HttpGet("id:int")]
        public async Task<ActionResult<ReadPaymentDto>> GetById(int id)
        {
            var getid = await genricService.GetById(id);
            if (getid == null) return NotFound($"Invalid Number !({id})");
            return Ok(getid);
        }
        [HttpPost]
        public async Task<ActionResult> Add(AddPaymentDto Entity)
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
        public async Task<ActionResult> update(int id, AddPaymentDto Entity)
        {
            var check = await genricService.GetById(id);
            if (check == null) return NotFound($"Invalid Number !({id})");
            await genricServiceAdd.update(id, Entity);
            return Ok("updated Sucssfuly");
        }
    }
}
