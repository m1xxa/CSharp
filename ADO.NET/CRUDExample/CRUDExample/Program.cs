using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var conString = ConfigurationManager.AppSettings["ConnectionString"];
            string dbName = DbHelper.CreateDb(conString);
            List<Product> listOfProducts  = DbHelper.ManageDb(conString, dbName);
            
            foreach (var currentProduct in listOfProducts)
            {
                Console.WriteLine($"{currentProduct.Id} {currentProduct.Name} {currentProduct.Definition} {currentProduct.Picture}");
            }
        }

      
    }
    
}
