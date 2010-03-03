using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAE.src.project;

namespace CAE.src.gui
{
    public partial class ProjectView : UserControl
    {
        private Project project;

        /// <summary>
        /// Initialization constructor.
        /// </summary>
        /// <param name="project">The project that this view represents.</param>
        public ProjectView(Project project)
        {
            this.project = project;

            InitializeComponent();
            SpecialInitializations();
        }

        /// <summary>
        /// Perform specialized initializations for this panel.
        /// </summary>
        private void SpecialInitializations()
        {
            // User Control Initializations (this)
            this.Dock = DockStyle.Fill;

            // File Browser Initializations
            browser1.ShowNavigationBar = false;
            browser1.ShowFolders = false;
            browser1.ShowFoldersButton = false;
            browser1.StartUpDirectory = FileBrowser.SpecialFolders.Other;
            browser1.StartUpDirectoryOther = project.LocalPath;
        }
    }
}
