using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace CAE.src.data
{
    public static class DatabaseManager
    {
        public static string EXPORT_FILE_NAME = "database.cae";
        public static string FORMAT_FILE_NAME = "ReviewAnnotationFormat.txt";

        /// <summary>
        /// Export the database out to a flat file so that the database
        /// information can be saved back up to the source control server.
        /// </summary>
        /// <param name="FullPath">The full path to where the exported database file should be stored.</param>
        public static void ExportAnnotations(string FullPath, string ProjectName)
        {
            string cmd =
                    // @"bcp CAE.dbo.Review_annotation out " +
                    // @"""" + FullPath + @"\" + DatabaseManager.EXPORT_FILE_NAME + 
                    // @""" -Slocalhost\sqlexpress -f " +
                    // @"""" + @".\resources\BCP_formats\" + FORMAT_FILE_NAME + @""" -T";

                    // @"bcp ""SELECT * FROM CAE.dbo.Review_annotation WHERE project_nm = 'cust_mgt' "" queryout " +
                    // @"""" + FullPath + @"\" + DatabaseManager.EXPORT_FILE_NAME + 
                    // @""" -Slocalhost\sqlexpress -f " +
                    // @"""" + @".\resources\BCP_formats\" + FORMAT_FILE_NAME + @""" -T";

                    @"bcp ""SELECT * FROM CAE.dbo.Review_annotation WHERE project_nm = '" +
                    @"" + ProjectName + @"' "" queryout " +
                    @"""" + FullPath + @"\" + DatabaseManager.EXPORT_FILE_NAME +
                    @""" -Slocalhost\sqlexpress -f " +
                    @"""" + @".\resources\BCP_formats\" + FORMAT_FILE_NAME + @""" -T";

            System.Diagnostics.ProcessStartInfo processStartInfo =
            new System.Diagnostics.ProcessStartInfo("CMD.exe", @"/C " + cmd);
            processStartInfo.CreateNoWindow = true;
            processStartInfo.UseShellExecute = false;
            System.Diagnostics.Process process =
               System.Diagnostics.Process.Start(processStartInfo);
            process.Close();
        }

        /// <summary>
        /// Import the database from a flat file to the staging table
        /// so that the data can be merged with the local database.
        /// </summary>
        /// <param name="ImportFile">The full path and file name
        ///    of the import file.  This is where the database will be loaded from.</param>
        /// <param name="rvwr_first_nm">The last name of the Reviewer</param>
        /// <param name="rvwr_last_nm">The first name of the Reviewer</param>
        public static StringBuilder ImportAnnotations(string ImportFile, string rvwr_last_nm, string rvwr_first_nm)
        {
            int waitTime = 6000; // Time to wait for BCP to finish.
            string cmd =
                @"bcp CAE.dbo.Import_Stage in " +
                @"""" + ImportFile + @""" -Slocalhost\sqlexpress -f " +
                @"""" + @".\resources\BCP_formats\" + FORMAT_FILE_NAME + @""" -T";

            // Wpe everything out of the Staging Table.
            DatabaseManager.TruncateStaging();

            // Import the flat file data into the Staging Table.
            System.Diagnostics.ProcessStartInfo processStartInfo =
            new System.Diagnostics.ProcessStartInfo();
            processStartInfo.FileName = "CMD.exe";
            processStartInfo.Arguments = "/C " + cmd;
            processStartInfo.CreateNoWindow = true;
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            processStartInfo.UseShellExecute = false;
            process.EnableRaisingEvents = true;

            // Wait until the process has completed.
            process.StartInfo = processStartInfo;
            process.Start();
            process.WaitForExit(waitTime);
            process.Close();
            
            // Merge annotations in the Import_Stage table into the local Review_annotation table.
            StringBuilder errorMessages = DatabaseManager.MergeAnnotations(rvwr_last_nm, rvwr_first_nm);
            return errorMessages;
        }

        /// <summary>
        /// Merge Annotations from Staging Table.
        /// </summary>
        /// <param name="rvwr_last_nm">The last name of the reviewer.</param>
        /// <param name="rvwr_first_nm">The first name of the reviewer.</param>
        /// <returns>Any error messages.</returns>
        private static StringBuilder MergeAnnotations(string rvwr_last_nm, string rvwr_first_nm)
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
        /// Call the stored procedure to wipe the information currently stored in the database.
        /// </summary>
        private static void TruncateStaging()
        {
            SqlConnection mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CAE.Properties.Settings.CAEConnectionString"].ToString());
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "EXECUTE dbo.trunc_staging";
            mySqlConnection.Open();
            mySqlCommand.ExecuteNonQuery();
            mySqlConnection.Close();
        }
    }
}
