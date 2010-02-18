namespace CAE.src.gui
{
    partial class ProjectWindow
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
            this.fsTree1 = new CAE.src.gui.component.FSTree();
            this.SuspendLayout();
            // 
            // fsTree1
            // 
            this.fsTree1.Location = new System.Drawing.Point(12, 12);
            this.fsTree1.Name = "fsTree1";
            this.fsTree1.Size = new System.Drawing.Size(191, 423);
            this.fsTree1.TabIndex = 0;
            // 
            // ProjectWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 447);
            this.Controls.Add(this.fsTree1);
            this.Name = "ProjectWindow";
            this.Text = "ProjectWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private CAE.src.gui.component.FSTree fsTree1;
    }
}