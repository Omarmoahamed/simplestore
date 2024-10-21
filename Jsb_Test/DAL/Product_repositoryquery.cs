using Jsb_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace Jsb_Test.DAL
{
    public class Product_repositoryquery: IrepositoryQuery<Product>
    {
        public Product_repositoryquery(Simplestorecontext context) 
        {
            this.context = context;
        }

        protected Simplestorecontext context {  get; set; }

        public async Task<Product> findasync(int id) 
        {
            Product? pr = await this.context.Products.AsNoTracking().FirstOrDefaultAsync(p=> p.Id == id);

            return pr;
        }

        public async Task<IEnumerable<Product>> findallasync() 
        {
            var pr = await this.context.Products.AsNoTracking().ToListAsync();

            return pr;
        }
    }
}
