using SwiggyApi.Models.Data;
using SwiggyApi.Models.Products;

namespace SwiggyApi.Models.Customers
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly SwiggyDbContext _context;
        public CustomerRepository(SwiggyDbContext context)
        {
            _context = context;

        }

        public Customer AddCustomer(CustomerRequestModel cust)
        {
            try
            {
            Customer Copy = new Customer()
            {

                Customer_Name = cust.Customer_Name,
                Address = cust.Address,
                TotalSpent = cust.TotalSpent,
            };
            _context.Customers.Add(Copy);
            _context.SaveChanges();
            return Copy;
        }
            catch
            {
                throw new Exception("Unable to add Customer");
            }
        }

        public bool DeleteCustomer(int id)
        {
            try
            {
            var customer = _context.Customers.FirstOrDefault(x => x.Customer_Id == id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
            catch
            {
                throw new Exception("Unable to delete user");
            }
        }

        public List<Customer> GetAll()
        {
            try
            {
            List<Customer> cust = _context.Customers.ToList();
            return cust;
        }
            catch
            {
                throw new Exception("Server Error! Can't load customer Details");
            }
        }

        public Customer GetCustomerById(int id)
        {
            var customer = _context.Customers.Find(id);
            if (customer != null)
                return customer;
            else
                throw new Exception(" Customer Id not Found! ");
        }

        public Customer UpdateCustomer(UpdateCustomerModel customer, int id)
        {
            var cust = _context.Customers.Find(id);
            if (cust != null)
            {
               cust.Customer_Name = customer.Customer_Name;
                cust.Address = customer.Address;
                cust.TotalSpent = customer.TotalSpent;

                _context.SaveChanges();
                return cust;
            }
            else
            {
                throw new Exception("Id not Found");
            }
        }
    }
}
