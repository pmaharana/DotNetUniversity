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
        static public List<MySchool> GetCourseInfo(SqlConnection connection)
        {
            var courses = new List<MySchool>();
            var sqlCommand = new SqlCommand(
                        @"select Courses.Title, Courses.CourseNumber, Instructor.Name, Department.Name
                        from Courses
                        join Instructor on Instructor.Id = Courses.Instructor
                        join Department on Instructor.DeptId = Department.DeptCode"
                          , connection);
            connection.Open();
            var reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                var course = new MySchool(reader);
                courses.Add(course);
            }
            connection.Close();
            return courses;
        }

        static void Main(string[] args)
        {
            //the database path 
            const string connectionString =
                @"Server=localhost\SQLEXPRESS;Database=DotNetUniversity;Trusted_Connection=True;";

            var courses = new List<MySchool>();
            using (var connection = new SqlConnection(connectionString))
            {
                courses = GetCourseInfo(connection);
            }

            foreach (var item in courses)
            {
                Console.WriteLine("Course Name: " + item.Course + "                    Name of professor: " + item.Instructor);
            }





            //Console.WriteLine("Hello, welcome to Dot Net Academy. Are you interested in enrolling?");
            //var enrolling = Console.ReadLine();

            //if (enrolling == "yes")
            //{
            //    Console.WriteLine("Very well, here is a list of the courses we offer");
            //    Console.WriteLine("");

            ////open with using statement
            //using (var connection = new SqlConnection(connectionString))
            //{

            //    //queries the result from SQL, all courses and instructor teaching the class
            //    var sqlCommand = new SqlCommand(
            //        @"select Courses.Title, Courses.CourseNumber, Instructor.Name 
            //            from Courses 
            //            join Instructor on Instructor.Id = Courses.Instructor" 
            //                    ,connection);
            //    //Opens connection
            //    connection.Open();
            //    //while the reader reads, write out the sql query results
            //    var reader = sqlCommand.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        Console.WriteLine("Course Name: " + reader[0] + " Course Number: " + reader[1] + " Instructor: " + reader[2]);


            //    }
            //    Console.ReadLine();
            //    connection.Close();
            //}

            //}

            using (var connection = new SqlConnection(connectionString))
            {

                //queries the result from SQL, all courses and instructor teaching the class
                var sqlCommand = new SqlCommand(
                                @"select count(Distinct Instructor.Name), count(Courses.Title)
                                from Courses
                                Join Instructor on Instructor.Id = Courses.Instructor"
                                , connection);
                //Opens connection
                connection.Open();
                //while the reader reads, write out the sql query results
                var reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine("Total number of teachers: " + reader[0] + " Total number of Classes: " + reader[1]);
                    Console.WriteLine("");
                }
                Console.ReadLine();
                connection.Close();

            }







        }
    }
}
