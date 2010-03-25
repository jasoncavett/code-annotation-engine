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
        /// Return all the available projects.
        /// </summary>
        /// <returns>A data set containing all the projects.</returns>
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

        /// <summary>
        /// Return all the available reviewers for a project.
        /// </summary>
        /// <param name="project_nm">The name of the project.</param>
        /// <returns>The reviewers for a project.</returns>
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

        /// <summary>
        /// List all the annotations for a specific codefile within a project.
        /// </summary>
        /// <param name="project_nm">The name of the project.</param>
        /// <param name="codefile_nm">The name of the module.</param>
        /// <returns>A list of all the annotations in a module.</returns>
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

        public static DataSet ListAnnotations(string project_nm, string codefile_nm, int codefile_line_no)
        {
            DataSet data = new DataSet();
            SqlConnection mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CAE.Properties.Settings.CAEConnectionString"].ToString());
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "EXECUTE dbo.list_annotations_by_line @project_nm, @codefile_nm, @codefile_line_no";
            mySqlCommand.Parameters.Add("@project_nm", SqlDbType.VarChar, 20).Value = project_nm;
            mySqlCommand.Parameters.Add("@codefile_nm", SqlDbType.VarChar, 50).Value = codefile_nm;
            mySqlCommand.Parameters.Add("@codefile_line_no", SqlDbType.Int).Value = codefile_line_no;
            SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter();
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            mySqlConnection.Open();
            int numberOfRows = mySqlDataAdapter.Fill(data, "list_annotations_by_line");
            mySqlConnection.Close();

            return data;
        }

        /// <summary>
        /// List all the annotations for a specific codefile made by a specific individual.
        /// </summary>
        /// <param name="project_nm">The name of the project.</param>
        /// <param name="codefile_nm">The name of the module within the project.</param>
        /// <param name="rvwr_last_nm">The reviewer's last name.</param>
        /// <param name="rvwr_first_nm">The reviewer's first name.</param>
        /// <returns>A dataset of the list of annotations in a specific file from a specific reviewer.</returns>
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

        /// <summary>
        /// Return a specific annotation.
        /// </summary>
        /// <param name="project_nm">The name of the project.</param>
        /// <param name="codefile_nm">The name of the code file.</param>
        /// <param name="codefile_line_no">The line number that the annotation is on.</param>
        /// <param name="rvwr_last_nm">The last name of the reviewer.</param>
        /// <param name="rvwr_first_nm">The first name of the reviewer.</param>
        /// <returns>The annotation string.</returns>
        public static String GetAnnotation(string project_nm, string codefile_nm, int codefile_line_no, string rvwr_last_nm, string rvwr_first_nm)
        {
            DataSet data = new DataSet();
            SqlConnection mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CAE.Properties.Settings.CAEConnectionString"].ToString());
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "EXECUTE dbo.get_annotation @project_nm, @codefile_nm, @codefile_line_no, @rvwr_last_nm, @rvwr_first_nm";
            mySqlCommand.Parameters.Add("@project_nm", SqlDbType.VarChar, 20).Value = project_nm;
            mySqlCommand.Parameters.Add("@codefile_nm", SqlDbType.VarChar, 50).Value = codefile_nm;
            mySqlCommand.Parameters.Add("@codefile_line_no", SqlDbType.Int).Value = codefile_line_no;
            mySqlCommand.Parameters.Add("@rvwr_last_nm", SqlDbType.VarChar, 20).Value = rvwr_last_nm;
            mySqlCommand.Parameters.Add("@rvwr_first_nm", SqlDbType.VarChar, 20).Value = rvwr_first_nm;
            SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter();
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            mySqlConnection.Open();
            int numberOfRows = mySqlDataAdapter.Fill(data, "get_annotation");
            mySqlConnection.Close();

            return data.Tables[0].Rows[0]["annotation_txt"].ToString(); ;
        }

        /// <summary>
        /// Return the information associated with a specific codefile within a project.
        /// </summary>
        /// <param name="project_nm">The name of the project.</param>
        /// <param name="codefile_nm">The name of the module.</param>
        /// <returns>The dataset of a specific module in a project.</returns>
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

        /// <summary>
        /// Return the information associated with a specific project.
        /// </summary>
        /// <param name="project_nm">The name of the project.</param>
        /// <returns>Get a specific project.</returns>
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

        /// <summary>
        /// Return the information associated with a specific reviewer.
        /// </summary>
        /// <param name="project_nm">The project name.</param>
        /// <param name="rvwr_last_nm">The last name of the reviewer.</param>
        /// <param name="rvwr_first_nm">The first name of the reviewer.</param>
        /// <returns>The information associated with a specific reviewer.</returns>
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