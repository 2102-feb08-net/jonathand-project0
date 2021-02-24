using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaParadise.Library
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ItemName { get; set; }
        public double Price { get; set; }
        public Product()
        {
        }

        public Product(string name, double p)
        {
            ItemName = name;
            Price = p;
        }
    }
}
