//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Security;
//using System.Xml.Serialization;
//using Microsoft.EntityFrameworkCore;
//using PizzaParadise.DAL;
//using Microsoft.Extensions.Logging;
//using System.Diagnostics;



//THIS IS BROKEN

//namespace PizzaParadise.ConsoleUI
//{
//    class Console
//    {
//        static DbContextOptions<ChinookNumberTwoContext> contextOptions;
//        static void Main(string[] args)
//        {
//            using var logStream = new StreamWriter("ef-logs.txt", append: false) { AutoFlush = true };
//            string connectionString = File.ReadAllText("C:/revature/pizzaappcs.txt");
//            contextOptions = new DbContextOptionsBuilder<ChinookNumberTwoContext>()
//                .UseSqlServer(connectionString)
//                .LogTo(logStream.WriteLine, minimumLevel: LogLevel.Information)
//                .LogTo(s => Debug.WriteLine(s), minimumLevel: LogLevel.Debug)
//                .Options;

//            using var context = new ChinookNumberTwoContext(contextOptions);

//            //DisplayOrderDetails(1);
//            startUI();


//        }

//        static void startUI()
//        {
//            Console.WriteLine("Welcome to Pizza Paradise!");
//            Console.WriteLine("Enter the Customer's First Name ");
//            string fName = Console.ReadLine();
//            Console.WriteLine("Enter the Customer's Last Name? ");
//            string lName = Console.ReadLine();

//            AddNewCustomer(fName, lName);
//            Console.WriteLine("Here's the new Customer List");
//            DisplayCustomers();

//            bool moreOrders = true;
//            do
//            {
//                Console.WriteLine("Would you like to place on order? Press y or n");
//                string answer = Console.ReadLine();
//                if (answer == "y")
//                {
//                    PlaceOrder();
//                }
//                else
//                {
//                    moreOrders = false;
//                }
//            }
//        }
//        static void DisplayCustomers()
//        {
//            using var context = new ChinookNumberTwoContext(contextOptions);

//            IQueryable<Customer> entries = context.Customers
//                   .Select(x => x);

//            Console.WriteLine("Current Customers");
//            foreach (Customer c in entries)
//            {
//                Console.WriteLine($"{c.FirstName} {c.LastName}");
//            }
//        }

//        static void AddNewCustomer(string fName, string lName)
//        {
//            using var context = new ChinookNumberTwoContext(contextOptions);


//            var entry = new Customer
//            {
//                FirstName = fName,
//                LastName = lName
//            };


//            context.Add(entry);

//            context.SaveChanges();

//        }

//        static void PlaceOrder()
//        {
//            using var context = new ChinookNumberTwoContext(contextOptions);
//            Console.WriteLine("Enter Customer ID");
//            int customerId = int.Parse(Console.ReadLine());

//            Console.WriteLine("Enter Store ID");
//            int storeId = int.Parse(Console.ReadLine());



//            bool buyMore = true;
//            do
//            {
//                Console.WriteLine("Enter Product Choice");
//                Console.WriteLine("Menu");
//                IQueryable<Product> entries = context.Products
//                .Select(x => x);

//                foreach (Product p in entries)
//                {
//                    Console.WriteLine($"Choice {p.ProductId}    {p.ProductName}");
//                }
//                int id = int.Parse(Console.ReadLine());

//                Product _product = new Product();

//                foreach (Product p in entries)
//                {
//                    if (p.ProductId == id)
//                    {
//                        _product = p.ProductName;
//                    }
//                }


//                Console.WriteLine("Enter Quantity");
//                int quantity = int.Parse(Console.ReadLine());
//                Console.WriteLine("Enter Cost");
//                int cost = int.Parse(Console.ReadLine());
//                Order o = new Order
//                {
//                    CustomerId = customerId,
//                    StoreId = storeId,
//                }

//                var entry = new OrderLine
//                {
//                    ProductId = id,
//                    Product = _product,
//                    ProductPrice = price,
//                    Quantity = quantity
//                    Order = o;
//                }


//                context.Add(entry);
//                context.SaveChanges
                
//                Console.WriteLine("Does the Customer want anything else? Press y or n")
//                string answer = Console.ReadLine();
//                if (answer == "y")
//                {
//                    buyMore = true;
//                }   
//                else
//                {
//                buyMore = false;
//                }

//            }while(buyMore);
//        }
//    static void DisplayOrderDetails(int Id)
//    {
//        using var context = new ChinookNumberTwoContext(contextOptions);
//        IQueryable<OrderLine> entries = context.OrderLines
//            .Include(or => or.Order)
//            .Where(o => o.OrderId == Id)
//            .OrderBy(o => o.OrderLineId);

//        OrderLine first = entries.First();
//        OrderLine last = entries.Last();



//        Console.WriteLine($"Order {Id}");
//        foreach (OrderLine currentOrder in entries)
//        {
//            if (currentOrder == first)
//            {
//                Console.WriteLine($"Time: {currentOrder.Order.OrderTime}");
//                Console.WriteLine($"Customer: { currentOrder.Order.Customer.FirstName } " +
//                    $" { currentOrder.Order.Customer.LastName}");
//                Console.WriteLine($"Product: {currentOrder.Product.ProductName}");
//            }
//            else if (currentOrder == last)
//            {
//                Console.WriteLine($"Product: {currentOrder.Product.ProductName}");
//                Console.WriteLine($"Total Cost: {currentOrder.Order.OrderTotal}");
//            }
//            else
//            {
//                Console.WriteLine($"Product: {currentOrder.Product.ProductName}");
//            }
//        }
//    }

//}
//}
