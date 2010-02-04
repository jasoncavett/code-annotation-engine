using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAE.src.gui;

namespace CAE
{
    public partial class MainView : Form
    {
        public MainView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Response to the 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void aboutCodeAnnotationEngineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox box = new AboutBox();
            box.ShowDialog(this);
        }
    }
}
