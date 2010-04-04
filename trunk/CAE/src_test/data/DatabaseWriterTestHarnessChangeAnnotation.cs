using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CAE.src.data;

namespace CAE.src_test.data
{
    public class DatabaseWriterTestHarnessChangeAnnotation
    {
        public static void Main()
        {
            // declare variables needed by DatabaseWriter method ChangeAnnotation
            // these would normally be variables, not literals:
            string project_nm = "order_mgt";
            string codefile_nm = "java_main";
            int codefile_line_no = 54;
            string rvwr_last_nm = "Manon";
            string rvwr_first_nm = "Joel";
            string annotation_txt = "This comment has just been changed";
            // call DatabaseWriter method ChangeAnnotation to change an existing Annotation:
            StringBuilder errorMessages = DatabaseWriter.ChangeAnnotation(project_nm, codefile_nm, codefile_line_no, 
                rvwr_last_nm, rvwr_first_nm, annotation_txt);
            Console.WriteLine("Changing a row using the Change Annotation Procedure");
            Console.WriteLine(errorMessages.ToString());
        }
    }
}