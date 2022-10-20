using SwiggyApi.Models.Customers;

namespace SwiggyApi.Models.Orders
{
    public class Order
    {
        public int Order_Id { get; set; }
        public int? Customer_Id { get; set; }
        //public Customer? Customer { get; set; }
        public string? OrderType { get; set; }
        public decimal? OrderValue { get; set; }

        
    }
}
