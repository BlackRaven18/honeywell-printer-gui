
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.IO;


namespace VIVEVMSLabels
{
    public class LablelStringToPrinter
    {

        public static string StringToPrinter(DataRow OneRow, StringCollection columnNames)
        {
            string thisstring = "";

            OptionsManager optionsManager = OptionsManager.getInstance();
            Debug.WriteLine($"default = {optionsManager.appSettings.defaultPrinterScript}");

            for (int i = 0; i < columnNames.Count; i++)
            {
                //Debug.WriteLine(columnNames[i]);
                thisstring = thisstring.Replace("@@" + columnNames[i] + "@@", OneRow[i].ToString());
            }

            using (StreamWriter writer = new StreamWriter(@"D:\\profil_arkadiuszw\\Desktop\\dssmith 2021-01-22\\Wpf_Sek20210121\\WpfApp2\\printedlog.txt"))
            {
                writer.WriteLine(thisstring);
            }

            return thisstring;
        }



    }

}
