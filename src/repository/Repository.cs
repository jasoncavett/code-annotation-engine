using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAE.src.repository
{
    /// <summary>
    /// Represents an interface to connect to a repository.
    /// </summary>
    interface Repository
    {
        /// <summary>
        /// Check in files to the repository.  Only files created by
        /// CAE should be checked in as not to affect the overall repository.
        /// 
        /// <param name="localPath">The local path of the repository.</param>
        /// <param name="logMessage">The message for the log file.</param>
        /// </summary>
        void CheckIn(string localPath, string logMessage);

        /// <summary>
        /// Check out files from a repository to a specific location.
        /// 
        /// <param name="repositoryPath">The path to the repository.</param>
        /// <param name="localPath">The location to store repository files.</param>
        /// </summary>
        void CheckOut(string repositoryPath, string localPath);
    }
}
