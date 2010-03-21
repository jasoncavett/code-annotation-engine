using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CAE.src.data;

namespace CAE.src_test.data
{
    public class DatabaseWriterTestHarnessAddAnnotation
    {
        public static void Main()
        {
            // declare variables needed by DatabaseWriter method AddAnnotation
            // these would normally be variables, not literals:
            string project_nm = "order_mgt";
            string codefile_nm = "java_main";
            int codefile_line_no = 54;
            string rvwr_last_nm = "Manon";
            string rvwr_first_nm = "Joel";
            string annotation_txt = "This module needs a lot more work";
            // call DatabaseWriter method AddReviewer to add a new Reviewer to a Project:
            StringBuilder errorMessages = DatabaseWriter.AddAnnotation(project_nm, codefile_nm, codefile_line_no, 
                rvwr_last_nm, rvwr_first_nm, annotation_txt);
            Console.WriteLine("Adding a row using the Add Annotation Procedure");
            Console.WriteLine(errorMessages.ToString());
        }
    }
}