using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CAE.src.gui;

namespace CAE.src_test.gui
{
    class ReviewWindowDriver
    {
        /// <summary>
        /// The main entry point for the ReviewWindow.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ReviewWindow());
        }
    }
}
