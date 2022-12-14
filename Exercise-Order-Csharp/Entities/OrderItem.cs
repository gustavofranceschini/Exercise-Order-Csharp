using System;
using System.Globalization;

namespace Exercise_Order_Csharp.Entities
{
    class OrderItem
    {
        CultureInfo CI = CultureInfo.InvariantCulture;

        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product Product { get; set; }

        public OrderItem()
        {
        }

        public OrderItem(int quantity, double price, Product product)
        {
            Quantity = quantity;
            Price = price;
            Product = product;
        }

        public double SubTotal()
        {
            return Quantity * Price;
        }

        public override string ToString()
        {
            return Product.Name
                + ", R$ "
                + Price.ToString("F2", CI)
                + ", Quantity: "
                + Quantity
                + ", Subtotal: R$ "
                + SubTotal().ToString("F2", CI);
        }
    }
}
