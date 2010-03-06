using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace CAE.src.project
{
    public static class ProjectWriter
    {
        private const string PROJECT_FILE_NAME = "project.cae";

        /// <summary>
        /// Read a project file from a local path.  If the path is not available,
        /// a null project will be returned.
        /// </summary>
        /// <param name="path">The path to the project file.</param>
        /// <returns>The project built from the project file.</returns>
        public static Project ReadProject(string path)
        {
            Project project = null;

            // Parse the file and build the project.
            if (File.Exists(path))
            {
                XmlTextReader textReader = new XmlTextReader(path);
                textReader.Read();

                while (textReader.Read())
                {
                    switch (textReader.Name)
                    {
                        case "project-name":
                            project.Title = textReader.Value;
                            break;
                        case "svn-path":
                            project.SvnPath = textReader.Value;
                            break;
                    }
                }
            }

            return project;
        }

        /// <summary>
        /// Write a project to a specified path.  The path is defined as the
        /// local path inside the project itself.
        /// </summary>
        /// <param name="project">The project to write.</param>
        /// <param name="path">The path that the project file will be written.</param>
        public static void WriteProject(Project project, string path)
        {
            if (Directory.Exists(path))
            {
                FileStream fs = new FileStream(path + ProjectWriter.PROJECT_FILE_NAME, FileMode.Create);

                XmlWriter w = XmlWriter.Create(fs);

                w.WriteStartDocument();
                w.WriteStartElement("project");

                w.WriteElementString("project-name", project.Title);
                w.WriteElementString("svn-path", project.SvnPath);
                
                w.WriteEndElement();
                w.WriteEndDocument();
                w.Flush();

                fs.Close();
            }
        }
    }
}
