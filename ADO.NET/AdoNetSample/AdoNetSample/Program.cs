using System;
using System.Data.SqlClient;

namespace AdoNetSample
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = @"Data Source= (localdb)\MSSQLLocalDB; 
            Initial Catalog = SqlEntry; Integrated Security = SSPI;";

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(@"select * from books", connection);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader[0]} {reader[1]}");
                    }
                }
            }
        }
    }
}
