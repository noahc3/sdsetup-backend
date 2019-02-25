﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdsetup_backend_control_panel.Types {
    class Config {
        public string MasterPasswordHash;
        public string CryptoSanityCheck = "f1a028bbc85240e0aafab336070861a5";
        public const string _CryptoSanityCheck = "f1a028bbc85240e0aafab336070861a5";
        public Dictionary<string, ServerConfig> Servers;

        public string GuideSourceDirectory = "";

        public Config() {
            MasterPasswordHash = "";
            Servers = new Dictionary<string, ServerConfig>();
            GuideSourceDirectory = "";
        }

        public Config(Config template) {
            MasterPasswordHash = template.MasterPasswordHash;
            CryptoSanityCheck = template.CryptoSanityCheck;
            Servers = new Dictionary<string, ServerConfig>();

            foreach (ServerConfig k in template.Servers.Values) {
                Servers[k.UUID] = new ServerConfig(k);
            }

            GuideSourceDirectory = "";
        }
    }
}
