using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParadise.Library
{
    public class Store
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }

        public List<Order> Orders { get; set; }

        public Inventory StoreInventory { get; set; }

        public Store(int store)
        {
            StoreId = store;
            Orders = new List<Order>();
            //StoreInventory = new Inventory();
        }

        public void addOrder(Order o)
        {
            Orders.Add(o);
        }
    }
}
