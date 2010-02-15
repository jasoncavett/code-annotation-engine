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

        public string LocalPath
        {
            get { return localPathTextBox.Text; }
        }

        public string RepositoryPath
        {
            get { return repositoryPathTextBox.Text; }
        }

        /// <summary>
        /// Initializing constructor.
        /// </summary>
        /// <param name="view">The MainView that this dialog is attached to.</param>
        public NewProjectDialog(MainView view)
        {
            this.view = view;
            InitializeComponent();

            repositoryTypeComboBox.SelectedIndex = 0;
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

        /// <summary>
        /// Browse to a folder that contains a project.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void browseFoldersButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.RootFolder = Environment.SpecialFolder.MyComputer;
                dialog.Description = "Select the root folder of your software project.";

                // Populate the local folder field if a folder is selected.
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    this.localPathTextBox.Text = dialog.SelectedPath;
                }
            }
        }
    }
}
