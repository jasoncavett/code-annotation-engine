﻿using System;
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
    public partial class ProjectView : UserControl
    {
        public Project Project { get; set; }

        private Dictionary<string, Color> UserAnnotations;
        private double hue;

        /// <summary>
        /// Represents RGB color system.
        /// 
        /// From: http://www.geekymonkey.com/Programming/CSharp/RGB2HSL_HSL2RGB.htm
        /// </summary>
        public struct ColorRGB
        {
            public byte R;
            public byte G;
            public byte B;

            public ColorRGB(Color value)
            {
                this.R = value.R;
                this.G = value.G;
                this.B = value.B;
            }

            public static implicit operator Color(ColorRGB rgb)
            {
                Color c = Color.FromArgb(rgb.R, rgb.G, rgb.B);
                return c;
            }

            public static explicit operator ColorRGB(Color c)
            {
                return new ColorRGB(c);
            }
        }

        /// <summary>
        /// Initialization constructor.
        /// </summary>
        /// <param name="project">The project that this view represents.</param>
        public ProjectView(Project project)
        {
            this.Project = project;
            this.UserAnnotations = new Dictionary<string, Color>();
            this.hue = 0.0;

            InitializeComponent();
            SpecialInitializations();
        }

        /// <summary>
        /// Add a line marker to the Scintilla viewer.  Track the users who have already
        /// received line markers so that colors aren't reused and that color stays
        /// consistent across a user's session.  (This method does not currently worry
        /// about maintaining state within the database.)
        /// </summary>
        /// <param name="lineNo">The line to add the marker to.</param>
        /// <param name="reviewerName">The name of the reviewer.</param>
        private void AddLineMarker(int lineNo, string reviewerName)
        {
            Marker marker = scintilla1.Markers[1];

            // Generate the next color if the user annotations does
            // not already exist in the document.
            if (!UserAnnotations.ContainsKey(reviewerName))
            {
                hue += 0.03 % 1;
                ColorRGB c = HSL2RGB(hue, 0.5, 0.5);
                UserAnnotations[reviewerName] = c;
            }

            marker.BackColor = UserAnnotations[reviewerName];
            scintilla1.Lines[lineNo].AddMarker(marker);
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
        /// Given H,S,L in range of 0-1, returns a Color (RGB struct) in range of 0-255.
        /// </summary>
        /// <param name="h"></param>
        /// <param name="sl"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        private static ColorRGB HSL2RGB(double h, double sl, double l)
        {
            double v;
            double r, g, b;

            r = l;   // default to gray
            g = l;
            b = l;
            v = (l <= 0.5) ? (l * (1.0 + sl)) : (l + sl - l * sl);
            if (v > 0)
            {
                double m;
                double sv;
                int sextant;
                double fract, vsf, mid1, mid2;

                m = l + l - v;
                sv = (v - m) / v;
                h *= 6.0;
                sextant = (int)h;
                fract = h - sextant;
                vsf = v * sv * fract;
                mid1 = m + vsf;
                mid2 = v - vsf;
                switch (sextant)
                {
                    case 0:
                        r = v;
                        g = mid1;
                        b = m;
                        break;
                    case 1:
                        r = mid2;
                        g = v;
                        b = m;
                        break;
                    case 2:
                        r = m;
                        g = v;
                        b = mid1;
                        break;
                    case 3:
                        r = m;
                        g = mid2;
                        b = v;
                        break;
                    case 4:
                        r = mid1;
                        g = m;
                        b = v;
                        break;
                    case 5:
                        r = v;
                        g = m;
                        b = mid2;
                        break;
                }
            }
            ColorRGB rgb;
            rgb.R = Convert.ToByte(r * 255.0f);
            rgb.G = Convert.ToByte(g * 255.0f);
            rgb.B = Convert.ToByte(b * 255.0f);
            return rgb;
        }

        /// <summary>
        /// Set the type of parser to use to format this piece of code.
        /// </summary>
        private void SetLexigraphicalParser()
        {
            FileInfo info = new FileInfo(Project.CurrentFile);
            switch (info.Extension)
            {
                case ".java":   // Java
                    scintilla1.ConfigurationManager.Language = "java";
                    break;
                case ".cs":     // C#
                    scintilla1.ConfigurationManager.Language = "C#";
                    break;
                case ".pl":     // Perl
                    scintilla1.ConfigurationManager.Language = "Perl";
                    break;
                case ".awk":    // Awk
                    scintilla1.ConfigurationManager.Language = "awk";
                    break;
                case ".c":      // C
                    scintilla1.ConfigurationManager.Language = "C";
                    break;
                case ".vb":     // Visual Basic .Net
                    scintilla1.ConfigurationManager.Language = "Visual Basic .Net";
                    break;
                case ".cob":     // COBOL
                    scintilla1.ConfigurationManager.Language = "COBOL";
                    break;
                default:        // Not Supported
                    scintilla1.ConfigurationManager.Language = "default";
                    break;
            }
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
                // Open the file so it can be displayed.
                scintilla1.ResetText();
                Project.CurrentFile = selectedItem;
                this.SetLexigraphicalParser();
                using (StreamReader sr = File.OpenText(path))
                {
                    string line = sr.ReadLine();
                    while (line != null)
                    {
                        this.AppendLine(line);
                        line = sr.ReadLine();
                    }
                }

                // Retrieve the annotations for this file.
                DataSet annotations = DatabaseReader.ListAnnotations(Project.Title, Project.CurrentFile);
                DataTable table = annotations.Tables["list_annotations_by_file"];

                // Place each annotation on the window.
                foreach (DataRow row in table.Rows)
                {
                    this.AddLineMarker((Int32)row["codefile_line_no"], (string)row["rvwr_last_nm"] + (string)row["rvwr_first_nm"]);
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
            // Depending on the key that is pressed, annotations respond differently.

            // No annotations on the line mean to always ask for annotations no matter what
            // the modifier is.  Note that the response for the second half of this if statement is the same
            // as if no modifiers are pressed and a marker exists (the final else).  This is because, when
            // annotation support is added to ScintillaNET, the single click will display the annotations
            // inline.
            if (e.Line.GetMarkers().Count == 0)
            {
                // Pop-up a dialog asking to modify the annotation.
                using (AnnotationDialog annotation = new AnnotationDialog())
                {
                    annotation.Editable = true;
                    if (annotation.ShowDialog(this) == DialogResult.OK && annotation.Annotation.Length > 0)
                    {
                        // Store annotation information in the database, either as a new or a changed annotation.
                        if (e.Line.GetMarkers().Count == 0)
                        {
                            DatabaseWriter.AddAnnotation(Project.Title, Project.CurrentFile, e.Line.Number, Project.AuthorName, "", annotation.Annotation);
                        }
                        else
                        {
                            DatabaseWriter.ChangeAnnotation(Project.Title, Project.CurrentFile, e.Line.Number, Project.AuthorName, "", annotation.Annotation);
                        }

                        // Display the annotation on the marker.
                        this.AddLineMarker(e.Line.Number, Project.AuthorName);

                        // Mark the project as unsaved.
                        Project.SavedStatus = false;
                    }
                }
            }
            else if (e.Modifiers == Keys.Control)
            {
                // Allow the user to edit their own annotation if one exists at that location.
                string userAnnotation = DatabaseReader.GetAnnotation(Project.Title, Project.CurrentFile, e.Line.Number, Project.AuthorName, "");

                // Display the annotation information.
                using (AnnotationDialog annotation = new AnnotationDialog())
                {
                    annotation.Editable = true;
                    annotation.Annotation = userAnnotation;
                    if (annotation.ShowDialog(this) == DialogResult.OK)
                    {
                        // Store annotation information in the database, either as a new or a changed annotation.
                        if (userAnnotation.Length == 0)
                        {
                            DatabaseWriter.AddAnnotation(Project.Title, Project.CurrentFile, e.Line.Number, Project.AuthorName, "", annotation.Annotation);
                        }
                        else
                        {
                            DatabaseWriter.ChangeAnnotation(Project.Title, Project.CurrentFile, e.Line.Number, Project.AuthorName, "", annotation.Annotation);
                        }
                    }
                }
            }
            else if (e.Modifiers == Keys.Alt)
            {
                DatabaseWriter.DeleteAnnotation(Project.Title, Project.CurrentFile, e.Line.Number, Project.AuthorName, "");

                // See if all the annotations are deleted from that line.  Remove the markers if true.
                DataSet annotations = DatabaseReader.ListAnnotations(Project.Title, Project.CurrentFile, e.Line.Number);
                if (annotations.Tables["list_annotations_by_line"].Rows.Count == 0)
                {
                    e.Line.DeleteAllMarkers();
                }
            }
            else
            {
                // TODO - Display the annotation(s) inline.
                // This support has not yet been added to ScintillaNET.
                // See: http://scintillanet.codeplex.com/WorkItem/View.aspx?WorkItemId=25014

                // Display the annotation information.
                using (AnnotationDialog annotation = new AnnotationDialog())
                {
                    StringBuilder annotationBuilder = new StringBuilder();
                    DataSet data = DatabaseReader.ListAnnotations(Project.Title, Project.CurrentFile, e.Line.Number);
                    foreach (DataRow row in data.Tables["list_annotations_by_line"].Rows)
                    {
                        annotationBuilder.Append(row["rvwr_last_nm"] + " " + row["rvwr_first_nm"] + ": ");
                        annotationBuilder.Append(row["annotation_txt"]);
                        annotationBuilder.AppendLine();
                        annotationBuilder.AppendLine();
                    }
                    annotation.Annotation = annotationBuilder.ToString();
                    annotation.Editable = false;
                    annotation.ShowDialog(this);
                }
            }
        }

        #endregion
    }

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
}