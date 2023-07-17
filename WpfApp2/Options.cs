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

        public Options(string defaultPrinterScript, string conditionColumn, Condition[] conditions)
        {
            this.defaultPrinterScript = defaultPrinterScript;
            this.conditionColumn = conditionColumn;
            this.conditions = conditions;
        }

        public string defaultPrinterScript { get; set; }
        public string conditionColumn { get; set; }
        public Condition[] conditions { get; set; }
    }


   
}
