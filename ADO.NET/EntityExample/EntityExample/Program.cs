using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityExample
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             1. database first
             2. model first
             3. code first
             */
            using (var context = new FactoryDbContext())
            {

                var orders = context.Orders.Include(c => c.IdClient).ToList();

                foreach (var order in orders)
                {
                    Console.WriteLine($"{order.IdClient.FirstName} {order.Value}");
                    //Console.WriteLine($"{client.Value} {client.IdClient.FirstName}");
                }
                

                //foreach (var client in context.Clients)
                //{
                //    Console.WriteLine(
                //        $"{client.FirstName} {client.LastName} " +
                //        $"{client.RegisterDate.ToShortDateString()}");
                //}

            }
        }
    }
}
