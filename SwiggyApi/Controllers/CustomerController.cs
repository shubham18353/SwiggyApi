using Microsoft.AspNetCore.Mvc;
using SwiggyApi.Models.Customers;
using SwiggyApi.Models.Data;
using SwiggyApi.Models.Products;

namespace SwiggyApi.Controllers
{
           [ApiController]
        [Route("api/[controller]")]
        public class CustomerController : Controller
        {
            private ICustomerRepository _customerRepository;

            private readonly SwiggyDbContext dbContext;

            public CustomerController(ICustomerRepository customerRepository, SwiggyDbContext dbContext)
            {
                _customerRepository = customerRepository;
                this.dbContext = dbContext;
            }

            [HttpGet]
            public IActionResult GetProducts()
            {
                return Ok(_customerRepository.GetAll());

            }
            [HttpGet]
            [Route("{id:int}")]
            public IActionResult GetCustomer([FromRoute] int id)
            {

                try
                {
                    return Ok(_customerRepository.GetCustomerById(id));
                }
                catch { return NotFound(); }
            }

            [HttpPost]
            public IActionResult AddCustomer(CustomerRequestModel cust)
            {

                return Ok(_customerRepository.AddCustomer(cust));
            }
            [HttpPut]
            [Route("{id:int}")]

            public IActionResult UpdateCustomer([FromRoute] int id, UpdateCustomerModel cust)
            {

                try
                {
                    return Ok(_customerRepository.UpdateCustomer(cust, id));
                }

                catch
                {
                    return NotFound();
                }
            }

            [HttpDelete]
            [Route("{id:int}")]
            public IActionResult DeleteCustomer([FromRoute] int id)
            {

                if (_customerRepository.DeleteCustomer(id))
                {


                    return Ok();
                }
                else
                { return NotFound(); }
            }
        }
}
