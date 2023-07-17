
using System.Collections.Specialized;
using System.Data;
using System.IO;


namespace VIVEVMSLabels
{
    public class LablelStringToPrinter
    {

        public static string StringToPrinter(DataRow OneRow, StringCollection columnNames)
        {
            OptionsManager optionsManager = OptionsManager.getInstance();
            string thisstring = "";
            int conditionColumnNumber = findColumnNumber(columnNames);

            if (conditionColumnNumber == -1) return null;


            foreach(Condition condition in optionsManager.appSettings.conditions)
            {
                if(condition.value == OneRow[conditionColumnNumber].ToString().Trim()) //here value from specified column oneRow. ...
                {
                    thisstring = File.ReadAllText(
                        @"D:\profil_arkadiuszw\Desktop\dssmith 2021-01-22\Wpf_Sek20210121\scripts\" + condition.script);
       
                    break;
                }
                else
                {
                    thisstring = File.ReadAllText(
                       @"D:\profil_arkadiuszw\Desktop\dssmith 2021-01-22\Wpf_Sek20210121\scripts\" + optionsManager.appSettings.defaultPrinterScript);
                }
            }



            for (int i = 0; i < columnNames.Count; i++)
            {
                //Debug.WriteLine(columnNames[i]);
                thisstring = thisstring.Replace("@@" + columnNames[i] + "@@", OneRow[i].ToString());
            }

         

            return thisstring;
        }

        private static int findColumnNumber(StringCollection columnNames)
        {
            OptionsManager optionsManager = OptionsManager.getInstance();
            int i = -1;
            bool found = false;

            foreach(string columnName in columnNames)
            {
                i++;

                if (columnName.Trim() == optionsManager.appSettings.conditionColumn.Trim())
                {
                    found = true;
                    break;
                }
            }

            if(found)
            {
                return i;
            }else
            {
                return -1;
            }
        }



    }

}
