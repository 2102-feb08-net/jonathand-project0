using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParadise.Library
{
    public class Order
    {
        public int OrderId { get; set; }
        //public Store OrderStore { get; }
        //public Customer OrderCustomer { get; set; }
        public List<OrderEntry> OrderEntries { get; set; }

        public DateTimeOffset OrderTime { get; set; }

        //public Order(Store oStore, Customer oCustomer)
        //{
        //    OrderId = 0;
        //    OrderStore = oStore;
        //    OrderCustomer = oCustomer;
        //    OrderTime = DateTime.Now;
        //    OrderEntries = new List<OrderEntry>();
        //}
        
        public double OrderTotal
        {
            get
            {
                double total = 0.0;
                foreach(OrderEntry entry in OrderEntries)
                {
                    total += entry.ProductPrice * entry.Quantity;
                }
                return total;
            }
        }
        //public void AddOrderLine(Product newProduct, double price, int quantity)
        //{
        //    var lineItem = new OrderEntry(newProduct, price, quantity);
        //    OrderEntries.Add(lineItem);
        //}

    }
}
