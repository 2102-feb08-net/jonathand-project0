using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Xml.Serialization;
using Microsoft.EntityFrameworkCore;
using PizzaParadise.DAL;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
//using RestaurantReviews.Library.Interfaces;
//using RestaurantReviews.Library.Models;
//using NLog;


namespace PizzaParadise.ConsoleUI
{
    class Program
    {
        static DbContextOptions<ChinookNumberTwoContext> contextOptions;
        static void Main(string[] args)
        {
            using var logStream = new StreamWriter("ef-logs.txt", append: false) { AutoFlush = true };
            string connectionString = File.ReadAllText("C:/revature/pizzaappcs.txt");
            contextOptions = new DbContextOptionsBuilder<ChinookNumberTwoContext>()
                .UseSqlServer(connectionString)
                .LogTo(logStream.WriteLine, minimumLevel: LogLevel.Information)
                .LogTo(s => Debug.WriteLine(s), minimumLevel: LogLevel.Debug)
                .Options;

            using var context = new ChinookNumberTwoContext(contextOptions);

            DisplayOrderDetails(1);
    
        }

        static void DisplayCustomers()
        {
            using var context = new ChinookNumberTwoContext(contextOptions);
            
            IQueryable<Customer> entries = context.Customers
                .Include(x => x);

            Console.WriteLine("Current Customers");
            foreach(Customer c in entries)
            {
                Console.WriteLine($"{c.FirstName} {c.LastName}");
            }
        }

        static void AddNewCustomer(string fName, string lName)
        {
            using var context = new ChinookNumberTwoContext(contextOptions);


            var entry = new Customer
            {
                FirstName = fName,
                LastName = lName
            };


            context.Add(entry);

            context.SaveChanges();

            // EF frees us from having to worry about foreign key values

            //context.Tracks.Add(track);

            // this not only will see the Genre and insert it as well, with the right foreign key value on the Track...
            context.SaveChanges();
        }

       //static void PlaceOrder()
       // {
       //     using var context = new ChinookNumberTwoContext(contextOptions);
       //     Console.WriteLine("What is the Customer ID");
       //     int customerId = int.Parse(Console.ReadLine());
            
       //     Console.WriteLine("What is the Store ID");
       //     int storeId = int.Parse(Console.ReadLine());

       //     bool buyMore = true;
       //     do
       //     {
       //         Console.WriteLine("What would you like to buy?");
       //         Console.WriteLine("Menu");
       //         IQueryable<Product> entries = context.Products
       //         .Include(x => x);

       //         foreach(Product p in entries)
       //         {
       //             Console.WriteLine($"Choice {p.ProductId}    {p.ProductName}");
       //         }
       //         int choice = int.Parse(Console.ReadLine());
                   
                 

       //     } while (buyMore);
       // }
        static void DisplayOrderDetails(int Id)
        {
            using var context = new ChinookNumberTwoContext(contextOptions);
            IQueryable<OrderLine> entries = context.OrderLines
                .Include(o => o.Order)
                .Where(o => o.OrderId == Id)
                .OrderBy(o => o.OrderLineId);

            var first = entries.First();
            var last = entries.Last();

            string Name = first.Order.Customer.FirstName + " " + first.Order.Customer.LastName;

            Console.WriteLine($"Order {Id}");
            foreach (OrderLine currentOrder in entries)
            {
                if(currentOrder == first)
                {
                    Console.WriteLine($"Time: {currentOrder.Order.OrderDate}");
                    Console.WriteLine($"Customer: {Name}");
                    Console.WriteLine($"Product: {currentOrder.Product.ProductName}");
                }
                else if (currentOrder == last)
                {
                    Console.WriteLine($"Product: {currentOrder.Product.ProductName}");
                    Console.WriteLine($"Total Cost: {currentOrder.Order.OrderTotal}");
                }    
                else
                {
                    Console.WriteLine($"Product: {currentOrder.Product.ProductName}");
                }
            }
        }

    }
}
