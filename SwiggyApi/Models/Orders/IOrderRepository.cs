using SwiggyApi.Models.Customers;

namespace SwiggyApi.Models.Orders
{
    public interface IOrderRepository
    {
        List<Order> GetAll();
        Order GetOrderById(int id);
        Order NewOrder(OrderRequestModel order);
        Order UpdateOrder(UpdateOrderModel order, int id);
        bool DeleteOrder(int id);
    }
}
