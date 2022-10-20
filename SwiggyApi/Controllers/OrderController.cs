using Microsoft.AspNetCore.Mvc;
using SwiggyApi.Models.Data;
using SwiggyApi.Models.Orders;
using SwiggyApi.Models.Orders;

namespace SwiggyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        
            private IOrderRepository _orderRepository;

            private readonly SwiggyDbContext dbContext;

            public OrderController(IOrderRepository orderRepository, SwiggyDbContext dbContext)
            {
                _orderRepository = orderRepository;
                this.dbContext = dbContext;
            }

            [HttpGet]
            public IActionResult GetOrders()
            {
                return Ok(_orderRepository.GetAll());

            }
            [HttpGet]
            [Route("{id:int}")]
            public IActionResult GetOrder([FromRoute] int id)
            {

                try
                {
                    return Ok(_orderRepository.GetOrderById(id));
                }
                catch { return NotFound(); }
            }

            [HttpPost]
            public IActionResult AddOrder(OrderRequestModel order)
            {

                return Ok(_orderRepository.NewOrder(order));
            }
            [HttpPut]
            [Route("{id:int}")]

            public IActionResult UpdateOrder([FromRoute] int id, UpdateOrderModel order)
            {

                try
                {
                    return Ok(_orderRepository.UpdateOrder(order, id));
                }

                catch
                {
                    return NotFound();
                }
            }

            [HttpDelete]
            [Route("{id:int}")]
            public IActionResult DeleteOrder([FromRoute] int id)
            {

                if (_orderRepository.DeleteOrder(id))
                {


                    return Ok();
                }
                else
                { return NotFound(); }
            }
        }
}
