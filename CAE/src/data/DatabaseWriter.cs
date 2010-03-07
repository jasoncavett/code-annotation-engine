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
                errorMessages.Append("Successfully Added New Project \n");
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
                errorMessages.Append("Successfully Added New Module \n");
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
        public static StringBuilder AddModuleRevision(string project_nm, string module_nm, decimal revision_no,
            string chg_desc, string devlpr_last_nm, string devlpr_first_nm)
        {
            StringBuilder errorMessages = new StringBuilder();
            SqlConnection mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CAE.Properties.Settings.CAEConnectionString"].ToString());
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "EXECUTE dbo.add_mod_rev @project_nm, @module_nm, " +
                "@revision_no, @chg_desc, @devlpr_last_nm, @devlpr_first_nm";
            mySqlCommand.Parameters.Add("@project_nm", SqlDbType.VarChar, 20).Value = project_nm;
            mySqlCommand.Parameters.Add("@module_nm", SqlDbType.VarChar, 50).Value = module_nm;
            SqlParameter revno = mySqlCommand.Parameters.Add("@revision_no", SqlDbType.Decimal);
            revno.Value = revision_no;
            revno.Precision = 6;
            revno.Scale = 3;
            mySqlCommand.Parameters.Add("@chg_desc", SqlDbType.VarChar, 256).Value = chg_desc;
            mySqlCommand.Parameters.Add("@devlpr_last_nm", SqlDbType.VarChar, 20).Value = devlpr_last_nm;
            mySqlCommand.Parameters.Add("@devlpr_first_nm", SqlDbType.VarChar, 20).Value = devlpr_first_nm;
            try
            {
                mySqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
                errorMessages.Append("Successfully Added New Module Revision \n");
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
                string job_title, string annotation_color, string annotation_font, string annotation_font_wt)
        {
            StringBuilder errorMessages = new StringBuilder();
            SqlConnection mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CAE.Properties.Settings.CAEConnectionString"].ToString());
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "EXECUTE dbo.add_reviewer @project_nm, @rvwr_last_nm, " +
                "@rvwr_first_nm, @job_title, @annotation_color, @annotation_font, @annotation_font_wt";
            mySqlCommand.Parameters.Add("@project_nm", SqlDbType.VarChar, 20).Value = project_nm;
            mySqlCommand.Parameters.Add("@rvwr_last_nm", SqlDbType.VarChar, 20).Value = rvwr_last_nm;
            mySqlCommand.Parameters.Add("@rvwr_first_nm", SqlDbType.VarChar, 20).Value = rvwr_first_nm;
            mySqlCommand.Parameters.Add("@job_title", SqlDbType.VarChar, 30).Value = job_title;
            mySqlCommand.Parameters.Add("@annotation_color", SqlDbType.VarChar, 15).Value = annotation_color;
            mySqlCommand.Parameters.Add("@annotation_font", SqlDbType.VarChar, 20).Value = annotation_font;
            mySqlCommand.Parameters.Add("@annotation_font_wt", SqlDbType.VarChar, 15).Value = annotation_font_wt;
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
    }
}