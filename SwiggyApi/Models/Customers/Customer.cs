using SwiggyApi.Models.Orders;

namespace SwiggyApi.Models.Customers
{
    public class Customer
    {
        public int Customer_Id { get; set; }
        public string? Customer_Name { get; set; }
        public string? Address { get; set; }
        public decimal TotalSpent { get; set; }

        //public List<Order>? Orders { get; set; }
    }
}
