using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaParadise.Library
{
    public class Customer
    {
        public string FirstName { get; }
        public string LastName { get; }

        public Customer(string fName, string lName)
        {
            FirstName = fName;
            LastName = lName;
        }
    }
}
