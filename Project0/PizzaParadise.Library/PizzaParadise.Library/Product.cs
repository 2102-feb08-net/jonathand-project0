using System;

namespace PizzaParadise.Library
{
    public class Product
    {
        public string ItemName { get; set; }
        public int Amount { get; set; }
        public double Price { get; }


        public Product(string name, int num, double p)
        {
            ItemName = name;
            Amount = num;
            Price = p;
        }
    }
}
