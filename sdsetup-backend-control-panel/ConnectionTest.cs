﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using sdsetup_backend_control_panel.Types;
using sdsetup_backend_control_panel.Common;
using WinSCP;

namespace sdsetup_backend_control_panel {
    public partial class ConnectionTest : Form {
        public string LastMessage = "";

        public ConnectionTest(ServerConfig conf) {
            InitializeComponent();

            Task.Factory.StartNew(new Action(() => Test(conf)));
        }

        private void UpdateMessage(string message) {
            Action upd = new Action(() => {
                lblMessage.Text = message;
                LastMessage = message;
            });

            if (this.InvokeRequired) this.Invoke(upd);
            else upd();
        }

        private void CloseForm() {
            Action close = new Action(() => {
                Close();
            });

            if (this.InvokeRequired) this.Invoke(close);
            else close();
        }

        private void Test(ServerConfig conf) {
            Session session;
            SessionOptions opts;

            UpdateMessage("Configuring WinSCP Information...");

            try {
                opts = ConnectionUtils.GetSessionOptions(conf);
            } catch {
                UpdateMessage("Configuring WinSCP Information Failed!");
                DialogResult = DialogResult.Abort;
                //CloseForm();
                return;
            }

            UpdateMessage($"Connecting to {conf.Hostname} with username {conf.Username}");

            try {
                session = ConnectionUtils.GetSession(opts);
            } catch {
                UpdateMessage($"Connection to {conf.Hostname} failed!");
                DialogResult = DialogResult.Abort;
                //CloseForm();
                return;
            }

            try {
                RemoteDirectoryInfo directory = session.ListDirectory("/");
                if (directory.Files.Count > 0) {
                    UpdateMessage($"Connection to {conf.Hostname} succeeded!");
                    DialogResult = DialogResult.OK;
                    //CloseForm();
                    return;
                } else {
                    UpdateMessage($"Connection to {conf.Hostname} failed!");
                    DialogResult = DialogResult.Abort;
                    //CloseForm();
                    return;
                }
            } catch {
                UpdateMessage($"Failed to verify successful connection to {conf.Hostname} (check '/' read permissions)");
                DialogResult = DialogResult.Abort;
                //CloseForm();
                return;
            } finally {
                session.Close();
            }
        }
    }
}
