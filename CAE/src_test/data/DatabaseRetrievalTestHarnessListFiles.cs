using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CAE.src.data;

namespace CAE.src_test.data
{
    public class DatabaseRetrievalTestHarnessListFiles
    {
        /// <summary>
        /// Main entry point.
        /// </summary>
        public static void Main()
        {
            // declare variables needed by DatabaseReader method ListFiles
            // these would normally be variables, not literals:
            string project_nm = "order_mgt";

            // call DatabaseReader method ListModules to return a list of all codefiles for a project:
            DataSet myDataSet = DatabaseReader.ListFiles(project_nm);
            Console.WriteLine("Retrieving rows from the List Files Procedure");
            
            // result set returned from Stored Procedure ends up in the DataSet's DataTable:
            DataTable myDataTable = myDataSet.Tables["list_files"];
            
            // loop through DataRows of the DataTable pulling off the fields you need
            // by name within square brackets:
            foreach (DataRow myDataRow in myDataTable.Rows)
            {
                Console.WriteLine("ProjectName = " + myDataRow["project_nm"]);
                Console.WriteLine("CodefileName = " + myDataRow["codefile_nm"]);
            }
        }
    }
}
