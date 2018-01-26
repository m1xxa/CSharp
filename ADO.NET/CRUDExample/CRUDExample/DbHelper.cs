using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CRUDExample
{


    public static class DbHelper
    {
        public static List<Product> ManageDb(string conString, string dbName)
        {
            List<Product> listOfProducts = new List<Product>();
            while (true)
            {
                bool isExit = false;
                Console.WriteLine("Please select number of following command:");
                Console.WriteLine("1. Create table");
                Console.WriteLine("2. Drop table");
                Console.WriteLine("3. Add record to table");
                Console.WriteLine("4. Get all records");
                Console.WriteLine("5. Exit program");

                int.TryParse(Console.ReadLine(), out int choise);
                string dataQuerry = string.Empty;

                using (var connection = new SqlConnection(conString))
                {
                    connection.Open();

                    switch (choise)
                    {
                        case 1:
                            dataQuerry = $@"
                                USE {dbName}
                                IF object_id('Products') IS NULL 
                                CREATE TABLE Products(
                                Id INT IDENTITY(1,1) NOT NULL CONSTRAINT PK_Products PRIMARY KEY,
                                Name NVARCHAR(80) NOT NULL,
                                Definition NVARCHAR(300),
                                Picture NVARCHAR(300))";

                            var createCommand = new SqlCommand(dataQuerry, connection);
                            createCommand.ExecuteNonQuery();
                            break;

                        case 2:
                            dataQuerry = $@"
                                USE {dbName}
                                IF object_id('Products') IS NOT NULL 
                                DROP TABLE Products";

                            var dropCommand = new SqlCommand(dataQuerry, connection);
                            dropCommand.ExecuteNonQuery();
                            break;

                        case 3:
                            Product product = new Product();
                            Console.Write("Name: ");
                            product.Name = Console.ReadLine();
                            Console.Write("Definition: ");
                            product.Definition = Console.ReadLine();
                            Console.Write("Picture URL: ");
                            product.Picture = Console.ReadLine();

                            dataQuerry = $@"
                                USE {dbName}
                                IF object_id('Products') IS NOT NULL 
                                INSERT Products(Name, Definition, Picture)
                                VALUES(N'{product.Name}', N'{product.Definition}', N'{product.Picture}')";

                            var addCommand = new SqlCommand(dataQuerry, connection);
                            addCommand.ExecuteNonQuery();
                            break;

                        case 4:
                            dataQuerry = $@"
                                USE {dbName}
                                IF object_id('Products') IS NOT NULL 
                                SELECT * FROM Products";

                            var getCommand = new SqlCommand(dataQuerry, connection);

                            using (SqlDataReader reader = getCommand.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var item = new Product
                                    {
                                        Id = int.Parse(reader[0].ToString()),
                                        Name = reader[1].ToString(),
                                        Definition = reader[2].ToString(),
                                        Picture = reader[3].ToString(),
                                    };
                                    listOfProducts.Add(item);
                                }

                                foreach (var currentProduct in listOfProducts)
                                {
                                    Console.WriteLine($"{currentProduct.Id} {currentProduct.Name} {currentProduct.Definition} {currentProduct.Picture}");
                                }
                            }

                            break;
                        case 5:
                            isExit = true;
                            break;
                    }

                    if (isExit) break;
                }
            }
            return listOfProducts;
        }

        public static string CreateDb(string conString)
        {
            string dbName = "";
            Console.WriteLine("Do you want create new base? (Yes/No)");
            bool isCreateNew = false;
            while (true)
            {
                string answer = Console.ReadLine()?.ToLower();
                switch (answer)
                {
                    case "yes":
                        isCreateNew = true;
                        break;
                    case "no":
                        isCreateNew = false;
                        break;
                    default:
                        Console.WriteLine("Wrong command, try again");
                        continue;
                }
                break;
            }

            if (isCreateNew)
            {
                Console.WriteLine("Please enter the name of database");
                dbName = Console.ReadLine();
                
                using (var connection = new SqlConnection(conString))
                {
                    var querry = $@"CREATE DATABASE {dbName}";
                    var command = new SqlCommand(querry, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    querry = $@"USE {dbName}";
                    command = new SqlCommand(querry, connection);
                    command.ExecuteNonQuery();
                }

            }
            else
            {
                Console.WriteLine("Please, enter the name of existing database");

                while (true)
                {
                    dbName = Console.ReadLine();
                    using (var connection = new SqlConnection(conString))
                    {
                        connection.Open();
                        var querry = $@"USE {dbName}";
                        var command = new SqlCommand(querry, connection);
                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (SqlException)
                        {
                            Console.WriteLine($"Database {dbName} doesent exist, try again");
                            continue;
                        }
                        break;
                    }
                }
            }
            return dbName;
        }
    }
}