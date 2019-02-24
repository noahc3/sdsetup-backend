using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
        }

        
    }
}
