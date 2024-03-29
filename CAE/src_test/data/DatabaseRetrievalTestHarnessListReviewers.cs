﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CAE.src.data;

namespace CAE.src_test.data
{
    public class DatabaseRetrievalTestHarnessListReviewers
    {
        public static void Main()
        {
            // declare variables needed by DatabaseReader method ListReviewers
            // these would normally be variables, not literals:
            string project_nm = "order_mgt";

            // call DatabaseReader method ListReviewers to return a list of all reviewers for a given project:
            DataSet myDataSet = DatabaseReader.ListReviewers(project_nm);
            Console.WriteLine("Retrieving rows from the List Reviewers Procedure");

            // result set returned from Stored Procedure ends up in the DataSet's DataTable:
            DataTable myDataTable = myDataSet.Tables["list_rvwrs"];

            // loop through DataRows of the DataTable pulling off the fields you need
            // by name within square brackets:
            foreach (DataRow myDataRow in myDataTable.Rows)
            {
                Console.WriteLine("ProjectName = " + myDataRow["project_nm"]);
                Console.WriteLine("Reviewer Last Name = " + myDataRow["rvwr_last_nm"]);
                Console.WriteLine("Reviewer First Name = " + myDataRow["rvwr_first_nm"]);
                Console.WriteLine("Annotation Color = " + myDataRow["annotation_color"]);
            }
        }
    }
}