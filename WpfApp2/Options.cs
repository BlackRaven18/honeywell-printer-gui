using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIVEVMSLabels
{
    public class Options
    {
        public Options() { }

        public Options(string printMethod, EthernetSettings ethernetSettings,
            string defaultPrinterScript, string conditionColumn, Condition[] conditions)
        {
            this.printMethod = printMethod;
            this.ethernetSettings = ethernetSettings;
            this.defaultPrinterScript = defaultPrinterScript;
            this.conditionColumn = conditionColumn;
            this.conditions = conditions;
        }

        public string printMethod { get; set; }
        public EthernetSettings ethernetSettings { get; set; }
        public int printingDelayTime { get; set; }
        public string defaultPrinterScript { get; set; }
        public string conditionColumn { get; set; }
        public Condition[] conditions { get; set; }
    }


   
}
