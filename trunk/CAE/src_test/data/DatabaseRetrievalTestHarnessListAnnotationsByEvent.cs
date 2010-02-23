using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CAE.src.data
{
    public class DatabaseRetrievalTestHarnessListAnnotationsByEvent
    {
        public static void Main()
        {
// declare variables needed by DatabaseReader method ListAnnotations
// these would normally be variables, not literals:
            string project_nm = "order_mgt";
            string module_nm = "get_order";
            decimal revision_no = 1.2M;
            string rvw_event_dt = "02/04/2010";
            DataSet myDataSet = new DataSet();
// call DatabaseReader method ListAnnotations to return a list of all annotations for a given review
// of a given revision of a module in a project:
            DatabaseReader.ListAnnotations(project_nm, module_nm, revision_no, rvw_event_dt, myDataSet);
            Console.WriteLine("Retrieving rows from the ListAnnotations Procedure");
// result set returned from Stored Procedure ends up in the DataSet's DataTable:
            DataTable myDataTable = myDataSet.Tables["list_annotations_by_evnt"];
// loop through DataRows of the DataTable pulling off the fields you need
// by name within square brackets:
            foreach (DataRow myDataRow in myDataTable.Rows)
            {
                Console.WriteLine("ProjectName = " + myDataRow["project_nm"]);
                Console.WriteLine("ModuleName = " + myDataRow["module_nm"]);
                Console.WriteLine("ModuleDesc = " + myDataRow["module_desc"]);
                Console.WriteLine("Lang = " + myDataRow["lang"]);
                Console.WriteLine("AuthorLastName = " + myDataRow["author_last_nm"]);
                Console.WriteLine("AuthorFirstName = " + myDataRow["author_first_nm"]);
                Console.WriteLine("RevisionNo = " + myDataRow["revision_no"]);
                Console.WriteLine("ChangeDesc = " + myDataRow["chg_desc"]);
                Console.WriteLine("Developer Last Name = " + myDataRow["devlpr_last_nm"]);
                Console.WriteLine("Developer First Name = " + myDataRow["devlpr_first_nm"]);
                Console.WriteLine("Review Event Date = " + myDataRow["rvw_event_dt"]);
                Console.WriteLine("Review Event Desc = " + myDataRow["rvw_event_desc"]);
                Console.WriteLine("Reviewer Last Name = " + myDataRow["rvwr_last_nm"]);
                Console.WriteLine("Reviewer First Name = " + myDataRow["rvwr_first_nm"]);
                Console.WriteLine("Annotation Text = " + myDataRow["annotation_txt"]);
            }
        }
    }
}
