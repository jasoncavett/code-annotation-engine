using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CAE.src.data;

namespace CAE.src_test.data
{
    public class DatabaseRetrievalTestHarnessGetRevwr
    {
        public static void Main()
        {
            // declare variables needed by DatabaseReader method GetReviewer
            // these would normally be variables, not literals:
            string project_nm = "order_mgt";
            string rvwr_last_nm = "Manon";
            string rvwr_first_nm = "Joel";

            // call DatabaseReader method GetModule to return data for a specific reviewer for a project:
            DataSet myDataSet = DatabaseReader.GetReviewer(project_nm, rvwr_last_nm, rvwr_first_nm);
            Console.WriteLine("Retrieving a row from the Get Reviewer Procedure");

            // result set returned from Stored Procedure ends up in the DataSet's DataTable:
            DataTable myDataTable = myDataSet.Tables["get_rvwr"];

            // loop through DataRows of the DataTable pulling off the fields you need
            // by name within square brackets:
            foreach (DataRow myDataRow in myDataTable.Rows)
            {
                Console.WriteLine("ProjectName = " + myDataRow["project_nm"]);
                Console.WriteLine("Reviewer Last Name = " + myDataRow["rvwr_last_nm"]);
                Console.WriteLine("Reviewer First Name = " + myDataRow["rvwr_first_nm"]);
                Console.WriteLine("Job Title = " + myDataRow["job_title"]);
                Console.WriteLine("Annotation Color = " + myDataRow["annotation_color"]);
                Console.WriteLine("Annotation Font = " + myDataRow["annotation_font"]);
                Console.WriteLine("Annotation Font Weight = " + myDataRow["annotation_font_wt"]);
            }
        }
    }
}