using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaParadise.Library
{
    public class Store
    {
        public List<Product> Inventory { get; set; }
        public List<Order> order { get; set; }
        public int StoreNum { get; set; }

        public Store(int store)
        {
            StoreNum = store;
            Inventory = new List<Product>();
        }

        public void addItem(string name, int amount, double price)
        {
            var item = new Product(name, amount, price);
            Inventory.Add(item);
        }

        public void makeOrder(string name, int amount)
        {
            foreach(Product n in Inventory)
            {
                if(n.ItemName == name)
                {
                    n.Amount -= amount;
                }

            }
        }
    }
}
