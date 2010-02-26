using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CAE.src.data;

namespace CAE.src_test.data
{
    public class DatabaseRetrievalTestHarnessListProjects
    {
        /// <summary>
        /// Main entry point.
        /// </summary>
        public static void Main()
        {
            // call DatabaseReader method ListModules to return a list of all project:
            DataSet myDataSet = DatabaseReader.ListProjects();
            Console.WriteLine("Retrieving rows from the List Projects Procedure");
            
            // result set returned from Stored Procedure ends up in the DataSet's DataTable:
            DataTable myDataTable = myDataSet.Tables["list_projects"];
            
            // loop through DataRows of the DataTable pulling off the fields you need
            // by name within square brackets:
            foreach (DataRow myDataRow in myDataTable.Rows)
            {
                Console.WriteLine("ProjectName = " + myDataRow["project_nm"]);
                Console.WriteLine("Project Decription = " + myDataRow["project_desc"]);
            }
        }
    }
}
