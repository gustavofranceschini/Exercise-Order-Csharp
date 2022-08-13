using Exercise_Order_Csharp.Entities.Enums;
using System;
using Exercise_Order_Csharp.Entities;
using System.Globalization;

namespace Exercise_Order_Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo CI = CultureInfo.InvariantCulture;

            Console.WriteLine("Enter cliente data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter order data:");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());

            Client client = new Client(name, email, birthDate);
            Order st = new Order(DateTime.Now, status, client);

            Console.Write("How many items to this order? ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Enter #{i} item data:");
                Console.Write("Product name: ");
                string nameProduct = Console.ReadLine();
                Console.Write("Product price: R$ ");
                double price = double.Parse(Console.ReadLine(),CI);
                Console.Write("Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Product product = new Product(nameProduct, price);
                OrderItem orderItem = new OrderItem(quantity, price, product);
                st.AddItem(orderItem);
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("ORDER SUMMARY:");
            Console.WriteLine("Order moment: "+st.Moment);
            Console.WriteLine("Order status: "+st.Status);
            Console.WriteLine("Client: "+client.Name+" ("+client.BirthDate.ToShortDateString()+") - "+client.Email);
            Console.WriteLine(st);
            
            
        }
    }
}
