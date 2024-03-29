﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using CAE.src.repository;
using NDepend.Helpers.FileDirectoryPath;

namespace CAE.src.gui
{
    public partial class NewProjectDialog : Form
    {
        public string ProjectName
        {
            get { return projectNameTextBox.Text; }
        }

        public string LocalPath
        {
            get { return localPathTextBox.Text; }
        }

        public string RepositoryPath
        {
            get { return repositoryPathTextBox.Text; }
        }

        public string UserName
        {
            get { return userNameTextBox.Text; }
        }

        public string Password
        {
            get { return passwordTextBox.Text; }
        }

        /// <summary>
        /// Initializing constructor.
        /// </summary>
        public NewProjectDialog()
        {
            InitializeComponent();

            // Specialized initializations.
            repositoryTypeComboBox.SelectedIndex = 0;
            okButton.Enabled = false;
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
                    userNameLabel.Show();
                    userNameTextBox.Clear();
                    userNameTextBox.Show();
                    passwordLabel.Show();
                    passwordTextBox.Clear();
                    passwordTextBox.Show();
                    break;
                case "Local":
                    repositoryPathLabel.Hide();
                    repositoryPathTextBox.Hide();
                    userNameLabel.Hide();
                    userNameTextBox.Hide();
                    passwordLabel.Hide();
                    passwordTextBox.Hide();
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

        /// <summary>
        /// Handle the clicking of the OK button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            // Set the result of the click.
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Make sure the project name exists and is valid before allowing a click to occur.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void validateFields_TextChanged(object sender, EventArgs e)
        {
            string reason;
            if (ProjectName.Length > 0 && PathHelper.IsValidAbsolutePath(LocalPath, out reason) && Directory.Exists(LocalPath))
            {
                okButton.Enabled = true;
            }
            else
            {
                okButton.Enabled = false;
            }
        }
    }
}
