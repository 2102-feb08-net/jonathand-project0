using System;
using System.Collections.Generic;

#nullable disable

namespace PizzaParadise.DAL
{
    public partial class Store
    {
        public Store()
        {
            Inventory = new HashSet<Inventory>();
            Orders = new HashSet<Order>();
        }

        public int StoreId { get; set; }
        public string StoreName { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
