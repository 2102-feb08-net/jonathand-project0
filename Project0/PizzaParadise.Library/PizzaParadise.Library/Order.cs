using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaParadise.Library
{
    public class Order
    {
        public int StoreNumber { get; }
        public Customer CurrentCustomer { get; set; }
        public List<Product> CustomerOrder { get; set; }

        public DateTimeOffset Time { get; set; }

        public Order(int store, Customer current, DateTimeOffset time)
        {
            CurrentCustomer = current;
            StoreNumber = store;
            CustomerOrder = new List<Product>();
            Time = time;
        }

        public void addProduct(string name, int amount, double price)
        {
            Product newProduct = new Product(name, amount, price);
            CustomerOrder.Add(newProduct);
        }
    }
}
