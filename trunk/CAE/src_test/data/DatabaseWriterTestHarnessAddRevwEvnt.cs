using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CAE.src.data;

namespace CAE.src_test.data
{
    public class DatabaseWriterTestHarnessAddRevwEvnt
    {
        public static void Main()
        {
            // declare variables needed by DatabaseWriter method AddReviewEvent
            // these would normally be variables, not literals:
            string project_nm = "order_mgt";
            string module_nm = "java_main";
            decimal revision_no = 1.3m;
            string rvw_event_dt = "02/25/2010";
            string rvw_event_desc = "Code Review for Sprint 2";
            // call DatabaseWriter method AddReviewer to add a new Reviewer to a Project:
            StringBuilder errorMessages = DatabaseWriter.AddReviewEvent(project_nm, module_nm, revision_no, rvw_event_dt, rvw_event_desc);
            Console.WriteLine("Adding a row using the Add Review Event Procedure");
            Console.WriteLine(errorMessages.ToString());
        }
    }
}