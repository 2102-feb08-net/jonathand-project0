using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParadise.Library
{
    public class InventoryEntry
    {

        public Product EntryProduct { get; set; }
        public int Quantity { get; set; }
        public InventoryEntry()
        {           

        }

        public InventoryEntry(Product p, int q)
        {
            EntryProduct = p;
            Quantity = q;     
        }
    }
}
