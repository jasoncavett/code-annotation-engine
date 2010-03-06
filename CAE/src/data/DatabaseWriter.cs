using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CAE.src.data
{
    public static class DatabaseWriter
    {
        public static StringBuilder AddProject(string project_nm, string project_desc)
        {
            StringBuilder errorMessages = new StringBuilder();
            SqlConnection mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CAE.Properties.Settings.CAEConnectionString"].ToString());
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "EXECUTE dbo.add_project @project_nm, @project_desc";
            mySqlCommand.Parameters.Add("@project_nm", SqlDbType.VarChar, 20).Value = project_nm;
            mySqlCommand.Parameters.Add("@project_desc", SqlDbType.VarChar, 256).Value = project_desc;
            try
            {
                mySqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
                errorMessages.Append("New Project Added Successfully \n");
            }
            catch (SqlException ex)
            {
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append(ex.Errors[i].Message + "\n");

                    //                    errorMessages.Append("Index #" + i + "\n" +
                    //                        "Message: " + ex.Errors[i].Message + "\n" +
                    //                        "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                    //                        "Source: " + ex.Errors[i].Source + "\n" +
                    //                        "Procedure: " + ex.Errors[i].Procedure + "\n");
                }
            }
            mySqlConnection.Close();
            return errorMessages;
        }
        public static StringBuilder AddModule(string project_nm, string module_nm, string module_desc,
            string lang, string author_last_nm, string author_first_nm)
        {
            StringBuilder errorMessages = new StringBuilder();
            SqlConnection mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CAE.Properties.Settings.CAEConnectionString"].ToString());
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "EXECUTE dbo.add_mod @project_nm, @module_nm, " +
                "@module_desc, @lang, @author_last_nm, @author_first_nm";
            mySqlCommand.Parameters.Add("@project_nm", SqlDbType.VarChar, 20).Value = project_nm;
            mySqlCommand.Parameters.Add("@module_nm", SqlDbType.VarChar, 50).Value = module_nm;
            mySqlCommand.Parameters.Add("@module_desc", SqlDbType.VarChar, 256).Value = module_desc;
            mySqlCommand.Parameters.Add("@lang", SqlDbType.VarChar, 10).Value = lang;
            mySqlCommand.Parameters.Add("@author_last_nm", SqlDbType.VarChar, 20).Value = author_last_nm;
            mySqlCommand.Parameters.Add("@author_first_nm", SqlDbType.VarChar, 20).Value = author_first_nm;
            try
            {
                mySqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
                errorMessages.Append("New Module Added Successfully \n");
            }
            catch (SqlException ex)
            {
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append(ex.Errors[i].Message + "\n");
                }
            }
            mySqlConnection.Close();
            return errorMessages;
        }
    }
}