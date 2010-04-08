using System;
using System.Configuration;
using System.Diagnostics;
using System.Windows.Forms;
using CAE.src.gui;
using CAE.src.project;
using System.IO;
using FarsiLibrary.Win;
using System.Drawing;
using CAE.src.data;
using CAE.src.repository;
using System.Threading;

namespace CAE
{
    public partial class MainView : Form
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public MainView()
        {
            InitializeComponent();

            // Restore the geometry of the window.
            Geometry.GeometryFromString(Properties.Settings.Default.WindowGeometry, this);
        }

        /// <summary>
        /// Return the current project based on the tab that is selected.
        /// </summary>
        /// <returns>The current project, or no project if one isn't open.</returns>
        private Project GetCurrentProject()
        {
            Project project = null;

            if (faTabStrip1.Items.Count > 0)
            {
                project = ((ProjectView)faTabStrip1.SelectedItem.Controls[0]).Project;
            }

            return project;
        }

        /// <summary>
        /// Response to clicking on the About Dialog Menu Item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutCodeAnnotationEngineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox box = new AboutBox();
            box.ShowDialog(this);
        }

        /// <summary>
        /// Response to clicking on the wiki menu item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void wikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo browser = new ProcessStartInfo(ConfigurationSettings.AppSettings["wikiAddress"]);
            Process.Start(browser);
        }

        /// <summary>
        /// Response to clicking on the license menu item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void licenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo browser = new ProcessStartInfo(ConfigurationSettings.AppSettings["license"]);
            Process.Start(browser);
        }

        /// <summary>
        /// Response to clicking on the "Report a Bug" menu item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reportABugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessStartInfo browser = new ProcessStartInfo(ConfigurationSettings.AppSettings["issuesAddress"]);
            Process.Start(browser);
        }

        /// <summary>
        /// Store the geometry of the form as the form is closing.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainView_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.WindowGeometry = Geometry.GeometryToString(this);
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Response to clicking on the "Exit" menu item.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Action for creating a new project.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip1.Text = "Connecting to Project...";

            // Ask the user for information about connecting to the project.
            using (NewProjectDialog dialog = new NewProjectDialog())
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    // Setup the project.
                    Project project = new Project(dialog.ProjectName, dialog.LocalPath, dialog.RepositoryPath, dialog.UserName, dialog.Password);

                    // Perform an update of the project information.
                    Subversion svn = new Subversion();
                    svn.Update(project.LocalPath, project.UserName, project.Password);

                    // Import the current values in the database if the database.cae file exists.
                    FileInfo databaseFile = new FileInfo(dialog.LocalPath + @"\" + DatabaseManager.EXPORT_FILE_NAME);
                    if (databaseFile.Exists)
                    {
                        DatabaseManager.ImportAnnotations(databaseFile.FullName, project.AuthorName, "");
                    }

                    // Create the view to the project.
                    ProjectView projectView = new ProjectView(project);

                    // Create a tab in the project.
                    FATabStripItem tab = new FATabStripItem(projectView);
                    tab.Title = project.Title;
                    faTabStrip1.AddTab(tab, true);
                }
            }

            statusStrip1.ResetText();
        }

        /// <summary>
        /// Perform a save of the current project.  A save involves a couple
        /// of actions.
        /// 
        /// 1. The database is exported to a flat file and stored in the top-level
        ///    directory of the project.
        /// 2. The exported database is then checked into Subversion.  This is done
        ///    without asking the user to reduce complexity.  Because code
        ///    cannot be edited directly in this application, there is no chance of
        ///    the code becoming out of sync with the database unless the user edits
        ///    code outside of the database.
        /// 3. The project is then marked as being saved.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveToolstripItem_Click(object sender, EventArgs e)
        {
            Project project = this.GetCurrentProject();

            // Export the database (only for a specific project).
            DatabaseManager.ExportAnnotations(project.LocalPath, project.Title);

            // Check the exported database into Subversion.
            Subversion svn = new Subversion();
            svn.CheckIn(project.LocalPath + @"\" + DatabaseManager.EXPORT_FILE_NAME, "Added annotations.", project.UserName, project.Password);

            project.SavedStatus = true;
        }
    }
}
