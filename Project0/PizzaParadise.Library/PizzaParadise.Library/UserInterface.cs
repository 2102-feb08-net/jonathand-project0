using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaParadise.Library
{
    public class UserInterface
    {
        static void Main()
        {
            Console.WriteLine("What is the customer's name? ");
            string first = Console.ReadLine();
            string last = Console.ReadLine();
            Customer one = new Customer(first, last);
            Console.WriteLine($"{first} {last}");
        }
    }
}
