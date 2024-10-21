namespace Jsb_Test.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public string item_Name { get; set; }

        public double price { get; set; }

        public int customerid { get; set; }

        public int orderid { get; set; }

        public Order order { get; set; }

    }
}
