using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionAndAttrDemo.stepbystep
{
    internal class Product
    {
        public string Name { set; get; }
        public int Stock { set; get; }
        public double price { set; get; }

        public Product() { }

        public Product(string name, int stock, double price)
        {
            Name = name;
            Stock = stock;
            this.price = price;
        }

        public void DecreaseStock(int stock)
        {
            this.Stock -= stock;
        }

        public void display()
        {
            Console.WriteLine($"{Name} {Stock} {price}");
        }

        public override string? ToString()
        {
            return $"{Name} {Stock} {price}";
        }
    }
}
