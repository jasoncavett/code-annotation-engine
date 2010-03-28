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
        /// <summary>
        /// Add a project to the database.
        /// </summary>
        /// <param name="project_nm">The name of the project.</param>
        /// <returns>Any error messages.</returns>
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
                }
            }
            mySqlConnection.Close();
            return errorMessages;
        }

        /// <summary>
        /// Add a new file to the database that is being updated.
        /// </summary>
        /// <param name="project_nm">The name of the project.</param>
        /// <param name="codefile_nm">The name of the code file that is receiving the annotation.</param>
        /// <returns>Any error messages.</returns>
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

        /// <summary>
        /// Add a reviewer to the database.
        /// </summary>
        /// <param name="project_nm">The name of the project.</param>
        /// <param name="rvwr_last_nm">The last name of the reviewer.</param>
        /// <param name="rvwr_first_nm">The first name of the reviewer.</param>
        /// <param name="annotation_color">The reviewer's annotation color.</param>
        /// <returns>Any error messages.</returns>
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

        /// <summary>
        /// Add an annotation to the database.
        /// </summary>
        /// <param name="project_nm">The project the annotation is associated with.</param>
        /// <param name="codefile_nm">The codefile the annotation is associated with.</param>
        /// <param name="codefile_line_no">The line that the annotation is being added to.</param>
        /// <param name="rvwr_last_nm">The last name of the reviewer.</param>
        /// <param name="rvwr_first_nm">The first name of the reviewer.</param>
        /// <param name="annotation_txt">The text of the annotation.</param>
        /// <returns>Any error messages.</returns>
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

        public static void TruncateStaging ()
        {
            SqlConnection mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CAE.Properties.Settings.CAEConnectionString"].ToString());
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "EXECUTE dbo.trunc_staging";
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
            return;
        }

        /// <summary>
        /// Merge Annotations from Staging Table.
        /// </summary>
        /// <param name="rvwr_last_nm">The last name of the reviewer.</param>
        /// <param name="rvwr_first_nm">The first name of the reviewer.</param>
        /// <returns>Any error messages.</returns>
        public static StringBuilder MergeAnnotations(string rvwr_last_nm, string rvwr_first_nm)
        {
            StringBuilder errorMessages = new StringBuilder();
            SqlConnection mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CAE.Properties.Settings.CAEConnectionString"].ToString());
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "EXECUTE dbo.merge_annotations @rvwr_last_nm, @rvwr_first_nm";
            mySqlCommand.Parameters.Add("@rvwr_last_nm", SqlDbType.VarChar, 20).Value = rvwr_last_nm;
            mySqlCommand.Parameters.Add("@rvwr_first_nm", SqlDbType.VarChar, 20).Value = rvwr_first_nm;
            try
            {
                mySqlConnection.Open();
                mySqlCommand.ExecuteNonQuery();
                errorMessages.Append("Successfully Merged Annotations \n");
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

        /// <summary>
        /// Import the database from a flat file to the staging table
        /// so that the data can be merged with the local database.
        /// </summary>
        /// <param name="ImportFile">The full path and file name
        ///    of the import file.  This is where the database will be loaded from.</param>
        /// <param name="FormatFile">The full path and file name of the format file.
        ///    This describes the flat file. </param>
        /// <param name="rvwr_first_nm">The last name of the Reviewer</param>
        /// <param name="rvwr_last_nm">The first name of the Reviewer</param>
        public static StringBuilder ImportAnnotations(string ImportFile, string FormatFile, string rvwr_last_nm, string rvwr_first_nm)
        {
            int waitTime = 6000; // max milliseconds to wait for bcp to finish
            string cmd =
                @"bcp CAE.dbo.Import_Stage in " +
                @"""" + ImportFile + @""" -Slocalhost\sqlexpress -f " +
                @"""" + FormatFile + @""" -T";

//              @"""" + Resources.ReviewAnnotationFormat.ToString() + @""" -T";
            //
            //  First, wipe everything out of the Staging Table:
            //
            DatabaseWriter.TruncateStaging();
            //
            //  Next, import the flat file data into the Staging Table:
            //
            System.Diagnostics.ProcessStartInfo processStartInfo =
            new System.Diagnostics.ProcessStartInfo();
            processStartInfo.FileName = "CMD.exe";
            processStartInfo.Arguments = "/C " + cmd;
            processStartInfo.CreateNoWindow = true;
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            processStartInfo.UseShellExecute = false;
            process.EnableRaisingEvents = true;
            //wait until the process has completed
            process.StartInfo = processStartInfo;
            process.Start();
            process.WaitForExit(waitTime);
            process.Close();
            //
            //  Finally, merge Annotations in the Import_Stage Table into the
            //      local Review_annotation Table:
            //
            StringBuilder errorMessages = DatabaseWriter.MergeAnnotations(rvwr_last_nm, rvwr_first_nm);
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