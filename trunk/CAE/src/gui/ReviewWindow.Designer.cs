namespace CAE.src.gui
{
    partial class ReviewWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.syntaxDocument1 = new Alsing.SourceCode.SyntaxDocument(this.components);
            this.baseListBoxControl1 = new Alsing.Windows.Forms.BaseListBoxControl();
            this.syntaxBoxControl1 = new Alsing.Windows.Forms.SyntaxBoxControl();
            this.syntaxDocument2 = new Alsing.SourceCode.SyntaxDocument(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // syntaxDocument1
            // 
            this.syntaxDocument1.Lines = new string[] {
        ""};
            this.syntaxDocument1.MaxUndoBufferSize = 1000;
            this.syntaxDocument1.Modified = false;
            this.syntaxDocument1.UndoStep = 0;
            // 
            // baseListBoxControl1
            // 
            this.baseListBoxControl1.BorderStyle = Alsing.Windows.Forms.BorderStyle.FixedSingle;
            this.baseListBoxControl1.FormattingEnabled = true;
            this.baseListBoxControl1.Location = new System.Drawing.Point(541, 1);
            this.baseListBoxControl1.Name = "baseListBoxControl1";
            this.baseListBoxControl1.Size = new System.Drawing.Size(59, 299);
            this.baseListBoxControl1.TabIndex = 1;
            this.baseListBoxControl1.SelectedIndexChanged += new System.EventHandler(this.baseListBoxControl1_SelectedIndexChanged);
            // 
            // syntaxBoxControl1
            // 
            this.syntaxBoxControl1.ActiveView = Alsing.Windows.Forms.ActiveView.BottomRight;
            this.syntaxBoxControl1.AutoListPosition = null;
            this.syntaxBoxControl1.AutoListSelectedText = "a123";
            this.syntaxBoxControl1.AutoListVisible = false;
            this.syntaxBoxControl1.BackColor = System.Drawing.Color.White;
            this.syntaxBoxControl1.BorderStyle = Alsing.Windows.Forms.BorderStyle.None;
            this.syntaxBoxControl1.CopyAsRTF = false;
            this.syntaxBoxControl1.FontName = "Courier new";
            this.syntaxBoxControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.syntaxBoxControl1.InfoTipCount = 1;
            this.syntaxBoxControl1.InfoTipPosition = null;
            this.syntaxBoxControl1.InfoTipSelectedIndex = 1;
            this.syntaxBoxControl1.InfoTipVisible = false;
            this.syntaxBoxControl1.Location = new System.Drawing.Point(14, 184);
            this.syntaxBoxControl1.LockCursorUpdate = false;
            this.syntaxBoxControl1.Name = "syntaxBoxControl1";
            this.syntaxBoxControl1.ShowScopeIndicator = false;
            this.syntaxBoxControl1.Size = new System.Drawing.Size(527, 105);
            this.syntaxBoxControl1.SmoothScroll = false;
            this.syntaxBoxControl1.SplitviewH = -4;
            this.syntaxBoxControl1.SplitviewV = -4;
            this.syntaxBoxControl1.TabGuideColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(235)))));
            this.syntaxBoxControl1.TabIndex = 2;
            this.syntaxBoxControl1.Text = "syntaxBoxControl1";
            this.syntaxBoxControl1.WhitespaceColor = System.Drawing.SystemColors.ControlDark;
            this.syntaxBoxControl1.Click += new System.EventHandler(this.syntaxBoxControl1_Click_1);
            // 
            // syntaxDocument2
            // 
            this.syntaxDocument2.Lines = new string[] {
        ""};
            this.syntaxDocument2.MaxUndoBufferSize = 1000;
            this.syntaxDocument2.Modified = false;
            this.syntaxDocument2.UndoStep = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(14, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Open File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ReviewWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 300);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.syntaxBoxControl1);
            this.Controls.Add(this.baseListBoxControl1);
            this.Name = "ReviewWindow";
            this.Text = "ReviewWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private Alsing.SourceCode.SyntaxDocument syntaxDocument1;
        private Alsing.Windows.Forms.BaseListBoxControl baseListBoxControl1;
        private Alsing.Windows.Forms.SyntaxBoxControl syntaxBoxControl1;
        private Alsing.SourceCode.SyntaxDocument syntaxDocument2;
        private System.Windows.Forms.Button button1;

    }
}