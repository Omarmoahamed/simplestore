using Jsb_Test.BL;
using Jsb_Test.DAL;
using Jsb_Test.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jsb_Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public OrderController(Iorderservice Orderservice) 
        {
            this.Orderservice = Orderservice;
        }

        public Iorderservice Orderservice;



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAll()
        {
            var list = await Orderservice.GetOrders();

            return Ok(list);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult> GetOrder(int id) 
        {
            var or = await Orderservice.GetOrder(id);

            return or == null ? NotFound("order is not found") : Ok(or);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteOrder(int id) 
        {
            var or = await Orderservice.delete(id);

            return or == false ? NotFound("order is not found") : Ok("order is deleted successfully");
        }

        [HttpPost]
        public async Task<ActionResult> AddOrder([FromBody]Order order) 
        {
            return await Orderservice.Add(order) == false ? BadRequest(new { message = "Please write correct fields" }) : Ok("order is added successfully");
        }

        [HttpPut("{id}")]

        public async Task<ActionResult> UpdateOrder(int id, [FromBody]Order order) 
        {
            return await Orderservice.update(id, order) == false ? BadRequest(new {messages = "order is not found or total amount is less equal or less than zero"}) : Ok("order is updated successfully");

            
        }
    }
}
