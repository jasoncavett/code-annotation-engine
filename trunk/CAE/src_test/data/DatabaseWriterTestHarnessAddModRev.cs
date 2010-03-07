using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CAE.src.data;

namespace CAE.src_test.data
{
    public class DatabaseWriterTestHarnessAddModRev
    {
        public static void Main()
        {
            // declare variables needed by DatabaseWriter method AddModuleRevision
            // these would normally be variables, not literals:
            string project_nm = "order_mgt";
            string module_nm = "java_main";
            decimal revision_no = 5.4m;
            string chg_desc = "Added new functionality";
	        string devlpr_last_nm = "Jackson";
            string devlpr_first_nm = "David";
            // call DatabaseWriter method AddModuleRevision to add a new revision for a module:
            StringBuilder errorMessages = DatabaseWriter.AddModuleRevision(project_nm, module_nm, revision_no, chg_desc, devlpr_last_nm, devlpr_first_nm);
            Console.WriteLine("Adding a row using the Add Module Revision Procedure");
            Console.WriteLine(errorMessages.ToString());
        }
    }
}