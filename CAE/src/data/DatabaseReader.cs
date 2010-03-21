using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CAE.src.data
{
    public static class DatabaseReader
    {
        /// <summary>
        /// List all projecst.
        /// </summary>
        /// no parameters
        /// <returns>The projects.</returns>
        public static DataSet ListProjects()
        {
            DataSet data = new DataSet();
            SqlConnection mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CAE.Properties.Settings.CAEConnectionString"].ToString());
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "EXECUTE dbo.list_projects";
            SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter();
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            mySqlConnection.Open();
            int numberOfRows = mySqlDataAdapter.Fill(data, "list_projects");
            mySqlConnection.Close();

            return data;
        }

        /// <summary>
        /// List the available codefiles for a project.
        /// </summary>
        /// <param name="project_nm">The project name.</param>
        /// <returns>The available modules for a project.</returns>
        public static DataSet ListFiles(string project_nm)
        {
            DataSet data = new DataSet();
            SqlConnection mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CAE.Properties.Settings.CAEConnectionString"].ToString());
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "EXECUTE dbo.list_files @project_nm";
            mySqlCommand.Parameters.Add("@project_nm", SqlDbType.VarChar, 20).Value = project_nm;
            SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter();
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            mySqlConnection.Open();
            int numberOfRows = mySqlDataAdapter.Fill(data, "list_files");
            mySqlConnection.Close();

            return data;
        }

        public static DataSet ListReviewers(string project_nm)
        {
            DataSet data = new DataSet();
            SqlConnection mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CAE.Properties.Settings.CAEConnectionString"].ToString());
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "EXECUTE dbo.list_rvwrs @project_nm";
            mySqlCommand.Parameters.Add("@project_nm", SqlDbType.VarChar, 20).Value = project_nm;
            SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter();
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            mySqlConnection.Open();
            int numberOfRows = mySqlDataAdapter.Fill(data, "list_rvwrs");
            mySqlConnection.Close();

            return data;
        }

        public static DataSet ListAnnotations(string project_nm, string codefile_nm)
        {
            DataSet data = new DataSet();
            SqlConnection mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CAE.Properties.Settings.CAEConnectionString"].ToString());
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "EXECUTE dbo.list_annotations_by_file @project_nm, @codefile_nm";
            mySqlCommand.Parameters.Add("@project_nm", SqlDbType.VarChar, 20).Value = project_nm;
            mySqlCommand.Parameters.Add("@codefile_nm", SqlDbType.VarChar, 50).Value = codefile_nm;
            SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter();
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            mySqlConnection.Open();
            int numberOfRows = mySqlDataAdapter.Fill(data, "list_annotations_by_file");
            mySqlConnection.Close();

            return data;
        }

        public static DataSet ListAnnotations(string project_nm, string codefile_nm, string rvwr_last_nm, string rvwr_first_nm)
        {
            DataSet data = new DataSet();
            SqlConnection mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CAE.Properties.Settings.CAEConnectionString"].ToString());
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "EXECUTE dbo.list_annotations_by_file_rvwr @project_nm, @codefile_nm, @rvwr_last_nm, @rvwr_first_nm";
            mySqlCommand.Parameters.Add("@project_nm", SqlDbType.VarChar, 20).Value = project_nm;
            mySqlCommand.Parameters.Add("@codefile_nm", SqlDbType.VarChar, 50).Value = codefile_nm;
            mySqlCommand.Parameters.Add("@rvwr_last_nm", SqlDbType.VarChar, 20).Value = rvwr_last_nm;
            mySqlCommand.Parameters.Add("@rvwr_first_nm", SqlDbType.VarChar, 20).Value = rvwr_first_nm;
            SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter();
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            mySqlConnection.Open();
            int numberOfRows = mySqlDataAdapter.Fill(data, "list_annotations_by_file_rvwr");
            mySqlConnection.Close();

            return data;
        }

        public static DataSet GetFile(string project_nm, string codefile_nm)
        {
            DataSet data = new DataSet();
            SqlConnection mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CAE.Properties.Settings.CAEConnectionString"].ToString());
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "EXECUTE dbo.get_file @project_nm, @codefile_nm";
            mySqlCommand.Parameters.Add("@project_nm", SqlDbType.VarChar, 20).Value = project_nm;
            mySqlCommand.Parameters.Add("@codefile_nm", SqlDbType.VarChar, 50).Value = codefile_nm;
            SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter();
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            mySqlConnection.Open();
            int numberOfRows = mySqlDataAdapter.Fill(data, "get_file");
            mySqlConnection.Close();

            return data;
        }
        public static DataSet GetProject(string project_nm)
        {
            DataSet data = new DataSet();
            SqlConnection mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CAE.Properties.Settings.CAEConnectionString"].ToString());
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "EXECUTE dbo.get_project @project_nm";
            mySqlCommand.Parameters.Add("@project_nm", SqlDbType.VarChar, 20).Value = project_nm;
            SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter();
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            mySqlConnection.Open();
            int numberOfRows = mySqlDataAdapter.Fill(data, "get_project");
            mySqlConnection.Close();

            return data;
        }
        public static DataSet GetReviewer(string project_nm, string rvwr_last_nm, string rvwr_first_nm)
        {
            DataSet data = new DataSet();
            SqlConnection mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CAE.Properties.Settings.CAEConnectionString"].ToString());
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "EXECUTE dbo.get_rvwr @project_nm, @rvwr_last_nm, @rvwr_first_nm";
            mySqlCommand.Parameters.Add("@project_nm", SqlDbType.VarChar, 20).Value = project_nm;
            mySqlCommand.Parameters.Add("@rvwr_last_nm", SqlDbType.VarChar, 20).Value = rvwr_last_nm;
            mySqlCommand.Parameters.Add("@rvwr_first_nm", SqlDbType.VarChar, 20).Value = rvwr_first_nm;
            SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter();
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            mySqlConnection.Open();
            int numberOfRows = mySqlDataAdapter.Fill(data, "get_rvwr");
            mySqlConnection.Close();

            return data;
         }
    }
}