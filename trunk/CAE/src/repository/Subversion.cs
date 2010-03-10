using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpSvn;
using NDepend.Helpers.FileDirectoryPath;
using System.Net;

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
        /// <param name="userName">The user's login name.</param>
        /// <param name="password">The user's password.</param>
        public void CheckIn(string localPath, string logMessage, string userName, string password)
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
        /// <param name="userName">The user's login name.</param>
        /// <param name="password">The user's password.</param>
        public void CheckOut(string repositoryPath, string localPath, string userName, string password)
        {
            using (SvnClient client = new SvnClient())
            {
                string reason;
                if (PathHelper.IsValidAbsolutePath(localPath, out reason))
                {
                    SvnUriTarget url = new SvnUriTarget(repositoryPath);
                    client.Authentication.DefaultCredentials = new NetworkCredential(userName, password);
                    client.CheckOut(url, localPath);
                }
                else
                {
                    throw new UriFormatException("Invalid Local Path: " + localPath + " because" + reason);
                }
            }
        }

        #endregion
    }
}
