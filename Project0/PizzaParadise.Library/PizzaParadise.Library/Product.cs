using System;

namespace PizzaParadise.Library
{
    public class Item
    {
        private string itemName;
        private int amount;
        private int price;

        public string ItemName
        {
            get{return itemName;}
            set{itemName = value;}
        }
        public int Amount
        {
            get{return amount;}
            set{amount = value;}
        }

        public int Price
        {
            get { return price; }
            set { price = value; }
        }

        public Item(string name, int num, int p)
        {
            itemName = name;
            amount = num;
            price = p;
        }
    }
}
