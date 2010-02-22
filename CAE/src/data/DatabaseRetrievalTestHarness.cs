using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CAE.src.data
{
    public class DatabaseRetrievalTestHarness
    {
        public static void Main()
        {
            int numberOfRows = 0;
            DataSet myDataSet = new DataSet();
            DatabaseReader.ListModules(myDataSet);
            Console.WriteLine("Retrieving rows from the List Modules Procedure");
            Console.WriteLine("numberOfRows = " + numberOfRows);
            DataTable myDataTable = myDataSet.Tables["list_mods"];
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
