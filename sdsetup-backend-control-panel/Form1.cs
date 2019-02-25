using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using WinSCP;

using sdsetup_backend_control_panel.Common;
using sdsetup_backend_control_panel.Types;


namespace sdsetup_backend_control_panel {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            ConfigureBindings();
            RefreshUi();
        }

        private void ConfigureBindings() {
            Binding bindModifyButtons = new Binding("Enabled", listboxServers, "SelectedIndex");
            bindModifyButtons.Parse += Common.Events.ListboxIndexExists;
            bindModifyButtons.Format += Common.Events.ListboxIndexExists;
            btnServerEdit.DataBindings.Add(bindModifyButtons);

            bindModifyButtons = new Binding("Enabled", listboxServers, "SelectedIndex");
            bindModifyButtons.Parse += Common.Events.ListboxIndexExists;
            bindModifyButtons.Format += Common.Events.ListboxIndexExists;
            btnServerDelete.DataBindings.Add(bindModifyButtons);
        }

        private void btnServerAdd_Click(object sender, EventArgs e) {
            ServerEditor editor = new ServerEditor();
            editor.ShowDialog();
            if (editor.DialogResult == DialogResult.OK) {
                RefreshUi();
            }
        }

        private void btnServerEdit_Click(object sender, EventArgs e) {
            ServerConfig selectedConfig = (ServerConfig) listboxServers.SelectedItem;
            ServerEditor editor = new ServerEditor(selectedConfig);
            editor.ShowDialog();
            if (editor.DialogResult == DialogResult.OK) {
                RefreshUi();
            }
        }

        private void btnServerDelete_Click(object sender, EventArgs e) {
            ServerConfig selectedConfig = (ServerConfig)listboxServers.SelectedItem;
            Program.config.Servers.Remove(selectedConfig.UUID);
            Program.SaveConfig();
            listboxServers.SelectedIndex = -1;
            RefreshUi();
        }

        private void btnConfigureMasterPassword_Click(object sender, EventArgs e) {
            SetMasterPassword setpass = new SetMasterPassword();
            setpass.ShowDialog();
        }

        private void RefreshUi() {
            //add servers to config
            listboxServers.Items.Clear();
            foreach(ServerConfig k in Program.config.Servers.Values) {
                listboxServers.Items.Add(k);
            }

            txtGuideDir.Text = Program.config.GuideSourceDirectory;
        }

        private void btnBrowsePrivateKey_Click(object sender, EventArgs e) {
            FolderBrowserDialog d = new FolderBrowserDialog();
            string path;

            if (d.ShowDialog() == DialogResult.OK) {
                path = d.SelectedPath;
            } else {
                return;
            }

            txtGuideDir.Text = path;
        }

        private void txtGuideDir_TextChanged(object sender, EventArgs e) {
            Program.config.GuideSourceDirectory = txtGuideDir.Text;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            Program.SaveConfig();
        }

        private void btnBuild_Click(object sender, EventArgs e) {
            Process process = new Process();
            ProcessStartInfo psi = new ProcessStartInfo {
                FileName = "cmd.exe",
                Arguments = "/C make clean && make html",
                WorkingDirectory = Program.config.GuideSourceDirectory,
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                UseShellExecute = false,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
            };

            process.StartInfo = psi;
            process.EnableRaisingEvents = true;

            process.Exited += delegate {
                CleanWriteToLog("\n============================================================\n");
            };

            CleanWriteToLog("\n============================================================\r\nStarting Guide Build\r\n============================================================\n");

            process.Start();

            AsyncStreamReader standardOutput = new AsyncStreamReader(process.StandardOutput);
            AsyncStreamReader standardError = new AsyncStreamReader(process.StandardError);

            standardOutput.DataReceived += (send, data) => {
                if (data != null)
                    CleanWriteToLog(data);
            };

            standardError.DataReceived += (send, data) => {
                if (data != null)
                    CleanWriteToLog(data);
            };


            standardOutput.Start();
            standardError.Start();


        }

        

        private void FileTransferred(object sender, TransferEventArgs e) {
            if (e.Error == null) {
                Log(String.Format("Upload of {0} succeeded", e.FileName));
            } else {
                Log(String.Format("Upload of {0} failed: {1}", e.FileName, e.Error));
            }

            if (e.Chmod != null) {
                if (e.Chmod.Error == null) {
                    //Log(String.Format("Permissions of {0} set to {1}", e.Chmod.FileName, e.Chmod.FilePermissions));
                } else {
                    Log(String.Format("Setting permissions of {0} failed: {1}", e.Chmod.FileName, e.Chmod.Error));
                }
            } else {
                //Log(String.Format("Permissions of {0} kept with their defaults", e.Destination));
            }

            if (e.Touch != null) {
                if (e.Touch.Error == null) {
                    //Log(String.Format("Timestamp of {0} set to {1}", e.Touch.FileName, e.Touch.LastWriteTime));
                } else {
                    Log(String.Format("Setting timestamp of {0} failed: {1}", e.Touch.FileName, e.Touch.Error));
                }
            } else {
                // This should never happen during "local to remote" synchronization
                //Log(String.Format("Timestamp of {0} kept with its default (current time)", e.Destination));
            }
        }

        private void Log(string message) {
            Action action = new Action(() => txtDebug.AppendText("[LOG] " + message + "\n"));
            if (txtDebug.InvokeRequired) {
                txtDebug.Invoke(action);
            } else {
                action();
            }
        }

        private void CleanWriteToLog(string message) {
            Action action = new Action(() => txtDebug.AppendText((message + "\n").Replace("\n\n", "\n")));
            if (txtDebug.InvokeRequired) {
                txtDebug.Invoke(action);
            } else {
                action();
            }
        }

        private void btnPushPublic_Click(object sender, EventArgs e) {
            Task.Factory.StartNew(new Action(() => {
                foreach (ServerConfig k in Program.config.Servers.Values) {
                    Log("Syncronizing local guide build to public on " + k.Hostname + "\n");

                    Session session = ConnectionUtils.GetSession(ConnectionUtils.GetSessionOptions(k));

                    session.FileTransferred += FileTransferred;

                    session.SynchronizeDirectories(SynchronizationMode.Remote, Program.config.GuideSourceDirectory + "\\_build\\html\\", k.GuideDirectory, true, false, SynchronizationCriteria.Either);

                    session.Close();

                    Log("Finished syncronizing local guide build to public on " + k.Hostname + "\n");
                }
            }));
        }

        private void btnPushPrivateTesting_Click(object sender, EventArgs e) {
            Task.Factory.StartNew(new Action(() => {
                foreach (ServerConfig k in Program.config.Servers.Values) {
                    Log("Syncronizing local guide build to private test on " + k.Hostname + "\n");

                    Session session = ConnectionUtils.GetSession(ConnectionUtils.GetSessionOptions(k));

                    session.FileTransferred += FileTransferred;

                    session.SynchronizeDirectories(SynchronizationMode.Remote, Program.config.GuideSourceDirectory + "\\_build\\html\\", k.PrivateTestingGuideDirectory, true, false, SynchronizationCriteria.Either);

                    session.Close();

                    Log("Finished syncronizing local guide build to private test on " + k.Hostname + "\n");
                }
            }));
        }

        private void btnPushPublicTest_Click(object sender, EventArgs e) {
            Task.Factory.StartNew(new Action(() => {
                foreach (ServerConfig k in Program.config.Servers.Values) {
                    Log("Syncronizing local guide build to public on " + k.Hostname + "\n");

                    Session session = ConnectionUtils.GetSession(ConnectionUtils.GetSessionOptions(k));

                    session.FileTransferred += FileTransferred;

                    session.SynchronizeDirectories(SynchronizationMode.Remote, Program.config.GuideSourceDirectory + "\\_build\\html\\", k.PublicTestingGuideDirectory, true, false, SynchronizationCriteria.Either);

                    session.Close();

                    Log("Finished syncronizing local guide build to public on " + k.Hostname + "\n");
                }
            }));
        }
    }
}
