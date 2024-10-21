using Jsb_Test.Models;

namespace Jsb_Test.BL
{
    public interface Iorderservice
    {
        Task<IEnumerable<Order>?> GetOrders();
        Task<Order?> GetOrder(int id);
        public Task<bool> Add(Order or);
        public Task<bool> update(int id,Order order);

        public Task<bool> delete(int id);
    }
}
