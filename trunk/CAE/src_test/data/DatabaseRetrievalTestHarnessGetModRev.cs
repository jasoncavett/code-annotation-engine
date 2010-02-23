using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CAE.src.data
{
    public class DatabaseReaderTestHarnessGetModRev
    {
        public static void Main()
        {
// declare variables needed by DatabaseReader method GetModuleRevision
// these would normally be variables, not literals:
            string project_nm = "order_mgt";
            string module_nm = "get_order";
            decimal revision_no = 1.3M;
            DataSet myDataSet = new DataSet();
// call DatabaseReader method GetModuleRevision to return data
// for a specific revision of a module in a project:
            DatabaseReader.GetModuleRevision(project_nm, module_nm, revision_no, myDataSet);
            Console.WriteLine("Retrieving rows from the Get Module Revision Procedure");
// result set returned from Stored Procedure ends up in the DataSet's DataTable:
            DataTable myDataTable = myDataSet.Tables["get_mod_rev"];
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
                Console.WriteLine("RevisionNo = " + myDataRow["revision_no"]);
                Console.WriteLine("ChangeDesc = " + myDataRow["chg_desc"]);
                Console.WriteLine("Developer Last Name = " + myDataRow["devlpr_last_nm"]);
                Console.WriteLine("Developer First Name = " + myDataRow["devlpr_first_nm"]);
            }
        }
    }
}


