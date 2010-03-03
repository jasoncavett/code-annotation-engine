using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CAE.src.gui
{
    public partial class ProjectView : Panel
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ProjectView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializing constructor.
        /// </summary>
        /// <param name="container">The container to add this view to.</param>
        public ProjectView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
