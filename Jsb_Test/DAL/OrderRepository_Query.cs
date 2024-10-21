using Jsb_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace Jsb_Test.DAL
{
    public class OrderRepository_Query : IrepositoryQuery<Order>
    {
        public OrderRepository_Query(Simplestorecontext context)
        {
            this.context = context;
        }

        protected Simplestorecontext context { get; set; }

        public async Task<Order> findasync(int id)
        {
            Order? pr = await this.context.Orders.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);

            return pr;
        }

        public async Task<IEnumerable<Order>> findallasync()
        {
            var pr = await this.context.Orders.AsNoTracking().ToListAsync();

            return pr;
        }

    }
}
