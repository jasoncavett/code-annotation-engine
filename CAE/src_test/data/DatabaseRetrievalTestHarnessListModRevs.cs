﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CAE.src.data
{
    public class DatabaseReaderTestHarnessListModRevs
    {
        public static void Main()
        {
// declare variables needed by DatabaseReader method ListModuleRevisions
// these would normally be variables, not literals:
            string project_nm = "order_mgt";
            string module_nm = "get_order";
            DataSet myDataSet = new DataSet();
// call DatabaseReader method ListModuleRevisions to return a list of all revisions for a module in a project:
            DatabaseReader.ListModuleRevisions(project_nm, module_nm, myDataSet);
            Console.WriteLine("Retrieving rows from the List Module Revisions Procedure");
// result set returned from Stored Procedure ends up in the DataSet's DataTable:
            DataTable myDataTable = myDataSet.Tables["list_mod_revs"];
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
            }
        }
    }
}

  
 