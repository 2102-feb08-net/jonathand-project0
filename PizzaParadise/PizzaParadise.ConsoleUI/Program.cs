using System;
using System.Collections.Generic;
using PizzaParadise.DAL;
using PizzaParadise.Library;


namespace PizzaParadise.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository r = new();
            startUI(r);
        }

        static void PlaceOrder(Repository r)
        {
            Console.WriteLine("Enter Customer ID");
            int customerId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Store ID");
            int storeId = int.Parse(Console.ReadLine());
            r.CreateOrder(customerId,storeId);
            bool buyMore = true;
            do
            {
                Console.WriteLine("Enter Product Choice");
                Console.WriteLine("Menu");

                List<DAL.Product> products = r.GetAllProducts();
                foreach (DAL.Product p in products)
                {
                    Console.WriteLine($"Choice {p.ProductId}    {p.ProductName}");
                }
                int id = int.Parse(Console.ReadLine());

                DAL.Product product = r.GetProductById(id);
                Console.WriteLine("Enter Quantity");
                int quantity = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Cost");
                decimal cost = decimal.Parse(Console.ReadLine());

                r.AddProductToOrder(product, cost, quantity);
                r.AddTotalToOrder();

                Console.WriteLine("Continue Order? Select y or n");
                string selector = Console.ReadLine();
                if (selector == "n")
                {
                    buyMore = false;
                }

            } while (buyMore);
        }

        static void DisplayStoreOrders(Repository r, int storeId)
        {
            List<DAL.Order> storeOrders = r.GetOrdersByLocation(storeId);
            Console.WriteLine($"Store {storeId} Orders\n");
            foreach(DAL.Order o in storeOrders)
            {
                Console.WriteLine($"Order {o.OrderId}");
                DisplayOrderDetailsByOrder(r, o);
            }
        }
        static void DisplayCustomerOrders(Repository r, int customerId)
        {
            List<DAL.Order> customerOrders = r.GetCustomerOrdersById(customerId);
            Console.WriteLine($"{ r.GetCustomerNameById(customerId)} Orders\n");
            foreach (DAL.Order o in customerOrders)
            {
                Console.WriteLine($"Order {o.OrderId}");
                DisplayOrderDetailsByOrder(r, o);
            }
        }
        static void DisplayOrderDetailsByOrder(Repository r, DAL.Order o)
        {
            List<DAL.OrderLine> orders = r.GetOrderDetailsByOrderId(o.OrderId);
            Console.WriteLine($"Customer Name: {r.GetCustomerNameById(o.CustomerId)}");
            Console.WriteLine($"Date: {o.OrderTime}\n");
            Console.WriteLine("Order Details\n");
            Console.WriteLine("Menu Item     Quantity     Price");
            foreach (DAL.OrderLine entry in orders)
            {
                Console.WriteLine($"{r.GetProductById(entry.ProductId).ProductName} " +
                    $"{entry.Quantity} {entry.ProductPrice}");
            }
            Console.WriteLine();
            Console.WriteLine($"Total: ${(double)o.OrderTotal}");
        }

        static void DisplayLastOrderDetails(Repository r)
        {
            DAL.Order last = r.GetLastOrder();
            List<DAL.OrderLine> o = r.GetLastOrderDetails();
            Console.WriteLine($"Customer Name: {r.GetCustomerNameById(last.CustomerId)}");
            Console.WriteLine($"Date: {last.OrderTime}\n");
            Console.WriteLine("Order Details\n");
            Console.WriteLine("Menu Item     Quantity     Price");
            foreach (DAL.OrderLine entry in o)
            {
                Console.WriteLine($"{r.GetProductById(entry.ProductId).ProductName} " +
                    $"{entry.Quantity} {entry.ProductPrice}");
            }
            Console.WriteLine();
            Console.WriteLine($"Total: ${(double)last.OrderTotal}");
        }
        static void DisplayCustomers(Repository r)
        {
            List<DAL.Customer> c = r.GetAllCustomers();

            Console.WriteLine("Current Customers");
            foreach (DAL.Customer entry in c)
            {
                Console.WriteLine($"{entry.FirstName} {entry.LastName}");
            }
        }

        static void startUI(Repository r)
        {
            Console.WriteLine("Welcome to Pizza Paradise!");
            Console.WriteLine("Enter the Customer's First Name ");
            string fName = Console.ReadLine();
            Console.WriteLine("Enter the Customer's Last Name? ");
            string lName = Console.ReadLine();
            Library.Customer c = new(fName,lName);
            r.AddCustomer(c);
            Console.WriteLine("Here's the new Customer List");
            DisplayCustomers(r);
            PlaceOrder(r);
            DisplayLastOrderDetails(r);
            Console.WriteLine("What Store's Order would you like to see?");
            int store = int.Parse(Console.ReadLine());
            DisplayStoreOrders(r, store);
            Console.WriteLine("What Customer's Order would you like to see?");
            int customer = int.Parse(Console.ReadLine());
            DisplayCustomerOrders(r, customer);
        }
    }
}
