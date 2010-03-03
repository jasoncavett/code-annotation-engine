using System;
using System.Configuration;
using System.Diagnostics;
using System.Windows.Forms;
using CAE.src.gui;
using CAE.src.project;
using System.IO;
using FarsiLibrary.Win;
using System.Drawing;

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
                    Project project = new Project(dialog.ProjectName, dialog.LocalPath, dialog.RepositoryPath);

                    // Create the view to the project.
                    ProjectView projectView = new ProjectView();

                    // Create a tab in the project.
                    // TODO - Add ProjectView to tab.
                    FATabStripItem tab = new FATabStripItem(projectView);
                    tab.Title = project.Title;
                    faTabStrip1.AddTab(tab, true);
                }
            }

            statusStrip1.ResetText();
        }
    }
}
