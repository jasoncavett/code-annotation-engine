using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace CAE.src.gui
{
    public partial class ReviewWindow : Form
    {
        public ReviewWindow()
        {
            InitializeComponent();
            populate();
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
            richTextBox1.Text = goodText.ToString();
            ///textbox.Text = goodText.ToString();

        }


        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.Text = "Testing\n";
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
         

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.ShowDialog();
        }

    
    }
}
