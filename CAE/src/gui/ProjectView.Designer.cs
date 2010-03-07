namespace CAE.src.gui
{
    partial class ProjectView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.browser1 = new FileBrowser.Browser();
            this.scintilla1 = new ScintillaNet.Scintilla();
            ((System.ComponentModel.ISupportInitialize)(this.scintilla1)).BeginInit();
            this.SuspendLayout();
            // 
            // browser1
            // 
            this.browser1.Dock = System.Windows.Forms.DockStyle.Left;
            this.browser1.ListViewMode = System.Windows.Forms.View.List;
            this.browser1.Location = new System.Drawing.Point(0, 0);
            this.browser1.Name = "browser1";
            this.browser1.SelectedNode = null;
            this.browser1.ShowFolders = false;
            this.browser1.ShowFoldersButton = false;
            this.browser1.Size = new System.Drawing.Size(255, 374);
            this.browser1.SplitterDistance = 160;
            this.browser1.StartUpDirectory = FileBrowser.SpecialFolders.Other;
            this.browser1.TabIndex = 0;
            this.browser1.TabStop = false;
            // 
            // scintilla1
            // 
            this.scintilla1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scintilla1.Location = new System.Drawing.Point(255, 0);
            this.scintilla1.Name = "scintilla1";
            this.scintilla1.Size = new System.Drawing.Size(574, 374);
            this.scintilla1.Styles.BraceBad.FontName = "Verdana";
            this.scintilla1.Styles.BraceLight.FontName = "Verdana";
            this.scintilla1.Styles.ControlChar.FontName = "Verdana";
            this.scintilla1.Styles.Default.FontName = "Verdana";
            this.scintilla1.Styles.IndentGuide.FontName = "Verdana";
            this.scintilla1.Styles.LastPredefined.FontName = "Verdana";
            this.scintilla1.Styles.LineNumber.FontName = "Verdana";
            this.scintilla1.Styles.Max.FontName = "Verdana";
            this.scintilla1.TabIndex = 1;
            // 
            // ProjectView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.scintilla1);
            this.Controls.Add(this.browser1);
            this.Name = "ProjectView";
            this.Size = new System.Drawing.Size(829, 374);
            ((System.ComponentModel.ISupportInitialize)(this.scintilla1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FileBrowser.Browser browser1;
        private ScintillaNet.Scintilla scintilla1;
    }
}
