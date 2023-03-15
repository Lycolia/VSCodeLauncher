using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VSCodeLauncher {
    internal class Util {
        public static void loadConfig(string configPath) {
            if (File.Exists(configPath)) {
                var sr = new StreamReader(configPath);
                var configString = sr.ReadToEnd();
            }

        }
    }
}
