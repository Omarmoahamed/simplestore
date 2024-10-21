using Jsb_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace Jsb_Test.DAL
{
    public class OrderRepository : Irepository<Order>
    {
        public OrderRepository(Simplestorecontext context) 
        {
            this.context = context;
        }

        protected Simplestorecontext context { get; set; }

        public async Task Addasync(Order entity) 
        {
            await context.Orders.AddAsync(entity);
        }

        public  void Delete(Order entity) 
        {
           context.Orders.Remove(entity);
        }

        public async Task<Order?> Findasync(int id) 
        {
            var or = await context.Orders.FindAsync(id);

            return or;
        }

        public void update(Order entity) 
        {
            context.Update(entity);
        }

        public async Task saveasync() 
        {
            await context.SaveChangesAsync();
        }
    }
}
