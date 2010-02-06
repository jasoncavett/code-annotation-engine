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

        public void CheckIn(string localPath, string logMessage)
        {
            SvnCommitArgs args = new SvnCommitArgs();
            args.LogMessage = logMessage;

            using (SvnClient client = new SvnClient())
            {
                client.Commit(localPath, args);
            }
        }

        public void CheckOut(string repositoryPath, string localPath)
        {
            using (SvnClient client = new SvnClient())
            {
                client.CheckOut(new Uri(repositoryPath), localPath);
            }
        }

        #endregion
    }
}
