using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VIVEVMSLabels
{
    public class LablelStringToPrinter
    {

        public static string ShelfNo4(string rack, string xcoor, string ycoor, string cheksum)
        {
            string FirstTree = "";
            string SecondTree = "";


            FirstTree = String.Join(Environment.NewLine,
                                                            "ALIGN 1",

                                                            "CTRLSUM$ = \"" + cheksum + "\"",

                                                            "SHELF$= \"" + ycoor.Substring(1, 1) + "\"",

                                                            "CORENUM1$ = \"" + rack + "\"",
                                                            "CORENUM2$ = \"" + xcoor + "\"",
                                                            "CORENUM3$ = \"" + ycoor + "\"",

                                                            "PRPOS60, 160",
                                                            "BARFONT OFF",
                                                            "BARSET \"CODE128C\", 3, 1, 10, 140, 0, 0",
                                                            "PRBAR CTRLSUM$",

                                                            "FONT \"Univers Bold\", 48",
                                                            "PRPOS30, 01",
                                                            "PRTXT CTRLSUM$",

                                                            "DIR 1",
                                                            "FONT \"Univers Bold\", 36",
                                                            "PRPOS55, 325",
                                                            "PRTXT SHELF$",

                                                            "NORIMAGE",
                                                            "PRPOS25, 325",
                                                            "PRBOX125, 125, 15",

                                                            "PRPOS 180, 425 - 10",
                                                            "PRIMAGE \"TRIANGLE.1\"",
                                                            "PRPOS 180, 390 - 10",
                                                            "PRIMAGE \"TRIANGLE.1\"",
                                                            "PRPOS 180, 355 - 10",
                                                            "PRIMAGE \"TRIANGLE.1\"",
                                                            "PRPOS 180, 320 - 10",
                                                            "PRIMAGE \"TRIANGLE.1\""
                                                );


            if(int.Parse(ycoor) >= 5)
            {
                SecondTree = String.Join(Environment.NewLine,
                                                            "PRPOS 300, 320 - 10",
                                                            "PRIMAGE \"TRIANGLE.1\""
                                        );
            }
            if (int.Parse(ycoor) >= 6)
            {
                SecondTree = String.Join(Environment.NewLine,
                                                            SecondTree,
                                                            "PRPOS 300, 355 - 10",
                                                            "PRIMAGE \"TRIANGLE.1\""
                                        );
            }
            if (int.Parse(ycoor) >= 7)
            {
                SecondTree = String.Join(Environment.NewLine,
                                                            SecondTree,
                                                            "PRPOS 300, 390 - 10",
                                                            "PRIMAGE \"TRIANGLE.1\""
                                        );
            }
            if (int.Parse(ycoor) >= 8)
            {
                SecondTree = String.Join(Environment.NewLine,
                                                            SecondTree,
                                                            "PRPOS 300, 425 - 10",
                                                            "PRIMAGE \"TRIANGLE.1\""
                                        );
            }



            return (String.Join(Environment.NewLine,
                                                            FirstTree,
                                                            SecondTree,
                                                            "PRINTFEED",
                                                            "NEXT",
                                                            ""

                                        ));
        }


        public static string ShelfNo3(string rack, string xcoor, string cheksum)
        {
            return (String.Join(Environment.NewLine,
                                                            "ALIGN 1",

                                                            "CTRLSUM$ = \"" + cheksum + "\"",

                                                            "SHELF$= \"3\"",

                                                            "CORENUM1$ = \"" + rack + "\"",
                                                            "CORENUM2$ = \"" + xcoor + "\"",
                                                            "CORENUM3$ = \"0\" + SHELF$",

                                                            "PRPOS60, 160",
                                                            "BARFONT OFF",
                                                            "BARSET \"CODE128C\", 3, 1, 10, 140, 0, 0",
                                                            "PRBAR CTRLSUM$",

                                                            "FONT \"Univers Bold\", 48",
                                                            "PRPOS30, 01",
                                                            "PRTXT CTRLSUM$",

                                                            "DIR 1",
                                                            "FONT \"Univers Bold\", 36",
                                                            "PRPOS55, 325",
                                                            "PRTXT SHELF$",

                                                            "NORIMAGE",
                                                            "PRPOS25, 325",
                                                            "PRBOX125, 125, 15",

                                                            "PRPOS 180, 420 - 10",
                                                            "PRIMAGE \"TRIANGLE.1\"",
                                                            "PRPOS 180, 375 - 10",
                                                            "PRIMAGE \"TRIANGLE.1\"",
                                                            "PRPOS 180, 330 - 10",
                                                            "PRIMAGE \"TRIANGLE.1\"",

                                                            "PRINTFEED",
                                                            "NEXT",
                                                            ""

                                        ));
        }

        public static string ShelfNo2(string rack, string xcoor, string cheksum)
        {
            return (String.Join(Environment.NewLine,
                                                            "ALIGN 1",

                                                            "CTRLSUM$ = \"" + cheksum + "\"",

                                                            "SHELF$= \"2\"",

                                                            "CORENUM1$ = \"" + rack + "\"",
                                                            "CORENUM2$ = \"" + xcoor + "\"",
                                                            "CORENUM3$ = \"0\" + SHELF$",

                                                            "PRPOS60, 160",
                                                            "BARFONT OFF",
                                                            "BARSET \"CODE128C\", 3, 1, 10, 140, 0, 0",
                                                            "PRBAR CTRLSUM$",

                                                            "FONT \"Univers Bold\", 48",
                                                            "PRPOS30, 01",
                                                            "PRTXT CTRLSUM$",

                                                            "DIR 1",
                                                            "FONT \"Univers Bold\", 36",
                                                            "PRPOS55, 325",
                                                            "PRTXT SHELF$",

                                                            "NORIMAGE",
                                                            "PRPOS25, 325",
                                                            "PRBOX125, 125, 15",

                                                            "PRPOS 180, 375 - 10",
                                                            "PRIMAGE \"TRIANGLE.1\"",
                                                            "PRPOS 180, 330 - 10",
                                                            "PRIMAGE \"TRIANGLE.1\"",

                                                            "PRINTFEED",
                                                            "NEXT"

                                        ));
        }


        public static string ShelfNo1(string rack, string xcoor, string cheksum)
        {
            return (String.Join(Environment.NewLine,
                                                            "ALIGN 1",

                                                            "CTRLSUM$ = \"" + cheksum + "\"",

                                                            "SHELF$= \"1\"",

                                                            "CORENUM1$ = \"" + rack + "\"",
                                                            "CORENUM2$ = \"" + xcoor + "\"",
                                                            "CORENUM3$ = \"0\" + SHELF$",

                                                            "PRPOS60, 160",
                                                            "BARFONT OFF",
                                                            "BARSET \"CODE128C\", 3, 1, 10, 140, 0, 0",
                                                            "PRBAR CTRLSUM$",

                                                            "FONT \"Univers Bold\", 48",
                                                            "PRPOS30, 01",
                                                            "PRTXT CTRLSUM$",

                                                            "DIR 1",
                                                            "FONT \"Univers Bold\", 36",
                                                            "PRPOS55, 325",
                                                            "PRTXT SHELF$",

                                                            "NORIMAGE",
                                                            "PRPOS25, 325",
                                                            "PRBOX125, 125, 15",

                                                            "PRPOS 180, 330-10",
                                                            "PRIMAGE \"TRIANGLE.1\"",

                                                            "PRINTFEED",
                                                            "NEXT"

                                        ));
        }


        public static string ShelfNo0(string rack, string xcoor, string cheksum)
        {
            return (String.Join(Environment.NewLine,
                                                            "ALIGN 1",

                                                            "CTRLSUM$ = \"" + cheksum + "\"",

                                                            "SHELF$= \"" + rack + "\"",

                                                            //"CORENUM1$ = \"" + rack + "\"",
                                                            //"CORENUM2$ = \"" + xcoor + "\"",
                                                            //"CORENUM3$ = \"0\" + SHELF$",

                                                            "PRPOS60, 160",
                                                            "BARFONT OFF",
                                                            "BARSET \"CODE128\", 3, 1, 4, 120, 0, 0",
                                                            "PRBAR CTRLSUM$",

                                                            "FONT \"Univers Bold\", 40",
                                                            "PRPOS30, 01",
                                                            "PRTXT CTRLSUM$",

                                                            //"DIR 3",
                                                            //"PRPOS265, 380",
                                                            //"PRIMAGE \"TRIANGLE.1\"",

                                                            "DIR 1",
                                                            //"INVIMAGE",
                                                            "FONT \"Univers Bold\", 40",
                                                            "PRPOS50, 325",
                                                            "PRTXT SHELF$",

                                                            //"NORIMAGE",
                                                            //"PRPOS30, 325",
                                                            //"PRBOX125, 99, 20",

                                                            "PRINTFEED",
                                                            "NEXT"

                                        ));
        }



        public static string StringToPrinter(DataRow OneRow, string printedScript, StringCollection columnNames)
        {
            string thisstring;
            string rack, xcoor, ycoor, cheksum;
            int i = 0;

            rack = "01";
            xcoor = "01";
            ycoor = "01";
            //rack = OneRow[1].ToString();
            //xcoor = OneRow[2].ToString();
            //ycoor = OneRow[3].ToString();
            //cheksum = OneRow[3].ToString();

            //thisstring = ShelfNo0(cheksum.Substring(7, 1), xcoor, cheksum);
            thisstring = printedScript;

            foreach(String columnVar in columnNames)
            {
                Debug.WriteLine(columnVar);
                thisstring = thisstring.Replace(columnVar, OneRow[i++].ToString());

            }

            using (StreamWriter writer = new StreamWriter(@"D:\\profil_arkadiuszw\\Desktop\\dssmith 2021-01-22\\Wpf_Sek20210121\\WpfApp2\\printedlog.txt"))
            {
                writer.WriteLine(thisstring);
            }

            /**
            switch (ycoor)
            {
                case "00":
                    thisstring = ShelfNo0(rack, xcoor, cheksum);
                    break;
                case "01":
                    thisstring = ShelfNo1(rack, xcoor, cheksum);
                    break;
                case "02":
                    thisstring = ShelfNo2(rack, xcoor, cheksum);
                    break;
                case "03":
                    thisstring = ShelfNo3(rack, xcoor, cheksum);
                    break;
                default:
                    thisstring = ShelfNo4(rack, xcoor, ycoor, cheksum);
                    break;
            }
            **/

            //Debug.WriteLine(thisstring);
            return thisstring;
        }
    }

}
