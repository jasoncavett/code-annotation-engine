using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CAE.src.data;

namespace CAE.src_test.data
{
    public class DatabaseRetrievalTestHarnessListAnnotationsByFileRvwr
    {
        public static void Main()
        {
            // declare variables needed by DatabaseReader method ListAnnotations
            // these would normally be variables, not literals:
            string project_nm = "order_mgt";
            string codefile_nm = "java_main";
            string rvwr_last_nm = "Rosa";
            string rvwr_first_nm = "Juan";

            // call DatabaseReader method ListAnnotations to return a list of all annotations for a 
            // given codefile in a project by a given reviewer:
            DataSet myDataSet = DatabaseReader.ListAnnotations(project_nm, codefile_nm, rvwr_last_nm, rvwr_first_nm);
            Console.WriteLine("Retrieving rows from the ListAnnotations Procedure");

            // result set returned from Stored Procedure ends up in the DataSet's DataTable:
            DataTable myDataTable = myDataSet.Tables["list_annotations_by_file_rvwr"];

            // loop through DataRows of the DataTable pulling off the fields you need
            // by name within square brackets:
            foreach (DataRow myDataRow in myDataTable.Rows)
            {
                Console.WriteLine("ProjectName = " + myDataRow["project_nm"]);
                Console.WriteLine("CodefileName = " + myDataRow["codefile_nm"]);
                Console.WriteLine("CodefileLineNo = " + myDataRow["codefile_line_no"]);
                Console.WriteLine("Reviewer Last Name = " + myDataRow["rvwr_last_nm"]);
                Console.WriteLine("Reviewer First Name = " + myDataRow["rvwr_first_nm"]);
                Console.WriteLine("Annotation Text = " + myDataRow["annotation_txt"]);
            }
        }
    }
}
