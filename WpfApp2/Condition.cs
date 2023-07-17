using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIVEVMSLabels
{
    public class Condition
    {
        public Condition() { }
        public Condition(string value, string script)
        {
            this.value = value;
            this.script = script;
        }

        public string value { get; set; }
        public string script { get; set; }
    }


}
