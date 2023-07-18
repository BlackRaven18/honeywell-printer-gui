using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace VIVEVMSLabels
{
    public class OptionsManager
    {
        private readonly string APP_SETTINGS_PATH ="appsettings.json";

        private static OptionsManager instance;
        public Options appSettings { get; set; }
        
        

        private OptionsManager() {
            loadAppSettings();
        }

        public static OptionsManager getInstance()
        {
            if(instance == null)
            {
                instance = new OptionsManager();
            }

            return instance;
        }

        private void loadAppSettings()
        {
            string appSettingsFile = File.ReadAllText(APP_SETTINGS_PATH);
            Debug.WriteLine(appSettingsFile);
            appSettings = JsonSerializer.Deserialize<Options>(appSettingsFile);
        }
    }
}
