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
            string project_nm = "blah_blah";
            string module_nm = "sub_module";
            string module_desc = "this is the main module";
            string lang = "c#";
            string author_last_nm = "Cavett";
            string author_first_nm = "Jason";
            // call DatabaseWriter method AddModule to return data for a specific project:
            StringBuilder errorMessages = DatabaseWriter.AddModule(project_nm, module_nm, module_desc, lang, author_last_nm, author_first_nm);
            Console.WriteLine("Adding a row using the Add Module Procedure");
            Console.WriteLine(errorMessages.ToString());
         }
    }
}