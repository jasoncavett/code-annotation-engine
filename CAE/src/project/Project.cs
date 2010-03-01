using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAE.src.project
{
    class Project
    {
        public string Title { get; set; }
        public string LocalPath { get; set; }

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

            // TODO - Initialize the product.
        }

        /// <summary>
        /// Initializing constructor.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="localPath"></param>
        /// <param name="remotePath"></param>
        public Project(string title, string localPath, string remotePath) : this(title, localPath)
        {
            // TODO - Connect to the remote path.
        }
    }
}
