using System;

namespace PizzaParadise.Library
{
    public class Customer
    {
        private string firstName;

        private string lastName;
        public int CustomerId { get; set; }

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
    }
}
