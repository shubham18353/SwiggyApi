using SwiggyApi.Models.Data;
using SwiggyApi.Models.Products;

namespace SwiggyApi.Models.Orders
{
    public class OrderRepository:IOrderRepository
    {
        private readonly SwiggyDbContext _context;
        public OrderRepository(SwiggyDbContext context)
        {
            _context = context;

        }

        public Order NewOrder(OrderRequestModel order)
        {
            Order Copy = new Order()
            {
                OrderValue = order.OrderValue,
                OrderType = order.OrderType,
                Customer_Id=order.Customer_Id,
                
            };
            _context.Orders.Add(Copy);
            
            _context.SaveChanges();
            return Copy;
        }

        public bool DeleteOrder(int id)
        {
            var order = _context.Orders.FirstOrDefault(x => x.Order_Id == id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Order> GetAll()
        {
            List<Order> order = _context.Orders.ToList();
            return order;
        }

        public Order GetOrderById(int id)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
                return order;
            else
                throw new Exception();
        }

        public Order UpdateOrder(UpdateOrderModel order, int id)
        {
            var ord = _context.Orders.Find(id);
            if (ord != null)
            {
                ord.OrderValue = order.OrderValue;
                ord.OrderType =order.OrderType;
                ord.Customer_Id = order.Customer_Id;

                _context.SaveChanges();
                return ord;
            }
            else
            {
                throw new Exception("Id not Found");
            }
        }
    }
}
