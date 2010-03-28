using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAE.src.data;
using CAE.src.project;
using NDepend.Helpers.FileDirectoryPath;
using ScintillaNet;

namespace CAE.src.gui
{
    class EventListener
    {
        private Project project;

        /// <summary>
        /// Initializing constructor.
        /// </summary>
        /// <param name="project">The project that will be monitored.</param>
        public EventListener(Project project)
        {
            this.project = project;
            this.project.Changed += new ChangedEventHandler(ProjectChanged);
        }

        /// <summary>
        /// Called whenever the project changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProjectChanged(object sender, EventArgs e)
        {
            Console.WriteLine("The project's status changed to: " + project.SavedStatus);
        }

        /// <summary>
        /// Detach the event.
        /// </summary>
        public void Detach()
        {
            project.Changed -= new ChangedEventHandler(ProjectChanged);
            project = null;
        }
    }

    public partial class ProjectView : UserControl
    {
        public Project Project { get; set; }

        /// <summary>
        /// Initialization constructor.
        /// </summary>
        /// <param name="project">The project that this view represents.</param>
        public ProjectView(Project project)
        {
            this.Project = project;

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

            // Create a class to listen to the project's change events.
            EventListener listener = new EventListener(Project);

            // File Browser Initializations
            browser1.StartUpDirectory = FileBrowser.SpecialFolders.Other;
            browser1.StartUpDirectoryOther = Project.LocalPath;
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
                Project.CurrentFile = selectedItem;
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
                        DatabaseWriter.AddAnnotation(Project.Title, Project.CurrentFile, Convert.ToInt32(e.Line), Project.AuthorName, "", annotation.Annotation);

                        // Display the annotation on the marker.
                        // TODO - Different markers for different users.
                        e.Line.AddMarker(15);

                        // Mark the project as unsaved.
                        Project.SavedStatus = false;
                    }
                }
            }
            else
            {
                // Display the annotation information.
                using (AnnotationDialog annotation = new AnnotationDialog())
                {
                    // Go to the database and grab the information for this specific annotation.
                    annotation.Annotation = DatabaseReader.GetAnnotation(Project.Title, Project.CurrentFile, Convert.ToInt32(e.Line), Project.AuthorName, "");

                    if (annotation.ShowDialog(this) == DialogResult.OK)
                    {
                        DatabaseWriter.AddAnnotation(Project.Title, Project.CurrentFile, Convert.ToInt32(e.Line), Project.AuthorName, "", annotation.Annotation);
                    }
                }
            }
        }

        #endregion
    }
}