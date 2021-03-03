using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaParadise.Library
{
    public class Product
    {
        private int productId;
        private string productName;
        private decimal price;
        public Product(string name, decimal p)
        {
            productName = name;
            price = p;
        }
        public Product(int id, string name, decimal p)
        {
            productId = id;
            productName = name;
            Price = p;
        }
        public Product(int id, string name)
        {
            productId = id;
            productName = name;
        }

        public Product(string name)
        {
            productName = name;
        }
        public Product()
        {
        }
        public int ProductId
        {
            get => productId;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Id must be greater than 0", nameof(value));
                }
                productId = value;
            }
        }
        public string ProductName
        {
            get => productName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Product name must not be empty.", nameof(value));
                }
                productName = value;
            }
        }
        public decimal Price
        {
            get => price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price must be greater than 0", nameof(value));
                }
                price = value;
            }
        }
    }
}
