using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CAE.src.data;

namespace CAE.src_test.data
{
    public class DatabaseRetrievalTestHarnessGetProject
    {
        public static void Main()
        {
            // declare variables needed by DatabaseReader method GetProject
            // these would normally be variables, not literals:
            string project_nm = "order_mgt";

            // call DatabaseReader method GetModule to return data for a specific project:
            DataSet myDataSet = DatabaseReader.GetProject(project_nm);
            Console.WriteLine("Retrieving a row from the Get Project Procedure");

            // result set returned from Stored Procedure ends up in the DataSet's DataTable:
            DataTable myDataTable = myDataSet.Tables["get_project"];

            // loop through DataRows of the DataTable pulling off the fields you need
            // by name within square brackets:
            foreach (DataRow myDataRow in myDataTable.Rows)
            {
                Console.WriteLine("ProjectName = " + myDataRow["project_nm"]);
                Console.WriteLine("ProjectDesc = " + myDataRow["project_desc"]);
            }
        }
    }
}