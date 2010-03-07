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
       
        }

        /// <summary>
        /// Populate the text inside the document.  Determine filetype and
        /// perform syntax highlighting.
        /// </summary>
        /// <param name="text"></param>
        public void PopulateText(string text)
        {
            //Alsing.Design.ComponaCollectionEditor;
            //Alsing.Windows.Forms.SyntaxBoxControl = new Alsing.Windows.Forms.SyntaxBoxControl newDoc;


        }

        private void syntaxBoxControl1_Click(object sender, EventArgs e)
        {
           
        }

        private void baseListBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void syntaxBoxControl1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Testing...");

            OpenFileDialog x = new OpenFileDialog();
            x.ShowDialog();
            SyntaxDocument MyDoc = new SyntaxDocument();
           
            //SyntaxDocument Doc = MySyntaxBox.Document;
            //OpenFileDialog x = new OpenFileDialog();
            //x.ShowDialog();
            //MyDoc.Text = "hello world";
            //MyDoc.InsertText("Hellow World", 3, 12, true);
            //MyDoc.ShowFind();
            //StreamReader Test1 = new StreamReader(sender);
            //MyDoc.Add;

                        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog x = new OpenFileDialog();
            x.ShowDialog();
            
        }



        
    }
}
