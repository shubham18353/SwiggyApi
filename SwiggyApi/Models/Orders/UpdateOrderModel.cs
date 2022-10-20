using SwiggyApi.Models.Customers;

namespace SwiggyApi.Models.Orders
{
    public class UpdateOrderModel
    {
        public int? Customer_Id { get; set; }
       // public Customer? Customer { get; set; }
        public string? OrderType { get; set; }
        public decimal? OrderValue { get; set; }
    }
}
