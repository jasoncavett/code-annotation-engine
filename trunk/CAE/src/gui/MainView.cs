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
            statusStrip1.Text = "Creating New Project...";

            // Ask the user for information about connecting to the project.
            using (NewProjectDialog dialog = new NewProjectDialog())
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    // Setup the project.
                    Project project = new Project(dialog.ProjectName, dialog.LocalPath, dialog.RepositoryPath, dialog.UserName, dialog.Password);

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

            // Export the database.
            // JM 2010-04-04 Added Project Name (string) to parms for ExportAnnotations
            // JM 2010-04-04 Hard-coded "order_mgt" since I wasn't sure what variable stored Project Name
            DatabaseManager.ExportAnnotations(project.LocalPath, "order_mgt");

            // Check the exported database into Subversion.
            Subversion svn = new Subversion();
            svn.CheckIn(project.LocalPath + @"\" + DatabaseManager.EXPORT_FILE_NAME, "Added annotations.", project.UserName, project.Password);

            project.SavedStatus = true;
        }

        /// <summary>
        /// Open a project that already exists on the user's local disc.
        /// 
        /// Currently, the opening of a project is not very smart and asks
        /// many of the similar questions that a new project would ask (in order
        /// to connect to a repository, gather user login information, etc).
        /// However, this will be made smarter in time.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            statusStrip1.Text = "Opening Project...";

            // Find the project folder using an OpenFileDialog.
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                // Setup the OpenFileDialog properties.
                ofd.CheckFileExists = true;
                ofd.Filter = "CAE Database (*.cae)|*.cae";
                ofd.InitialDirectory = Environment.SpecialFolder.MyDocuments.ToString();
                ofd.Multiselect = false;
                ofd.Title = "Open CAE Project";

                // Open the project if a database.cae file has been found.
                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    // Ask user for various pieces of information about the project.
                    // Ask the user for information about connecting to the project.
                    using (NewProjectDialog dialog = new NewProjectDialog())
                    {
                        if (dialog.ShowDialog(this) == DialogResult.OK)
                        {
                            // Setup the project.
                            Project project = new Project(dialog.ProjectName, dialog.LocalPath, dialog.RepositoryPath, dialog.UserName, dialog.Password);

                            // Import the annotations in to the database.
                            DatabaseManager.ImportAnnotations(ofd.FileName, project.AuthorName, "");

                            // Create the view to the project.
                            ProjectView projectView = new ProjectView(project);

                            // Create a tab in the project.
                            FATabStripItem tab = new FATabStripItem(projectView);
                            tab.Title = project.Title;
                            faTabStrip1.AddTab(tab, true);
                        }
                    }
                }
            }
        }
    }
}
