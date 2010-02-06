using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CAE.src.gui
{
    public partial class NewProjectDialog : Form
    {
        private MainView view;

        /// <summary>
        /// Initializing constructor.
        /// </summary>
        /// <param name="view">The MainView that this dialog is attached to.</param>
        public NewProjectDialog(MainView view)
        {
            this.view = view;
            InitializeComponent();
        }
    }
}
