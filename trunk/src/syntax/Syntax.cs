using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CAE.src.syntax
{
    /// <summary>
    /// The Syntax class provides the base, abstract class for providing
    /// syntax highlighting for various types of source files that can
    /// be read into the application.
    /// </summary>
    abstract class Syntax
    {
        /// <summary>
        /// Apply syntax highlighting to the source code that is read in from
        /// a stream.  Return a ??? that provides the view to the highlghted
        /// code.
        /// </summary>
        /// <param name="stream">The stream to apply syntax highlighting to.</param>
        public abstract void ApplySyntax(Stream stream);
    }
}
