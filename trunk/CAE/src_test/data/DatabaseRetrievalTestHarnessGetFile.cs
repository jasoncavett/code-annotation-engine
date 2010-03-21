using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CAE.src.data;

namespace CAE.src_test.data
{
    public class DatabaseRetrievalTestHarnessGetFile
    {
        public static void Main()
        {
            // declare variables needed by DatabaseReader method GetModule
            // these would normally be variables, not literals:
            string project_nm = "order_mgt";
            string codefile_nm = "java_main";

            // call DatabaseReader method GetFile to return data for a specific codefile for a project:
            DataSet myDataSet = DatabaseReader.GetFile(project_nm, codefile_nm);
            Console.WriteLine("Retrieving a row from the Get File Procedure");

            // result set returned from Stored Procedure ends up in the DataSet's DataTable:
            DataTable myDataTable = myDataSet.Tables["get_file"];

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