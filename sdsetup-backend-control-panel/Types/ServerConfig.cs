using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sdsetup_backend_control_panel.Common;

namespace sdsetup_backend_control_panel.Types {
    public class ServerConfig {
        public string Hostname = "";
        public string Username = "";
        public string Password = "";

        public string PrivateKeyPath = "";
        public string PrivateKeyPassphrase = "";

        public string UUID;

        public bool UsesKeyBasedAuthentication = true;
        public bool AskForPasswordEachRun = true;
        public bool AskForPrivateKeyPassphraseEachRun = true;

        public string BackendDirectory = "";
        public string GuideDirectory = "";
        public string PublicTestingGuideDirectory = "";
        public string PrivateTestingGuideDirectory = "";

        public ServerConfig() {
            UUID = Guid.NewGuid().ToCleanUuidString();
        }

        public ServerConfig(ServerConfig template) {
            Hostname = template.Hostname;
            Username = template.Username;
            Password = template.Password;

            PrivateKeyPath = template.PrivateKeyPath;
            PrivateKeyPassphrase = template.PrivateKeyPassphrase;

            UUID = template.UUID;

            UsesKeyBasedAuthentication = template.UsesKeyBasedAuthentication;
            AskForPasswordEachRun = template.AskForPasswordEachRun;
            AskForPrivateKeyPassphraseEachRun = template.AskForPrivateKeyPassphraseEachRun;

            BackendDirectory = template.BackendDirectory;
            GuideDirectory = template.GuideDirectory;
            PublicTestingGuideDirectory = template.PublicTestingGuideDirectory;
            PrivateTestingGuideDirectory = template.PrivateTestingGuideDirectory;
        }

        public ServerConfig(string hostname, string username, string password, string privateKeyPath, string privateKeyPassphrase, string uUID, bool usesKeyBasedAuthentication, bool askForPasswordEachRun, bool askForPrivateKeyPassphraseEachRun, string backendDirectory, string guideDirectory, string publicTestingGuideDirectory, string privateTestingGuideDirectory) {
            Hostname = hostname;
            Username = username;
            Password = password;
            PrivateKeyPath = privateKeyPath;
            PrivateKeyPassphrase = privateKeyPassphrase;
            UUID = uUID;
            UsesKeyBasedAuthentication = usesKeyBasedAuthentication;
            AskForPasswordEachRun = askForPasswordEachRun;
            AskForPrivateKeyPassphraseEachRun = askForPrivateKeyPassphraseEachRun;
            BackendDirectory = backendDirectory;
            GuideDirectory = guideDirectory;
            PublicTestingGuideDirectory = publicTestingGuideDirectory;
            PrivateTestingGuideDirectory = privateTestingGuideDirectory;
        }

        public override string ToString() {
            return Hostname;
        }
    }
}
