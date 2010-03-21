using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CAE.src.data;

namespace CAE.src_test.data
{
    public class DatabaseWriterTestHarnessAddReviewer
    {
        public static void Main()
        {
            // declare variables needed by DatabaseWriter method AddReviewer
            // these would normally be variables, not literals:
            string project_nm = "order_mgt";
            string rvwr_last_nm = "Kelley";
	        string rvwr_first_nm = "Maureen";
	        string annotation_color = "green";
            // call DatabaseWriter method AddReviewer to add a new Reviewer to a Project:
            StringBuilder errorMessages = DatabaseWriter.AddReviewer(project_nm, rvwr_last_nm, rvwr_first_nm, annotation_color);
            Console.WriteLine("Adding a row using the Add Reviewer Procedure");
            Console.WriteLine(errorMessages.ToString());
        }
    }
}
