using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CAE.src.project
{
    public static class ProjectWriter
    {
        /// <summary>
        /// Read a project file from a local path.
        /// </summary>
        /// <param name="path">The path to the project file.</param>
        /// <returns>The project built from the project file.</returns>
        public static Project ReadProject(string path)
        {
            Project project = null;

            // Parse the file and build the project.
            if (File.Exists(path))
            {
            }

            return project;
        }

        /// <summary>
        /// Write a project to a specified path.  The path is defined as the
        /// local path inside the project itself.
        /// </summary>
        /// <param name="project">The project to write.</param>
        public static void WriteProject(Project project)
        {

        }
    }
}
