using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CAE.src.data;

namespace CAE.src_test.data
{
    public class DatabaseWriterTestHarnessAddProject
    { 
        public static void Main()
        {
            string project_nm = "another_project";
            string project_desc = "This is a Second Project added through the App";
            // call DatabaseWriter method AddProject to return data for a specific project:
            StringBuilder errorMessages = DatabaseWriter.AddProject(project_nm, project_desc);
            Console.WriteLine("Adding a row using the Add Project Procedure \n");
            Console.WriteLine(errorMessages.ToString());
        }
    }
}
