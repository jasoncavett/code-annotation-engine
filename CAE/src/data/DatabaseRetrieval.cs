using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CAE.src.data
{
    class DatabaseRetrieval
    {
    public static void ListModules(string project_nm)
        {
        SqlConnection mySqlConnection =new SqlConnection(CAE.Properties.Settings.CAEConnectionString);

        SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
        mySqlCommand.CommandText = "EXECUTE dbo.list_mods @project_nm";
        mySqlCommand.Parameters.Add("@project_nm", SqlDbType.VarChar, 20).Value = project_nm;

        SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter();
        mySqlDataAdapter.SelectCommand = mySqlCommand;
        DataSet myDataSet = new DataSet();
        mySqlConnection.Open();
        int numberOfRows = mySqlDataAdapter.Fill(myDataSet, "list_mods");
        mySqlConnection.Close();
        }
    }
}
