using System;
using System.Configuration;
using System.Diagnostics;
using System.Windows.Forms;
using CAE.src.gui;

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
    }
}
