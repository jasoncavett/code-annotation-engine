using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpSvn;

namespace CAE.src.repository
{
    /// <summary>
    /// Provide a connection to a Subversion repository.
    /// </summary>
    class Subversion : Repository
    {
        #region Repository Members

        /// <summary>
        /// Commit a project to a Subversion repository.
        /// </summary>
        /// <param name="localPath">The local path to the repository.</param>
        /// <param name="logMessage">The log message associated with the commit.</param>
        public void CheckIn(string localPath, string logMessage)
        {
            SvnCommitArgs args = new SvnCommitArgs();
            args.LogMessage = logMessage;

            using (SvnClient client = new SvnClient())
            {
                client.Commit(localPath, args);
            }
        }

        /// <summary>
        /// Check out a project from a repository location.
        /// </summary>
        /// <param name="repositoryPath">The remote, repository path.</param>
        /// <param name="localPath">The local, working path.</param>
        public void CheckOut(string repositoryPath, string localPath)
        {
            using (SvnClient client = new SvnClient())
            {
                if (Uri.IsWellFormedUriString(repositoryPath, UriKind.Absolute))
                {
                    client.CheckOut(new Uri(repositoryPath), localPath);
                }
                else
                {
                    throw new UriFormatException("Invalid Subversion uri");
                }
            }
        }

        #endregion
    }
}
