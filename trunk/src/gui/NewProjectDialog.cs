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

        /// <summary>
        /// Handle making the appropriate connections and files upon acceptance
        /// of the dialog (clicking the OK button).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            // TODO - Create the file structure to maintain annotations.
        }

        /// <summary>
        /// Update the view based on the index that has been selected.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void repositoryTypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (repositoryTypeComboBox.Text)
            {
                case "Subversion":
                    repositoryPathLabel.Show();
                    repositoryPathTextBox.Clear();
                    repositoryPathTextBox.Show();
                    break;
                case "Local":
                    repositoryPathLabel.Hide();
                    repositoryPathTextBox.Hide();
                    break;
            }
        }
    }
}
