using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CAE.src.data;

namespace CAE.src_test.data
{
    public class ExportTestHarness
    {
        public static void Main()
        {
            // declare variables needed by DatabaseReader method ExportAnnotations
            // these would normally be variables, not literals:
            string FullPath = "C:\\SWENG500";

            // call DatabaseReader method ExportAnnotations to return a list of all annotations for a given
            // codefile in a project:
            DatabaseReader.ExportAnnotations(FullPath);
            Console.WriteLine("Exporting data via Export Annotations");
        }
    }
}
