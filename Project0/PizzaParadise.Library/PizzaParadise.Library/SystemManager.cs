using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaParadise.Library
{
    public class Database
    {
        public List<Store> StoreList { get; set; }

        public Database()
        {
            StoreList = new List<Store>(5);
        }
    }
}
