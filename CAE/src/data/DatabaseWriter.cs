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
        public static StringBuilder AddProject(string project_nm)
        {
            StringBuilder errorMessages = new StringBuilder();
            SqlConnection mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CAE.Properties.Settings.CAEConnectionString"].ToString());
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "EXECUTE dbo.add_project @project_nm";
            mySqlCommand.Parameters.Add("@project_nm", SqlDbType.VarChar, 20).Value = project_nm;
            try
            {
                mySqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
                errorMessages.Append("Successfully Added New Project \n");
            }
            catch (SqlException ex)
            {
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                 errorMessages.Append(ex.Errors[i].Message + "\n");
//               errorMessages.Append("Index #" + i + "\n" +
//                                    "Message: " + ex.Errors[i].Message + "\n" +
//                                    "Number: " + ex.Errors[i].Number + "\n" +
//                                    "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
//                                    "Source: " + ex.Errors[i].Source + "\n" +
//                                    "Procedure: " + ex.Errors[i].Procedure + "\n");
                }
            }
            mySqlConnection.Close();
            return errorMessages;
        }
        public static StringBuilder AddFile(string project_nm, string codefile_nm)
        {
            StringBuilder errorMessages = new StringBuilder();
            SqlConnection mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CAE.Properties.Settings.CAEConnectionString"].ToString());
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "EXECUTE dbo.add_file @project_nm, @codefile_nm";
            mySqlCommand.Parameters.Add("@project_nm", SqlDbType.VarChar, 20).Value = project_nm;
            mySqlCommand.Parameters.Add("@codefile_nm", SqlDbType.VarChar, 50).Value = codefile_nm;
            try
            {
                mySqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
                errorMessages.Append("Successfully Added New Codefile \n");
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
        public static StringBuilder AddReviewer(string project_nm, string rvwr_last_nm, string rvwr_first_nm,
                string annotation_color)
        {
            StringBuilder errorMessages = new StringBuilder();
            SqlConnection mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CAE.Properties.Settings.CAEConnectionString"].ToString());
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "EXECUTE dbo.add_reviewer @project_nm, @rvwr_last_nm, @rvwr_first_nm, @annotation_color";
            mySqlCommand.Parameters.Add("@project_nm", SqlDbType.VarChar, 20).Value = project_nm;
            mySqlCommand.Parameters.Add("@rvwr_last_nm", SqlDbType.VarChar, 20).Value = rvwr_last_nm;
            mySqlCommand.Parameters.Add("@rvwr_first_nm", SqlDbType.VarChar, 20).Value = rvwr_first_nm;
            mySqlCommand.Parameters.Add("@annotation_color", SqlDbType.VarChar, 15).Value = annotation_color;
            try
            {
                mySqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
                errorMessages.Append("Successfully Added New Reviewer \n");
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
        public static StringBuilder AddAnnotation(string project_nm, string codefile_nm, int codefile_line_no, 
            string rvwr_last_nm, string rvwr_first_nm, string annotation_txt)
        {
            StringBuilder errorMessages = new StringBuilder();
            SqlConnection mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CAE.Properties.Settings.CAEConnectionString"].ToString());
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "EXECUTE dbo.add_annotation @project_nm, @codefile_nm, " +
                "@codefile_line_no, @rvwr_last_nm, @rvwr_first_nm, @annotation_txt";
            mySqlCommand.Parameters.Add("@project_nm", SqlDbType.VarChar, 20).Value = project_nm;
            mySqlCommand.Parameters.Add("@codefile_nm", SqlDbType.VarChar, 50).Value = codefile_nm;
            mySqlCommand.Parameters.Add("@codefile_line_no", SqlDbType.Int).Value = codefile_line_no;
            mySqlCommand.Parameters.Add("@rvwr_last_nm", SqlDbType.VarChar, 20).Value = rvwr_last_nm;
            mySqlCommand.Parameters.Add("@rvwr_first_nm", SqlDbType.VarChar, 20).Value = rvwr_first_nm;
            mySqlCommand.Parameters.Add("@annotation_txt", SqlDbType.VarChar, 2000).Value = annotation_txt;
            try
            {
                mySqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
                errorMessages.Append("Successfully Added New Annotation \n");
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
//  For debugging: more extensive SQL Server error info:
//              errorMessages.Append("Index #" + i + "\n" +
//                                   "Message: " + ex.Errors[i].Message + "\n" +
//                                   "Number: " + ex.Errors[i].Number + "\n" +
//                                   "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
//                                   "Source: " + ex.Errors[i].Source + "\n" +
//                                   "Procedure: " + ex.Errors[i].Procedure + "\n");