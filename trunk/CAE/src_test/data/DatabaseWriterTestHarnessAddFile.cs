using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CAE.src.data;

namespace CAE.src_test.data
{
    public class DatabaseWriterTestHarnessAddFile
    {
        public static void Main()
        {
            // declare variables needed by DatabaseWriter method AddFile
            // these would normally be variables, not literals:
            string project_nm = "order_mgt";
            string codefile_nm = "delete_order";
            // call DatabaseWriter method AddFile to add a new Codefile:
            StringBuilder errorMessages = DatabaseWriter.AddFile(project_nm, codefile_nm);
            Console.WriteLine("Adding a row using the Add Codefile Procedure");
            Console.WriteLine(errorMessages.ToString());
         }
    }
}