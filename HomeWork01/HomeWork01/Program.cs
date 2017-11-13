using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork01
{
    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product(1, 100.5, "Iphone X");
            Console.WriteLine(product);
            product.Id = 10;
            product.Name = "Samsung";
            Console.WriteLine(product);
            Console.WriteLine($"Id: {product.Id}, Name: {product.Name}, Price: {product.Price}");
        }
    }
}
