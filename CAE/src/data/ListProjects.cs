using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CAE.src.data
{
    public partial class ListProjects : Form
    {
        public ListProjects()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataSet myDataSet = DatabaseReader.ListProjects();
        }
 
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ListProjects_Load(object sender, EventArgs e)
        {
            DataSet myDataSet = DatabaseReader.ListProjects();
        }
    }
}
