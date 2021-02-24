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
            //IQueryable<Inventory> s = context.Inventories
            //    .Select(x => x);
            //List<Store> products = s.ToList();

            //IQueryable<Inventory> i = context.Inventories
            //    .Include(i => i.Product)
            //    .Include(i => i.Store)
            //    .Where(i => i.StoreId == 1)
            //    .OrderBy(i => i.InventoryLineId);

            //List<Inventory> storeOne = i.ToList();
            //Console.WriteLine("Here is the Initial Inventory for Store 1, as well as the other stores");
            //foreach(Inventory inv in storeOne)
            //{
            //    Console.WriteLine($"Product: {inv.Product.ProductName}  Quantity: {inv.Quantity}");
            //}
        }

        //static void DisplayCustomers()
        //{

        //}
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
