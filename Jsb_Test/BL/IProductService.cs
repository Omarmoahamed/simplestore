using Jsb_Test.Models;

namespace Jsb_Test.BL
{
    public interface IProductService
    {
        Task<IEnumerable<Product>?> GetProducts();

        Task<Product?> GetProductById(int id);

        Task<bool> AddProduct(Product product);

        Task<bool> UpdateProduct(int id,Product pr);

        Task<bool> DeleteProduct(int id);



    }
}
