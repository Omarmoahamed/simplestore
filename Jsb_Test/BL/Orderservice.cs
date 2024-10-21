using Jsb_Test.DAL;
using Jsb_Test.Models;
using System.Reflection.Metadata.Ecma335;

namespace Jsb_Test.BL
{
    public class Orderservice : Iorderservice
    {

        public Orderservice(Irepository<Order> repository, IrepositoryQuery<Order> query) 
        {
            this.repository = repository;
            this.query = query;
        }
        protected Irepository<Order> repository;
        protected IrepositoryQuery<Order> query;



        public async Task<IEnumerable<Order>?> GetOrders()
        {
            var list = await query.findallasync();

            return list;
        }
        public async  Task<Order?> GetOrder(int id) 
        {
            var or = await repository.Findasync(id);
            return or;
        }
        public async Task<bool> Add(Order or) 
        {
            if (or.total_amount <= 0) 
            {
                return false;
            }

           await repository.Addasync(or);
            await repository.saveasync();

            return true;
        }

        public async Task<bool> update(int id,Order order) 
        {
            Order? or = await repository.Findasync(id);

            if (or is null || or.total_amount <=0) 
            {
                return false;
            }

            or.total_amount = order.total_amount;
            or.customerid = order.customerid;
            or.orderdate = order.orderdate;

            repository.update(or);
            await repository.saveasync();

            return true;

        }


        public async Task<bool> delete(int id) 
        {
            Order? or = await repository.Findasync(id);

            if (or is null)
            {
                return false;
            }

            repository.Delete(or);
          await  repository.saveasync();

            return true;

        }

    }
}
