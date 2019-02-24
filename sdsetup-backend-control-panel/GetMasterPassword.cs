﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sdsetup_backend_control_panel.Common;

namespace sdsetup_backend_control_panel {
    public partial class GetMasterPassword : Form {
        private string MasterPasswordHash;
        public string MasterPassword;
        public GetMasterPassword(string MasterPasswordHash) {
            InitializeComponent();

            this.MasterPasswordHash = MasterPasswordHash;
        }

        private void btnSetPassword_Click(object sender, EventArgs e) {
            if (Security.SHA256Sum(txtPassword.Text) == MasterPasswordHash) {
                MasterPassword = txtPassword.Text;
                DialogResult = DialogResult.OK;
                Close();
            } else {
                txtPassword.Text = "";
                lblPasswordValid.Visible = true;
            }
        }
    }
}
