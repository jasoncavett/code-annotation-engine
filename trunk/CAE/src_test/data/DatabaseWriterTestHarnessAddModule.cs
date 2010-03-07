using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CAE.src.data;

namespace CAE.src_test.data
{
    public class DatabaseWriterTestHarnessAddModule
    {
        public static void Main()
        {
            // declare variables needed by DatabaseWriter method AddModule
            // these would normally be variables, not literals:
            string project_nm = "order_mgt";
            string module_nm = "delete_order";
            string module_desc = "this is the main module";
            string lang = "c#";
            string author_last_nm = "Cavett";
            string author_first_nm = "Jason";
            // call DatabaseWriter method AddModule to add a new Module:
            StringBuilder errorMessages = DatabaseWriter.AddModule(project_nm, module_nm, module_desc, lang, author_last_nm, author_first_nm);
            Console.WriteLine("Adding a row using the Add Module Procedure");
            Console.WriteLine(errorMessages.ToString());
         }
    }
}