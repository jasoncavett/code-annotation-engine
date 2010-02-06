namespace CAE.src.gui
{
    partial class NewProjectDialog
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
            this.repositoryTypeLabel = new System.Windows.Forms.Label();
            this.repositoryTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // repositoryTypeLabel
            // 
            this.repositoryTypeLabel.AutoSize = true;
            this.repositoryTypeLabel.Location = new System.Drawing.Point(13, 13);
            this.repositoryTypeLabel.Name = "repositoryTypeLabel";
            this.repositoryTypeLabel.Size = new System.Drawing.Size(84, 13);
            this.repositoryTypeLabel.TabIndex = 0;
            this.repositoryTypeLabel.Text = "Repository Type";
            // 
            // repositoryTypeComboBox
            // 
            this.repositoryTypeComboBox.FormattingEnabled = true;
            this.repositoryTypeComboBox.Items.AddRange(new object[] {
            "Subversion"});
            this.repositoryTypeComboBox.Location = new System.Drawing.Point(103, 10);
            this.repositoryTypeComboBox.Name = "repositoryTypeComboBox";
            this.repositoryTypeComboBox.Size = new System.Drawing.Size(200, 21);
            this.repositoryTypeComboBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Repository Path";
            // 
            // NewProjectDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 214);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.repositoryTypeComboBox);
            this.Controls.Add(this.repositoryTypeLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewProjectDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create New Project";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label repositoryTypeLabel;
        private System.Windows.Forms.ComboBox repositoryTypeComboBox;
        private System.Windows.Forms.Label label1;
    }
}