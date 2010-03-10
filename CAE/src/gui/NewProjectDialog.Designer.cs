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
            this.repositoryPathLabel = new System.Windows.Forms.Label();
            this.repositoryPathTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.localPathLabel = new System.Windows.Forms.Label();
            this.localPathTextBox = new System.Windows.Forms.TextBox();
            this.browseFoldersButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.projectNameTextBox = new System.Windows.Forms.TextBox();
            this.userNameLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.userNameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
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
            this.repositoryTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.repositoryTypeComboBox.FormattingEnabled = true;
            this.repositoryTypeComboBox.Items.AddRange(new object[] {
            "Local",
            "Subversion"});
            this.repositoryTypeComboBox.Location = new System.Drawing.Point(103, 10);
            this.repositoryTypeComboBox.Name = "repositoryTypeComboBox";
            this.repositoryTypeComboBox.Size = new System.Drawing.Size(300, 21);
            this.repositoryTypeComboBox.TabIndex = 1;
            this.repositoryTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.repositoryTypeComboBox_SelectedIndexChanged);
            // 
            // repositoryPathLabel
            // 
            this.repositoryPathLabel.AutoSize = true;
            this.repositoryPathLabel.Location = new System.Drawing.Point(13, 110);
            this.repositoryPathLabel.Name = "repositoryPathLabel";
            this.repositoryPathLabel.Size = new System.Drawing.Size(82, 13);
            this.repositoryPathLabel.TabIndex = 2;
            this.repositoryPathLabel.Text = "Repository Path";
            this.repositoryPathLabel.Visible = false;
            // 
            // repositoryPathTextBox
            // 
            this.repositoryPathTextBox.Location = new System.Drawing.Point(103, 107);
            this.repositoryPathTextBox.Name = "repositoryPathTextBox";
            this.repositoryPathTextBox.Size = new System.Drawing.Size(300, 20);
            this.repositoryPathTextBox.TabIndex = 5;
            this.repositoryPathTextBox.Visible = false;
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(116, 199);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(214, 199);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // localPathLabel
            // 
            this.localPathLabel.AutoSize = true;
            this.localPathLabel.Location = new System.Drawing.Point(12, 78);
            this.localPathLabel.Name = "localPathLabel";
            this.localPathLabel.Size = new System.Drawing.Size(58, 13);
            this.localPathLabel.TabIndex = 6;
            this.localPathLabel.Text = "Local Path";
            // 
            // localPathTextBox
            // 
            this.localPathTextBox.Location = new System.Drawing.Point(102, 75);
            this.localPathTextBox.Name = "localPathTextBox";
            this.localPathTextBox.Size = new System.Drawing.Size(267, 20);
            this.localPathTextBox.TabIndex = 3;
            this.localPathTextBox.TextChanged += new System.EventHandler(this.validateFields_TextChanged);
            // 
            // browseFoldersButton
            // 
            this.browseFoldersButton.Image = global::CAE.Properties.Resources.search;
            this.browseFoldersButton.Location = new System.Drawing.Point(381, 73);
            this.browseFoldersButton.Name = "browseFoldersButton";
            this.browseFoldersButton.Size = new System.Drawing.Size(22, 22);
            this.browseFoldersButton.TabIndex = 4;
            this.browseFoldersButton.UseVisualStyleBackColor = true;
            this.browseFoldersButton.Click += new System.EventHandler(this.browseFoldersButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Project Name";
            // 
            // projectNameTextBox
            // 
            this.projectNameTextBox.Location = new System.Drawing.Point(102, 44);
            this.projectNameTextBox.Name = "projectNameTextBox";
            this.projectNameTextBox.Size = new System.Drawing.Size(301, 20);
            this.projectNameTextBox.TabIndex = 2;
            this.projectNameTextBox.TextChanged += new System.EventHandler(this.validateFields_TextChanged);
            // 
            // userNameLabel
            // 
            this.userNameLabel.AutoSize = true;
            this.userNameLabel.Location = new System.Drawing.Point(12, 136);
            this.userNameLabel.Name = "userNameLabel";
            this.userNameLabel.Size = new System.Drawing.Size(55, 13);
            this.userNameLabel.TabIndex = 10;
            this.userNameLabel.Text = "Username";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Location = new System.Drawing.Point(12, 162);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(53, 13);
            this.passwordLabel.TabIndex = 11;
            this.passwordLabel.Text = "Password";
            // 
            // userNameTextBox
            // 
            this.userNameTextBox.Location = new System.Drawing.Point(102, 136);
            this.userNameTextBox.Name = "userNameTextBox";
            this.userNameTextBox.Size = new System.Drawing.Size(301, 20);
            this.userNameTextBox.TabIndex = 12;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(102, 162);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(301, 20);
            this.passwordTextBox.TabIndex = 13;
            // 
            // NewProjectDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(421, 236);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.userNameTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.userNameLabel);
            this.Controls.Add(this.projectNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.browseFoldersButton);
            this.Controls.Add(this.localPathTextBox);
            this.Controls.Add(this.localPathLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.repositoryPathTextBox);
            this.Controls.Add(this.repositoryPathLabel);
            this.Controls.Add(this.repositoryTypeComboBox);
            this.Controls.Add(this.repositoryTypeLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewProjectDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create New Project";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label repositoryTypeLabel;
        private System.Windows.Forms.ComboBox repositoryTypeComboBox;
        private System.Windows.Forms.Label repositoryPathLabel;
        private System.Windows.Forms.TextBox repositoryPathTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label localPathLabel;
        private System.Windows.Forms.TextBox localPathTextBox;
        private System.Windows.Forms.Button browseFoldersButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox projectNameTextBox;
        private System.Windows.Forms.Label userNameLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.TextBox userNameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
    }
}