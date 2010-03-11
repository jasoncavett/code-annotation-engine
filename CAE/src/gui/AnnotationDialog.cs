﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CAE.src.gui
{
    public partial class AnnotationDialog : Form
    {
        public string Annotation
        {
            get { return annotationTextBox.Text; }
            set { annotationTextBox.Text = value; }
        }

        public AnnotationDialog()
        {
            InitializeComponent();
        }
    }
}
