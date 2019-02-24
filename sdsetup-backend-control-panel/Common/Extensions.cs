﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdsetup_backend_control_panel.Common {
    static class Extensions {
        public static string ToCleanUuidString(this Guid g) {
            return g.ToString().ToLower().Replace("-", "");
        }
    }
}
