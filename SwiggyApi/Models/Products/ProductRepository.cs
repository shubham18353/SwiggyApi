using Microsoft.EntityFrameworkCore;
using SwiggyApi.Models.Data;

namespace SwiggyApi.Models.Products
{
    public class ProductRepository : IProductRepository
    {

        private readonly SwiggyDbContext _context;
        public ProductRepository(SwiggyDbContext context)
        {
            _context = context;

        }

        public Product AddProduct(ProductRequestModel product)
        {
            Product productCopy = new Product()
            {

                ProductName = product.ProductName,
                ProductType = product.ProductType,
                Price = product.Price,
            };
            _context.Products.Add(productCopy);
            _context.SaveChanges();
            return productCopy;
        }

        public bool DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Product> GetAll()
        {
            List<Product> products = _context.Products.ToList();
            return products;
        }

        public Product GetProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
                return product;
            else
                throw new Exception();
        }

        public Product UpdateProduct(UpdateProductModel product, int id)
        {
            var products = _context.Products.Find(id);
            if (products != null)
            {
                products.ProductName = product.ProductName;
                products.ProductType = product.ProductType;
                products.Price = product.Price;

                _context.SaveChanges();
                return products;
            }
            else
            {
                throw new Exception("Id not Found");
            }
        }
    }
}
