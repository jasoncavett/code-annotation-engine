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
        /// </summary>
        public void CheckIn();

        /// <summary>
        /// Check out files from a repository to a specific location.
        /// </summary>
        public void CheckOut();

        /// <summary>
        /// Make a connection to the repository.
        /// </summary>
        public void ConnectToRepository();
    }
}
