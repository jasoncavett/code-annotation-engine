using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CAE.src.data;

namespace CAE.src_test.data
{
    public class ImportTestHarness
    {
        public static void Main()
        {
            // declare variables needed by DatabaseReader method ImportAnnotations
            // these would normally be variables, not literals:
            string ImportFile = @"C:\SWENG500\Export.txt";
            string FormatFile = @"C:\SWENG500\ReviewAnnotationFormat.txt";
            string rvwr_last_nm = "Manon";
            string rvwr_first_nm = "Joel";

            // call DatabaseWriter method ImportAnnotations to import annotations into database
            StringBuilder errorMessages =
                DatabaseWriter.ImportAnnotations(ImportFile, FormatFile, rvwr_last_nm, rvwr_first_nm);
            Console.WriteLine("Importing data via Import Annotations");
            Console.WriteLine(errorMessages.ToString());
        }
    }
}
