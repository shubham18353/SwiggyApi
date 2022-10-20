namespace SwiggyApi.Models.Customers
{
    public interface ICustomerRepository
    {
        List<Customer> GetAll();
        Customer GetCustomerById(int id);
        Customer AddCustomer(CustomerRequestModel customer);
        Customer UpdateCustomer(UpdateCustomerModel customer, int id);
        bool DeleteCustomer(int id);
    }
}
