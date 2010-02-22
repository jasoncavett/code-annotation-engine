using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CAE.src.data
{
    public class DatabaseReader
    {
        public static void ListModules(string project_nm, DataSet myDataSet)
        {
            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=CAE;Integrated Security=SSPI;");
            DatabaseReader myDatabaseReader = new DatabaseReader();
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "EXECUTE dbo.list_mods @project_nm";
            mySqlCommand.Parameters.Add("@project_nm", SqlDbType.VarChar, 20).Value = project_nm;
            SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter();
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            mySqlConnection.Open();
            int numberOfRows = mySqlDataAdapter.Fill(myDataSet, "list_mods");
            mySqlConnection.Close();
        }
        public static void ListModuleRevisions(string project_nm, string module_nm, DataSet myDataSet)
        {
            SqlConnection mySqlConnection = new SqlConnection("server=(local)\\SQLEXPRESS;database=CAE;Integrated Security=SSPI;");
            DatabaseReader myDatabaseReader = new DatabaseReader();
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "EXECUTE dbo.list_mod_revs @project_nm, @module_nm";
            mySqlCommand.Parameters.Add("@project_nm", SqlDbType.VarChar, 20).Value = project_nm;
            mySqlCommand.Parameters.Add("@module_nm", SqlDbType.VarChar, 50).Value = module_nm;
            SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter();
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            mySqlConnection.Open();
            int numberOfRows = mySqlDataAdapter.Fill(myDataSet, "list_mod_revs");
            mySqlConnection.Close();
        }
    }
}