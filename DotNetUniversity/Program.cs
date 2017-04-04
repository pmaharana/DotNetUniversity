using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetUniversity
{
    class Program
    {
        static void Main(string[] args)
        {
            //the database path 
            const string connectionString =
                @"Server=localhost\SQLEXPRESS;Database=DotNetUniversity;Trusted_Connection=True;";

            //open with using statement
            using (var connection = new SqlConnection(connectionString))
            {
                
                var sqlCommand = new SqlCommand(@"select * from Courses", connection);
                connection.Open();
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader["Title"] + "--" + reader["CourseNumber"]);
                }
                
                connection.Close();

            }

        }
    }
}
