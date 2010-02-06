using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CAE.src.repository
{
    /// <summary>
    /// Provides a connection to a local repository.
    /// </summary>
    class Local : Repository
    {
        #region Repository Members

        public void CheckIn(string localPath, string logMessage)
        {
            throw new NotImplementedException();
        }

        public void CheckOut(string repositoryPath, string localPath)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
