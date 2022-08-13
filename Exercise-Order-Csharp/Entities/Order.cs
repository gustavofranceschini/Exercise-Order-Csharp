using System;
using System.Collections.Generic;
using Exercise_Order_Csharp.Entities.Enums;
using System.Text;
using System.Globalization;

namespace Exercise_Order_Csharp.Entities
{
    class Order
    {
        CultureInfo CI = CultureInfo.InvariantCulture;

        public DateTime Moment { get; private set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
      

        public Order()
        {
        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double Total()
        {
            double sum = 0.0;
            foreach(OrderItem item in Items)
            {
                sum += item.SubTotal();
            }
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach(OrderItem item in Items)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("Total price: RS " + Total().ToString("F2", CI));
            return sb.ToString();
        }



    }
}
