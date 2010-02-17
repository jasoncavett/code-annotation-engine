using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Alsing.SourceCode;

namespace CAE.src.gui
{
    public partial class ReviewWindow : Form
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public ReviewWindow()
        {
            InitializeComponent();
            populate();
        }

        /// <summary>
        /// Populate the text inside the document.  Determine filetype and
        /// perform syntax highlighting.
        /// </summary>
        /// <param name="text"></param>
        public void PopulateText(string text)
        {

        }

        public void populate()
        {
            StringBuilder goodText = new StringBuilder("blah blah blah\n");
            string fileName = "C:\\Documents and Settings\\Count Discord.JR-8A2D6B829A02\\My Documents\\Visual Studio 2008\\Projects\\JuJu\\test.txt";
            StreamReader reader;
            reader = File.OpenText(fileName);
            string tempString = reader.ReadLine();
            while (tempString != null)
            {
                goodText.AppendLine(tempString);
                tempString = reader.ReadLine();
            }
            reader.Close();
        }
    }
}
