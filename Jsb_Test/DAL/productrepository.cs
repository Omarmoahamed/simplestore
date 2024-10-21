using Jsb_Test.Models;

namespace Jsb_Test.DAL
{
    public class productrepository : Irepository<Product>
    {
        public productrepository(Simplestorecontext context) 
        {

            this.context = context;
        }

        protected Simplestorecontext context;

        public async Task Addasync(Product entity) 
        {
            await context.Products.AddAsync(entity);
        }


        public async Task<Product?> Findasync(int id) 
        {
           Product? p = await context.Products.FindAsync(id);
            return p;
        }

        public void update(Product entity) 
        {
            context.Products.Update(entity);
        }

        public async Task saveasync() 
        {
            await context.SaveChangesAsync();
        }

        public void Delete(Product pr) 
        {
             context.Products.Remove(pr);
        }
    }
}
