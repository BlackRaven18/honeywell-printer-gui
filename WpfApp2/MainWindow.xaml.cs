using System;
using System.Windows;
using Microsoft.Win32;
using System.Data;
using System.Diagnostics;
using System.IO.Ports;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Threading;
using System.Windows.Media;
using System.Collections.Specialized;
using System.CodeDom;
using System.IO;
using System.Text.Json;

namespace VIVEVMSLabels
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        protected DataTable dt;


        public MainWindow()
        {
            InitializeComponent();
            //OptionsManager optionsManager = OptionsManager.getInstance();
            //Debug.WriteLine($"default = {optionsManager.appSettings.defaultPrinterScript}");
        }


  

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


        private void UpdatetxtInfo1(string newtxt, SolidColorBrush brush)
        {
            txtInfo1.Content = newtxt;
            txtInfo1.Foreground = brush;
        }

        private void UpdatedtGridItemsSource()
        {
            dtGrid.ItemsSource = dt.DefaultView;
        }

        private delegate void Updater(string udnewtxt, SolidColorBrush udbrush);

        private delegate void UpdaterGrid();


        private void ReadLabels(string chosenFile)
        {
            Updater uiUpdater = new Updater(UpdatetxtInfo1);

            Dispatcher.BeginInvoke(DispatcherPriority.Send, uiUpdater, $"Czekaj trwa wczytywanie pozycji.", Brushes.Red);

            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                //Static File From Base Path...........
                //Microsoft.Office.Interop.Excel.Workbook excelBook = excelApp.Workbooks.Open(AppDomain.CurrentDomain.BaseDirectory + "TestExcel.xlsx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                //Dynamic File Using Uploader...........
                Microsoft.Office.Interop.Excel.Workbook excelBook = excelApp.Workbooks.Open(chosenFile, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                Microsoft.Office.Interop.Excel.Worksheet excelSheet = (Microsoft.Office.Interop.Excel.Worksheet)excelBook.Worksheets.get_Item(1); ;
                Microsoft.Office.Interop.Excel.Range excelRange = excelSheet.UsedRange;



                string strCellData = "";
                double douCellData;
                int rowCnt = 0;
                int colCnt = 0;

                dt = new DataTable();
                for (colCnt = 1; colCnt <= excelRange.Columns.Count; colCnt++)
                {
                    string strColumn = "";
                    strColumn = (string)(excelRange.Cells[1, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                    strColumn = strColumn.Trim();
                    dt.Columns.Add(strColumn, typeof(string));
                }


                int rowcount = excelRange.Rows.Count - 1;

                for (rowCnt = 2; rowCnt <= excelRange.Rows.Count; rowCnt++)
                {
                    Dispatcher.BeginInvoke(DispatcherPriority.Send, uiUpdater, $"Czekaj trwa wczytywanie pozycji {rowCnt-1} / {rowcount}.", Brushes.Red);
                    string strData = "";
                    for (colCnt = 1; colCnt <= excelRange.Columns.Count; colCnt++)
                    {
                        try
                        {
                            strCellData = (string)(excelRange.Cells[rowCnt, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                            strCellData = strCellData.Trim();
                            strData += strCellData + "|";
                        }
                        catch (Exception ex)
                        {
                            douCellData = (excelRange.Cells[rowCnt, colCnt] as Microsoft.Office.Interop.Excel.Range).Value2;
                            strData += douCellData.ToString() + "|";
                        }
                    }
                    strData = strData.Remove(strData.Length - 1, 1);
                    dt.Rows.Add(strData.Split('|'));
                }

            UpdaterGrid uiUpdaterGrid = new UpdaterGrid(UpdatedtGridItemsSource);
            Dispatcher.BeginInvoke(DispatcherPriority.Send, uiUpdaterGrid);

            excelBook.Close(true, null, null);
            excelApp.Quit();
            

            Dispatcher.BeginInvoke(DispatcherPriority.Send, uiUpdater, $"Wybierz akcję ({dt.Rows.Count} pozycji.)", Brushes.Black);
        }

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.DefaultExt = ".xlsx";
            openfile.Filter = "(.xlsx)|*.xlsx";
            //openfile.ShowDialog();

            var browsefile = openfile.ShowDialog();

            txtFilePath.Text = openfile.FileName;
            string chosenFile;

            chosenFile = txtFilePath.Text.ToString();


            if (browsefile == true)
            {
                
                Thread t = new Thread(() => ReadLabels(chosenFile));
                t.Start();
                //t.Join();
               
            }

        }

        private void PrintLabels(string selectedport)
        {
            Updater uiUpdater = new Updater(UpdatetxtInfo1);
            Dispatcher.BeginInvoke(DispatcherPriority.Send, uiUpdater, "Trwa drukowanie", Brushes.Red);

            StringCollection columnNames = new StringCollection();
            foreach (DataColumn oneColumn in dt.Columns)
            {
                columnNames.Add(oneColumn.ColumnName);
            }

            //TODO: test printing without using printer
            /* foreach (DataRow oneRow in dt.Rows)
             {

                 //RawPrinterHelper.SendStringToPrinter("Generic / Text Only", LablelStringToPrinter.StringToPrinter(OneRow));

                 //Dispatcher.BeginInvoke(DispatcherPriority.Send, uiUpdater, $"Trwa drukowanie {printnumber++} / {dt.Rows.Count} ", Brushes.Red);

                 LablelStringToPrinter.StringToPrinter(oneRow, printedScript, columnNames);
             }*/



            SerialPort MyCOMPort = new SerialPort(); // Create a new SerialPort Object

            //COM port settings to 8N1 mode 
            //MyCOMPort.PortName = "COM9";            // Name of the COM port 
            MyCOMPort.PortName = selectedport;              // Name of the COM port 
            MyCOMPort.BaudRate = 9600;               // Baudrate = 9600bps
            MyCOMPort.Parity = Parity.None;          // Parity bits = none  
            MyCOMPort.DataBits = 8;                  // No of Data bits = 8
            MyCOMPort.StopBits = StopBits.One;       // No of Stop bits = 1

            MyCOMPort.Open();


            int printnumber;
            printnumber = 1;


            //TODO: printing rows based on excel
            Dispatcher.BeginInvoke(DispatcherPriority.Send, uiUpdater, $"Trwa drukowanie {printnumber++} / {dt.Rows.Count} ", Brushes.Red);
            System.Threading.Thread.Sleep(1500);

            foreach (DataRow oneRow in dt.Rows)
            {


                Dispatcher.BeginInvoke(DispatcherPriority.Send, uiUpdater, $"Trwa drukowanie {printnumber++} / {dt.Rows.Count} ", Brushes.Red);
                //MyCOMPort.Write(LablelStringToPrinter.StringToPrinter(oneRow, printedScript, columnNames));
                LablelStringToPrinter.StringToPrinter(oneRow, columnNames);
                //MyCOMPort.Write(LablelStringToPrinter.StringToPrinter(oneRow, columnNames));
                System.Threading.Thread.Sleep(1500);

            }

            MyCOMPort.Close();

            //using System.Threading.Tasks;

            Task.Run(() =>
            {
                Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                {
                    txtInfo1.Content = "Wybierz akcję.";
                    txtInfo1.Foreground = Brushes.Black;
                }), DispatcherPriority.Render);
                //Thread.Sleep(1);
            });

            Dispatcher.BeginInvoke(DispatcherPriority.Send, uiUpdater, $"Wybierz akcję ({dt.Rows.Count} pozycji).", Brushes.Black);
        }


        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {

            string selectedport = (string)comboboxforcom.SelectedValue;

            Thread t = new Thread(() => PrintLabels(selectedport));
            t.Start();

        }

        private void Cmb_Initialized(object sender, EventArgs e)
        {
            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                comboboxforcom.Items.Add(s);
            }
        }

        private void Cmb_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //TODO: this prints the selected port, uncomment this later
            btnPrint.IsEnabled = true;

           /* SerialPort MyCOMPort = new SerialPort();
            MyCOMPort.PortName = (string)comboboxforcom.SelectedValue;            // Name of the COM port 
            MyCOMPort.BaudRate = 9600;               // Baudrate = 9600bps
            MyCOMPort.Parity = Parity.None;          // Parity bits = none  
            MyCOMPort.DataBits = 8;                  // No of Data bits = 8
            MyCOMPort.StopBits = StopBits.One;       // No of Stop bits = 1
            MyCOMPort.Open();
            MyCOMPort.Write(String.Join(Environment.NewLine,
                                                            "ALIGN 1",

                                                            "FONT \"Univers Bold\", 20",
                                                            "PRPOS10, 30",
                                                            "PRTXT \"" + (string)comboboxforcom.SelectedValue + "\"",

                                                            "PRINTFEED",
                                                            "NEXT"

                                        ));
            MyCOMPort.Close();*/

        }
    }
}

