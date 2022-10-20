using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SwiggyApi.Models.Data;
using SwiggyApi.Models.Products;

namespace SwiggyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private IProductRepository _productRepository;

        private readonly SwiggyDbContext dbContext;

        public ProductController(IProductRepository productRepository, SwiggyDbContext dbContext)
        {
            _productRepository = productRepository;
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_productRepository.GetAll());

        }
        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetProduct([FromRoute] int id)
        {
            
            try{
                return Ok(_productRepository.GetProduct(id));
            }
            catch { return NotFound(); }
        }

        [HttpPost]
        public IActionResult AddProduct(ProductRequestModel prod)
        {
           
            return Ok(_productRepository.AddProduct(prod));
        }
        [HttpPut]
        [Route("{id:int}")]
         
    public IActionResult UpdateProduct([FromRoute] int id,  UpdateProductModel prod)
        {
           
            try
            {
               return Ok (_productRepository.UpdateProduct(prod, id));
            }
            
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult DeleteProduct([FromRoute] int id)
        {
          
            if(_productRepository.DeleteProduct(id))
            {
          

                return Ok();
            }
            else
            { return NotFound();}
        }
    }
}
