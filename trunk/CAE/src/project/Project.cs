using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CAE.src.repository;

namespace CAE.src.project
{
    // A delegate type for hooking up changes to the saved status of a project.
    public delegate void ChangedEventHandler(object sender, EventArgs e);

    public class Project
    {
        // An event that clients can use to know whenever the saved status
        // of the project changes.
        public event ChangedEventHandler Changed;
        
        // Invoke the Changed event; called whenever the project changes.
        protected virtual void OnChanged(EventArgs e)
        {
            if (Changed != null)
            {
                Changed(this, e);
            }
        }

        // Information specific to the project.
        public string Title { get; set; }
        public string CurrentFile { get; set; }
        public string LocalPath { get; set; }
        public string RemotePath { get; set; }
        public string AuthorName { get { return Environment.UserName; } }
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool SavedStatus { get; set; }
        //{
        //    get { return SavedStatus; }
        //    set { SavedStatus = value; OnChanged(EventArgs.Empty); }
        //}

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
        /// <param name="userName">The user's login name.</param>
        /// <param name="password">The user's password.</param>
        public Project(string title, string localPath, string remotePath, string userName, string password) : this(title, localPath)
        {
            RemotePath = remotePath;
            UserName = userName;
            Password = password;

            // Check out from the repository if a remote path was passed in.
            if (remotePath.Length > 0)
            {
                // If this constructor is called, then it is assumed that the project
                // needs to connect to a repository.  Only Subversion is supported right now.
                Subversion svn = new Subversion();
                svn.CheckOut(remotePath, localPath, userName, password);
            }
        }
    }
}
