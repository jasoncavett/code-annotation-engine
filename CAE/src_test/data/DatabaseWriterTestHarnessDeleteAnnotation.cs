using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CAE.src.data;

namespace CAE.src_test.data
{
    class DatabaseWriterTestHarnessDeleteAnnotation
    {
        public static void Main()
        {
            // declare variables needed by DatabaseWriter method DeleteAnnotation
            // these would normally be variables, not literals:
            string project_nm = "order_mgt";
            string codefile_nm = "java_main";
            int codefile_line_no = 54;
            string rvwr_last_nm = "Manon";
            string rvwr_first_nm = "Joel";
            // call DatabaseWriter method DeleteAnnotation to delete an Annotation from a Project:
            StringBuilder errorMessages = DatabaseWriter.DeleteAnnotation(project_nm, codefile_nm, codefile_line_no, 
                rvwr_last_nm, rvwr_first_nm);
            Console.WriteLine("Deleting a row using the Delete Annotation Procedure");
            Console.WriteLine(errorMessages.ToString());
        }
    }
}