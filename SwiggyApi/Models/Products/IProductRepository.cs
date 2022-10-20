namespace SwiggyApi.Models.Products
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetProduct(int id);
        Product AddProduct(ProductRequestModel product);
        Product UpdateProduct(UpdateProductModel product, int id);
        bool DeleteProduct(int id);
    }
}
