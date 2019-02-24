namespace sdsetup_backend_control_panel {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnServerEdit = new System.Windows.Forms.Button();
            this.btnServerDelete = new System.Windows.Forms.Button();
            this.btnServerAdd = new System.Windows.Forms.Button();
            this.listboxServers = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnConfigureMasterPassword = new System.Windows.Forms.Button();
            this.lblMasterPassword = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(804, 352);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(796, 326);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Backend";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(796, 326);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Guide";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.lblMasterPassword);
            this.tabPage3.Controls.Add(this.btnConfigureMasterPassword);
            this.tabPage3.Controls.Add(this.btnServerEdit);
            this.tabPage3.Controls.Add(this.btnServerDelete);
            this.tabPage3.Controls.Add(this.btnServerAdd);
            this.tabPage3.Controls.Add(this.listboxServers);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(796, 326);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Config";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnServerEdit
            // 
            this.btnServerEdit.Location = new System.Drawing.Point(77, 126);
            this.btnServerEdit.Name = "btnServerEdit";
            this.btnServerEdit.Size = new System.Drawing.Size(60, 23);
            this.btnServerEdit.TabIndex = 4;
            this.btnServerEdit.Text = "Edit";
            this.btnServerEdit.UseVisualStyleBackColor = true;
            this.btnServerEdit.Click += new System.EventHandler(this.btnServerEdit_Click);
            // 
            // btnServerDelete
            // 
            this.btnServerDelete.Location = new System.Drawing.Point(143, 126);
            this.btnServerDelete.Name = "btnServerDelete";
            this.btnServerDelete.Size = new System.Drawing.Size(60, 23);
            this.btnServerDelete.TabIndex = 3;
            this.btnServerDelete.Text = "Delete";
            this.btnServerDelete.UseVisualStyleBackColor = true;
            this.btnServerDelete.Click += new System.EventHandler(this.btnServerDelete_Click);
            // 
            // btnServerAdd
            // 
            this.btnServerAdd.Location = new System.Drawing.Point(11, 126);
            this.btnServerAdd.Name = "btnServerAdd";
            this.btnServerAdd.Size = new System.Drawing.Size(60, 23);
            this.btnServerAdd.TabIndex = 2;
            this.btnServerAdd.Text = "Add";
            this.btnServerAdd.UseVisualStyleBackColor = true;
            this.btnServerAdd.Click += new System.EventHandler(this.btnServerAdd_Click);
            // 
            // listboxServers
            // 
            this.listboxServers.FormattingEnabled = true;
            this.listboxServers.Location = new System.Drawing.Point(11, 25);
            this.listboxServers.Name = "listboxServers";
            this.listboxServers.Size = new System.Drawing.Size(192, 95);
            this.listboxServers.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server Config";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(4, 354);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(796, 276);
            this.textBox1.TabIndex = 1;
            // 
            // btnConfigureMasterPassword
            // 
            this.btnConfigureMasterPassword.Location = new System.Drawing.Point(11, 183);
            this.btnConfigureMasterPassword.Name = "btnConfigureMasterPassword";
            this.btnConfigureMasterPassword.Size = new System.Drawing.Size(192, 23);
            this.btnConfigureMasterPassword.TabIndex = 5;
            this.btnConfigureMasterPassword.Text = "Configure Master Password";
            this.btnConfigureMasterPassword.UseVisualStyleBackColor = true;
            this.btnConfigureMasterPassword.Click += new System.EventHandler(this.btnConfigureMasterPassword_Click);
            // 
            // lblMasterPassword
            // 
            this.lblMasterPassword.AutoSize = true;
            this.lblMasterPassword.Location = new System.Drawing.Point(8, 167);
            this.lblMasterPassword.Name = "lblMasterPassword";
            this.lblMasterPassword.Size = new System.Drawing.Size(162, 13);
            this.lblMasterPassword.TabIndex = 6;
            this.lblMasterPassword.Text = "Master Password Not Configured";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 632);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnServerEdit;
        private System.Windows.Forms.Button btnServerDelete;
        private System.Windows.Forms.Button btnServerAdd;
        private System.Windows.Forms.ListBox listboxServers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblMasterPassword;
        private System.Windows.Forms.Button btnConfigureMasterPassword;
    }
}

