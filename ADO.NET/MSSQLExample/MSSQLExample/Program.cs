using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MSSQLExample
{
    class Program
    {
        static void Main(string[] args)
        {
            //Call function for read data from db to List<Employee>
            var data = ReadFromBase();
            foreach (var employee in data)
            {
                Console.WriteLine(employee);
            }
        }

        private static List<Employee> ReadFromBase()
        {
            //read string from app.config file with key "ConnectionString"
            var conString = ConfigurationManager.AppSettings["ConnectionString"];
            //create list for save data from db and return as result of function
            List<Employee> dataFromDb = new List<Employee>();

            //create and use connection to SQL db
            using (var connection = new SqlConnection(conString))
            {
                //create command text whith we will use in SQLCommand
                string commandText = @"SELECT DISTINCT
                                      e.ID, e.Name, e.Birthday, e.Email, e.PositionID, DepartmentID
                                    FROM
                                      Employees e
                                    WHERE 
                                      LEN(e.Name) > @len";
                //create SqlCommand with early entered text and connection
                var command = new SqlCommand(commandText, connection);
                //create parameter for our command
                var parameter = new SqlParameter("@len", SqlDbType.Int);
                //set parameter value
                parameter.Value = 2;
                //add created parameter to command
                command.Parameters.Add(parameter);
                //open sql connection
                connection.Open();
                //execute and using reader for get results of command executing
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    //read data from reader
                    while (reader.Read())
                    {
                        //create new Employee from db data
                        var item = new Employee
                        {
                            Id = int.Parse(reader[0].ToString()),
                            Name = reader[1].ToString(),
                            //check if data in column "e.Birthday" not null. If it is true - return new DateTime()
                            BirthDay = reader[2].GetType() != typeof(DBNull)
                                ? Convert.ToDateTime(reader[2])
                                : new DateTime(),
                            Email = reader[3].GetType() != typeof(DBNull)
                                ? reader[3].ToString()
                                : String.Empty,
                            PositionId = int.Parse(reader[4].ToString()),
                            DepartmentId = int.Parse(reader[5].ToString()),
                        };
                        //add created employee to result list
                        dataFromDb.Add(item);
                    }
                }
            }
            //return result list
            return dataFromDb;
        }
    }

    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDay { get; set; }
        public string Email { get; set; }
        public int PositionId { get; set; }
        public int DepartmentId { get; set; }
        public override string ToString()
        {
            return $"{Id} {Name} {BirthDay} {Email} {PositionId} {DepartmentId}";
        }
    }
}