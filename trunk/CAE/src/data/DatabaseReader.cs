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
        /// List the available modules for a project.
        /// </summary>
        /// <param name="project_nm">The project name.</param>
        /// <returns>The available modules for a project.</returns>
        public static DataSet ListModules(string project_nm)
        {
            DataSet data = new DataSet();
            SqlConnection mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CAE.Properties.Settings.CAEConnectionString"].ToString());
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "EXECUTE dbo.list_mods @project_nm";
            mySqlCommand.Parameters.Add("@project_nm", SqlDbType.VarChar, 20).Value = project_nm;
            SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter();
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            mySqlConnection.Open();
            int numberOfRows = mySqlDataAdapter.Fill(data, "list_mods");
            mySqlConnection.Close();

            return data;
        }

        /// <summary>
        /// List all revisions for a given module for a project
        /// </summary>
        /// <param name="project_nm"></param>
        /// <param name="module_nm"></param>
        /// <returns>The available revisions for a given module for a project.</returns>
        public static DataSet ListModuleRevisions(string project_nm, string module_nm)
        {
            DataSet data = new DataSet();
            SqlConnection mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CAE.Properties.Settings.CAEConnectionString"].ToString());
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "EXECUTE dbo.list_mod_revs @project_nm, @module_nm";
            mySqlCommand.Parameters.Add("@project_nm", SqlDbType.VarChar, 20).Value = project_nm;
            mySqlCommand.Parameters.Add("@module_nm", SqlDbType.VarChar, 50).Value = module_nm;
            SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter();
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            mySqlConnection.Open();
            int numberOfRows = mySqlDataAdapter.Fill(data, "list_mod_revs");
            mySqlConnection.Close();

            return data;
        }

        public static DataSet ListReviewEvents(string project_nm, string module_nm, decimal revision_no)
        {
            DataSet data = new DataSet();
            SqlConnection mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CAE.Properties.Settings.CAEConnectionString"].ToString());
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "EXECUTE dbo.list_revw_evnts @project_nm, @module_nm, @revision_no";
            mySqlCommand.Parameters.Add("@project_nm", SqlDbType.VarChar, 20).Value = project_nm;
            mySqlCommand.Parameters.Add("@module_nm", SqlDbType.VarChar, 50).Value = module_nm;
            SqlParameter revno = mySqlCommand.Parameters.Add("@revision_no", SqlDbType.Decimal);
            revno.Value = revision_no;
            revno.Precision = 6;
            revno.Scale = 3;
            SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter();
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            mySqlConnection.Open();
            int numberOfRows = mySqlDataAdapter.Fill(data, "list_revw_evnts");
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

        public static DataSet ListAnnotations(string project_nm, string module_nm, decimal revision_no, string rvw_event_dt)
        {
            DataSet data = new DataSet();
            SqlConnection mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CAE.Properties.Settings.CAEConnectionString"].ToString());
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "EXECUTE dbo.list_annotations_by_evnt @project_nm, @module_nm, @revision_no, @rvw_event_dt";
            mySqlCommand.Parameters.Add("@project_nm", SqlDbType.VarChar, 20).Value = project_nm;
            mySqlCommand.Parameters.Add("@module_nm", SqlDbType.VarChar, 50).Value = module_nm;
            SqlParameter revno = mySqlCommand.Parameters.Add("@revision_no", SqlDbType.Decimal);
            revno.Value = revision_no;
            revno.Precision = 6;
            revno.Scale = 3;
            mySqlCommand.Parameters.Add("@rvw_event_dt", SqlDbType.DateTime).Value = rvw_event_dt;
            SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter();
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            mySqlConnection.Open();
            int numberOfRows = mySqlDataAdapter.Fill(data, "list_annotations_by_evnt");
            mySqlConnection.Close();

            return data;
        }

        public static DataSet ListAnnotations(string project_nm, string module_nm, decimal revision_no, string rvw_event_dt, string rvwr_last_nm, string rvwr_first_nm)
        {
            DataSet data = new DataSet();
            SqlConnection mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CAE.Properties.Settings.CAEConnectionString"].ToString());
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "EXECUTE dbo.list_annotations_by_evnt_rvwr @project_nm, @module_nm, @revision_no, @rvw_event_dt, @rvwr_last_nm, @rvwr_first_nm";
            mySqlCommand.Parameters.Add("@project_nm", SqlDbType.VarChar, 20).Value = project_nm;
            mySqlCommand.Parameters.Add("@module_nm", SqlDbType.VarChar, 50).Value = module_nm;
            SqlParameter revno = mySqlCommand.Parameters.Add("@revision_no", SqlDbType.Decimal);
            revno.Value = revision_no;
            revno.Precision = 6;
            revno.Scale = 3;
            mySqlCommand.Parameters.Add("@rvw_event_dt", SqlDbType.DateTime).Value = rvw_event_dt;
            mySqlCommand.Parameters.Add("@rvwr_last_nm", SqlDbType.VarChar, 20).Value = rvwr_last_nm;
            mySqlCommand.Parameters.Add("@rvwr_first_nm", SqlDbType.VarChar, 20).Value = rvwr_first_nm;
            SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter();
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            mySqlConnection.Open();
            int numberOfRows = mySqlDataAdapter.Fill(data, "list_annotations_by_evnt_rvwr");
            mySqlConnection.Close();

            return data;
        }

        public static DataSet GetModule(string project_nm, string module_nm)
        {
            DataSet data = new DataSet();
            SqlConnection mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CAE.Properties.Settings.CAEConnectionString"].ToString());
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "EXECUTE dbo.get_mod @project_nm, @module_nm";
            mySqlCommand.Parameters.Add("@project_nm", SqlDbType.VarChar, 20).Value = project_nm;
            mySqlCommand.Parameters.Add("@module_nm", SqlDbType.VarChar, 50).Value = module_nm;
            SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter();
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            mySqlConnection.Open();
            int numberOfRows = mySqlDataAdapter.Fill(data, "get_mod");
            mySqlConnection.Close();

            return data;
        }

        public static DataSet GetModuleRevision(string project_nm, string module_nm, decimal revision_no)
        {
            DataSet data = new DataSet();
            SqlConnection mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CAE.Properties.Settings.CAEConnectionString"].ToString());
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "EXECUTE dbo.get_mod_rev @project_nm, @module_nm, @revision_no";
            mySqlCommand.Parameters.Add("@project_nm", SqlDbType.VarChar, 20).Value = project_nm;
            mySqlCommand.Parameters.Add("@module_nm", SqlDbType.VarChar, 50).Value = module_nm;
            SqlParameter revno = mySqlCommand.Parameters.Add("@revision_no", SqlDbType.Decimal);
            revno.Value = revision_no;
            revno.Precision = 6;
            revno.Scale = 3;
            SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter();
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            mySqlConnection.Open();
            int numberOfRows = mySqlDataAdapter.Fill(data, "get_mod_rev");
            mySqlConnection.Close();

            return data;
        }

        public static DataSet GetReviewEvent(string project_nm, string module_nm, decimal revision_no, string rvw_event_dt)
        {
            DataSet data = new DataSet();
            SqlConnection mySqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["CAE.Properties.Settings.CAEConnectionString"].ToString());
            SqlCommand mySqlCommand = mySqlConnection.CreateCommand();
            mySqlCommand.CommandText = "EXECUTE dbo.get_revw_evnt @project_nm, @module_nm, @revision_no, @rvw_event_dt";
            mySqlCommand.Parameters.Add("@project_nm", SqlDbType.VarChar, 20).Value = project_nm;
            mySqlCommand.Parameters.Add("@module_nm", SqlDbType.VarChar, 50).Value = module_nm;
            SqlParameter revno = mySqlCommand.Parameters.Add("@revision_no", SqlDbType.Decimal);
            revno.Value = revision_no;
            revno.Precision = 6;
            revno.Scale = 3;
            mySqlCommand.Parameters.Add("@rvw_event_dt", SqlDbType.DateTime).Value = rvw_event_dt;
            SqlDataAdapter mySqlDataAdapter = new SqlDataAdapter();
            mySqlDataAdapter.SelectCommand = mySqlCommand;
            mySqlConnection.Open();
            int numberOfRows = mySqlDataAdapter.Fill(data, "get_revw_evnt");
            mySqlConnection.Close();

            return data;
        }
    }
}