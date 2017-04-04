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

                var sqlCommand = new SqlCommand(
                    @"select Courses.Title, Courses.CourseNumber, Instructor.Name 
                        from Courses 
                        join Instructor on Instructor.Id = Courses.Instructor" 
                                ,connection);


                                                    






                connection.Open();
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("Course Name: " + reader[0] + " Course Number: " + reader[1] + " Instructor: " + reader[2]);
                }
                Console.ReadLine();
                connection.Close();

            }

        }
    }
}
