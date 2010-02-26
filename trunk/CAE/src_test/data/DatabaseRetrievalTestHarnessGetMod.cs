using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CAE.src.data
{
    public class DatabaseRetrievalTestHarnessGetMod
    {
        public static void Main()
        {
            // declare variables needed by DatabaseReader method GetModule
            // these would normally be variables, not literals:
            string project_nm = "order_mgt";
            string module_nm = "java_main";

            // call DatabaseReader method GetModule to return a data for a specific module for a project:
            DataSet myDataSet = DatabaseReader.GetModule(project_nm, module_nm);
            Console.WriteLine("Retrieving a row from the Get Module Procedure");

            // result set returned from Stored Procedure ends up in the DataSet's DataTable:
            DataTable myDataTable = myDataSet.Tables["get_mod"];

            // loop through DataRows of the DataTable pulling off the fields you need
            // by name within square brackets:
            foreach (DataRow myDataRow in myDataTable.Rows)
            {
                Console.WriteLine("ProjectName = " + myDataRow["project_nm"]);
                Console.WriteLine("ModuleName = " + myDataRow["module_nm"]);
                Console.WriteLine("ModuleDesc = " + myDataRow["module_desc"]);
                Console.WriteLine("Lang = " + myDataRow["lang"]);
                Console.WriteLine("AuthorLastName = " + myDataRow["author_last_nm"]);
                Console.WriteLine("AuthorFirstName = " + myDataRow["author_first_nm"]);
            }
        }
    }
}