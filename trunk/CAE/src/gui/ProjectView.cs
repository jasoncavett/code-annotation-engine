using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CAE.src.gui
{
    public partial class ProjectView : UserControl
    {
        public ProjectView()
        {
            InitializeComponent();
            SpecialInitializations();
        }

        /// <summary>
        /// Perform specialized initializations for this panel.
        /// </summary>
        private void SpecialInitializations()
        {
            // UserControl
            this.Dock = DockStyle.Fill;

            // File Browser
            browser1.ShowNavigationBar = false;
            browser1.ShowFolders = false;
            browser1.ShowFoldersButton = false;
        }
    }
}
