using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAE.src.repository;

namespace CAE.src.project
{
    public class Project
    {
        public string Title { get; set; }
        public string LocalPath { get; set; }
        public string SvnPath { get; set; }

        /// <summary>
        /// Initializing constructor.  Determine if the project has already been created
        /// in a specific location.  If not, create the project with various files, etc.
        /// </summary>
        /// <param name="title">The title of the project.</param>
        /// <param name="localPath">The local path where the project will reside.</param>
        public Project(string title, string localPath)
        {
            Title = title;
            LocalPath = localPath;
        }

        /// <summary>
        /// Initializing constructor.
        /// </summary>
        /// <param name="title">The title of the project.</param>
        /// <param name="localPath">The local path where the project will reside.</param>
        /// <param name="remotePath">The remote path to the repository.</param>
        public Project(string title, string localPath, string remotePath) : this(title, localPath)
        {
            // Check out from the repository if a remote path was passed in.
            if (remotePath.Length > 0)
            {
                Subversion svn = new Subversion();
                svn.CheckOut(remotePath, localPath);
            }
        }
    }
}
