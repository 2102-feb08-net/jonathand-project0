using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParadise.Library
{
    class Store
    {
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public List<Inventory> Inventory { get; set; } = new List<Inventory>();

        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
