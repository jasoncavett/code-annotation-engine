using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CAE.src.data
{
    public class DatabaseRetrievalTestHarnessListMods
    {
        /// <summary>
        /// Main entry point.
        /// </summary>
        public static void Main()
        {
            // declare variables needed by DatabaseReader method ListModules
            // these would normally be variables, not literals:
            string project_nm = "order_mgt";

            // call DatabaseReader method ListModules to return a list of all modules for a project:
            DataSet myDataSet = DatabaseReader.ListModules(project_nm);
            Console.WriteLine("Retrieving rows from the List Modules Procedure");
            
            // result set returned from Stored Procedure ends up in the DataSet's DataTable:
            DataTable myDataTable = myDataSet.Tables["list_mods"];
            
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
