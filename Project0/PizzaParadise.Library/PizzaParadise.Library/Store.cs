using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaParadise.Library
{
    public class Store
    {
        private List<Product> inventory;
        
        public Store()
        {
            inventory = new List<Product>();
        }

        public void addItem(string name, int amount, double price)
        {
            var item = new Product(name, amount, price);
            inventory.Add(item);
        }

        public void removeItem(string name, int amount)
        {
            foreach(Product n in inventory)
            {
                if(n.ItemName == name)
                {
                    inventory.Remove(n);
                }

            }
        }
    }
}
