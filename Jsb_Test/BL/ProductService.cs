using Jsb_Test.DAL;
using Jsb_Test.Models;

namespace Jsb_Test.BL
{
    public class ProductService : IProductService
    {
        public ProductService(Irepository<Product> _repository, IrepositoryQuery<Product> _repositoryQuery) 
        {
            this._repository = _repository;
            this._repositoryQuery = _repositoryQuery;
        }

        protected Irepository<Product> _repository;

        protected IrepositoryQuery<Product> _repositoryQuery;


       public async Task<IEnumerable<Product>?> GetProducts() 
        {
         var list = await  _repositoryQuery.findallasync();

            return list;
        }

        public async Task<Product?> GetProductById(int id) 
        {
            Product? pr =await  _repositoryQuery.findasync(id);

            return pr;
        }

        public async Task<bool> AddProduct(Product product) 
        {
            if(product.price < 0 || product.stock < 0 || product.Description == string.Empty || product.Name == string.Empty) 
            {
                return false;
            }
           await _repository.Addasync(product);
            await _repository.saveasync();

            return true;
        }

        public async Task<bool> UpdateProduct(int id,Product product) 
        {
            Product? pr = await _repository.Findasync(id);

            if (pr is null) 
            {
                return false;
            }

            if (product.price < 0 || product.stock < 0 || product.Description == string.Empty || product.Name == string.Empty)
            {
                return false;
            }

            pr.price = product.price;
            pr.stock = product.stock;
            pr.Name = product.Name;
            pr.Description = product.Description;
            
            _repository.update(pr);
            await _repository.saveasync();
            return true;
        }

        public async Task<bool> DeleteProduct(int id) 
        {
            Product? pr = await _repository.Findasync(id);

            if(pr is null) {  return false; }

            _repository.Delete(pr);
            await _repository.saveasync();
            return true;
        }
    }
}
