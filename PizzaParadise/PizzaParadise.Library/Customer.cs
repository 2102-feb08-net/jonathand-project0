using System;
using System.Collections.Generic;

namespace PizzaParadise.Library
{
    public class Customer
    {
        public int CustomerId { get; set; }
        private string firstName;

        private string lastName;

        //public Customer(string fName, string LName)
        //{
        //    CustomerId = 0;
        //    firstName = fName;
        //    lastName = LName;
        //}

        public string FirstName
        {

            get => firstName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("First name must not be empty.", nameof(value));
                }
                firstName = value;
            }
        }
        public string   LastName
        {

            get => lastName;
            set
            {
                if (value.Length == 0)
                {
                    throw new ArgumentException("Last name must not be empty.", nameof(value));
                }
                lastName = value;
            }
        }

        public List<Order> customerOrders { get; set; } = new List<Order>();
    }
}
