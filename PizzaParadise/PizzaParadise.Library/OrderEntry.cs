using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParadise.Library
{
    public class OrderEntry
    {
        public int OrderLineId { get; set; }

        public Product ProductEntry { get; set; }
        public double ProductPrice { get; set; }

        public int Quantity { get; set; }

        //public OrderEntry(Product entry, double price, int amount)
        //{
        //    OrderLineId = 0;
        //    ProductEntry = entry;
        //    ProductPrice = price;
        //    Quantity = amount;
        //}

    }
}
