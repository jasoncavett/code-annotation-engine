﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAE.src.project;
using ScintillaNet;
using CAE.src.data;
using System.IO;
using NDepend.Helpers.FileDirectoryPath;

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
        /// Append a line of text to the current Scintilla document.
        /// </summary>
        /// <param name="line">The line to append.</param>
        private void AppendLine(string line)
        {
            scintilla1.AppendText(line);
            scintilla1.AppendText(Environment.NewLine);
        }

        /// <summary>
        /// Perform specialized initializations for this panel.
        /// </summary>
        private void SpecialInitializations()
        {
            // User Control Initializations (this)
            this.Dock = DockStyle.Fill;

            // File Browser Initializations
            browser1.StartUpDirectory = FileBrowser.SpecialFolders.Other;
            browser1.StartUpDirectoryOther = project.LocalPath;
        }

        #region Events

        /// <summary>
        /// Respond to a file being selected.
        /// </summary>
        /// <param name="selectedItem">The name of the current selected item.</param>
        private void browser1_SelectedFileChanged(string selectedItem)
        {
            // Make sure path and file are valid.
            string path = browser1.SelectedItem.Path + @"\" + selectedItem;
            FileAttributes attr = File.GetAttributes(path);
            string reason;
            if (PathHelper.IsValidAbsolutePath(path, out reason) && !((attr & FileAttributes.Directory) == FileAttributes.Directory))
            {
                scintilla1.ResetText();
                project.CurrentFile = selectedItem;
                using (StreamReader sr = File.OpenText(path))
                {
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        this.AppendLine(line);
                        line = sr.ReadLine();
                    }
                }
            }
        }

        /// <summary>
        /// Allow the addition of annotations when a margin is clicked.  The margin must be 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void scintilla1_MarginClick(object sender, MarginClickEventArgs e)
        {
            // Only add a marker if one is not already available.  Otherwise, retrieve the annotation
            // from the database and display that.
            if (e.Line.GetMarkers().Count == 0)
            {
                // Pop-up a dialog asking to add the annotation.
                using (AnnotationDialog annotation = new AnnotationDialog())
                {
                    if (annotation.ShowDialog(this) == DialogResult.OK)
                    {
                        // Store annotation information in the database.
                        DatabaseWriter.AddAnnotation(project.Title, project.CurrentFile, Convert.ToInt32(e.Line), project.AuthorName, "", annotation.Annotation);

                        // Display the annotation on the marker.
                        // TODO - Different markers for different users.
                        e.Line.AddMarker(15);
                    }
                }
            }
            else
            {
                // Display the annotation information.
                using (AnnotationDialog annotation = new AnnotationDialog())
                {
                    // Go to the database and grab the information for this specific annotation.
                    annotation.Annotation = DatabaseReader.GetAnnotation(project.Title, project.CurrentFile, Convert.ToInt32(e.Line), project.AuthorName, "");

                    if (annotation.ShowDialog(this) == DialogResult.OK)
                    {
                        DatabaseWriter.AddAnnotation(project.Title, project.CurrentFile, Convert.ToInt32(e.Line), project.AuthorName, "", annotation.Annotation);
                    }
                }
            }
        }

        #endregion
    }
}