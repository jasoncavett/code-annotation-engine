using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CAE.src_test.data
{
    class DatabaseRetrievalTestHarness
    {
        public static void Main()
        {
            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=CAE;Integrated Security=SSPI;");

            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "EXECUTE dbo.list_mods @project_nm";
            mySqlCommand.Parameters.Add("@project_nm", SqlDbType.VarChar, 20).Value = "order_mgt";
            SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter();
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            mySqlConnection.Open();
            DataSet myDataSet = new DataSet();
            Console.WriteLine("Retrieving rows from the List Modules Procedure");
            int numberOfRows = mySqlDataAdapter.Fill(myDataSet, "list_mods");
            Console.WriteLine("numberOfRows = " + numberOfRows);
            mySqlConnection.Close();
            DataTable myDataTable = myDataSet.Tables["list_mods"];
            foreach (DataRow myDataRow in myDataTable.Rows)
            {
                Console.WriteLine("ProjectName = " + myDataRow["project_nm"]);
                Console.WriteLine("ModuleName = " + myDataRow["module_nm"]);
                Console.WriteLine("ModuleDesc = " + myDataRow["module_desc"]);
                Console.WriteLine("Lang = " + myDataRow["lang"]);
            }
        }
 
    }
}
