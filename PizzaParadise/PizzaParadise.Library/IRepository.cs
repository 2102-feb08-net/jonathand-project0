using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParadise.Library
{
    public interface IRepository
    {
        public List<Customer> GetAllCustomers();
        public void AddCustomer(Customer c);
        public List<Order> GetAllOrders();
        public void placeOrder(Order o);
    }
}
