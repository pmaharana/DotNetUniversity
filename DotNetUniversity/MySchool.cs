using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetUniversity
{
    class MySchool
    {
        public string Course { get; set; }
        public int CourseNumber { get; set; }
        public string Instructor { get; set; }
        public string Department { get; set; }

        public MySchool()
        {

        }

        public MySchool(SqlDataReader reader)
        {
            Course = reader[0].ToString();
            CourseNumber = (int)reader[1];
            Instructor = reader[2].ToString();
            Department = reader[3].ToString();
            
        }
    }
}
