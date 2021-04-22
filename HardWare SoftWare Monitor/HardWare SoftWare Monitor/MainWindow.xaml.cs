using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using Microsoft.Win32;
using System.Management;
using System.IO;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;




namespace Pc_Monitoring_Software_Hardware
{

    public partial class MainWindow : Window
    {




        public MainWindow()
        {
            InitializeComponent();
            GetInstalledApps();

        }
        private void Betoltes(object sender, EventArgs e)
        {
            gomb_2.IsEnabled = false;




        }

        private void gomb_2_Click(object sender, RoutedEventArgs e)
        {
            text_1.Text = "";
            text_2.Text = "";
            text_3.Text = "";
            text_5.Text = "";
            text_6.Text = "";
            text_7.Text = "";
            text_8.Text = "";
            text_9.Text = "";

        }
        public String a1 = Environment.MachineName;
        public String a2 = Environment.UserName;
        public int a6 = Environment.ProcessorCount;
        public String a3 = (Environment.OSVersion.ToString());
        public String a5 = (Environment.OSVersion.Platform.ToString());
        public String a7 = Environment.CurrentDirectory;
        public String a8 = Environment.SystemDirectory;
        public String a9 = Environment.UserDomainName;



        private void gomb_1_Click(object sender, RoutedEventArgs e)
        {

            text_1.Text = a1;


            text_2.Text = a2;


            text_6.Text = Convert.ToString(a6);

            text_3.Text = a3;


            text_5.Text = a5;



            text_7.Text = a7;


            text_8.Text = a8;


            text_9.Text = a9;

        }


        private void gomb_3_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public void GetInstalledApps()

        {

            string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";

            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKey))

            {

                foreach (string skName in rk.GetSubKeyNames())

                {

                    using (RegistryKey sk = rk.OpenSubKey(skName))

                    {




                        listBox.Items.Add(sk.GetValue("DisplayName"));



                    }

                }

                label.Content = listBox.Items.Count.ToString();

            }

        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SelectQuery Sq = new SelectQuery("Win32_Processor");
            ManagementObjectSearcher objOSDetails = new ManagementObjectSearcher(Sq);
            ManagementObjectCollection osDetailsCollection = objOSDetails.Get();
            StringBuilder sb = new StringBuilder();
            foreach (ManagementObject mo in osDetailsCollection)
            {
                sb.AppendLine(string.Format("Name : {0}", (string)mo["Name"]));
                sb.AppendLine(string.Format("Availability: {0}", (ushort)mo["Availability"]));
                sb.AppendLine(string.Format("Architecture: {0}", (ushort)mo["Architecture"]));
                sb.AppendLine(string.Format("AddressWidth: {0}", (ushort)mo["AddressWidth"]));
                sb.AppendLine(string.Format("Caption: {0}", (string)mo["Caption"]));
                sb.AppendLine(string.Format("InstallDate: {0}", Convert.ToDateTime(mo["InstallDate"]).ToString()));
                sb.AppendLine(string.Format("ConfigManagerUserConfig: {0}", (string)mo["ConfigManagerUserConfig"]));
                sb.AppendLine(string.Format("CpuStatus : {0}", (ushort)mo["CpuStatus"]));
                sb.AppendLine(string.Format("CreationClassName : {0}", (string)mo["CreationClassName"]));
                sb.AppendLine(string.Format("CurrentClockSpeed : {0}", mo["CurrentClockSpeed"]).ToString());
                sb.AppendLine(string.Format("CurrentVoltage : {0}", (ushort)mo["CurrentVoltage"]));
                sb.AppendLine(string.Format("DataWidth : {0}", (ushort)mo["DataWidth"]));
                sb.AppendLine(string.Format("Description: {0}", (string)mo["Description"]));
                sb.AppendLine(string.Format("DeviceID : {0}", (string)mo["DeviceID"]));
                sb.AppendLine(string.Format("ErrorCleared: {0}", (string)mo["ErrorCleared"]));
                sb.AppendLine(string.Format("ErrorDescription : {0}", (string)mo["ErrorDescription"]));
                sb.AppendLine(string.Format("ExtClock : {0}", mo["ExtClock"]).ToString());
                sb.AppendLine(string.Format("Family : {0}", (ushort)mo["Family"]));
                sb.AppendLine(string.Format("L2CacheSize : {0}", mo["L2CacheSize"]).ToString());
                sb.AppendLine(string.Format("L2CacheSpeed : {0}", mo["L2CacheSpeed"]).ToString());
                sb.AppendLine(string.Format("L3CacheSize : {0}", mo["L3CacheSize"]).ToString());
                sb.AppendLine(string.Format("L3CacheSpeed : {0}", mo["L3CacheSpeed"]).ToString());
                sb.AppendLine(string.Format("LastErrorCode : {0}", mo["LastErrorCode"]).ToString());
                sb.AppendLine(string.Format("Level : {0}", (ushort)mo["Level"]));
                sb.AppendLine(string.Format("LoadPercentage: {0}", (ushort)mo["LoadPercentage"]));
                sb.AppendLine(string.Format("Manufacturer: {0}", (string)mo["Manufacturer"]));
                sb.AppendLine(string.Format("MaxClockSpeed : {0}", mo["MaxClockSpeed"]).ToString());
                sb.AppendLine(string.Format("NumberOfCores : {0}", mo["NumberOfCores"]).ToString());
                sb.AppendLine(string.Format("OtherFamilyDescription: {0}", (string)mo["OtherFamilyDescription"]));
                sb.AppendLine(string.Format("NumberOfLogicalProcessors : {0}", mo["NumberOfLogicalProcessors"]).ToString());
                sb.AppendLine(string.Format("PNPDeviceID: {0}", (string)mo["PNPDeviceID"]));
                sb.AppendLine(string.Format("PowerManagementSupported : {0}", mo["PowerManagementSupported"].ToString()));
                sb.AppendLine(string.Format("ProcessorId: {0}", (string)mo["ProcessorId"]));
                sb.AppendLine(string.Format("ProcessorType : {0}", (ushort)mo["ProcessorType"]));
                sb.AppendLine(string.Format("Revision: {0}", (ushort)mo["Revision"]));
                sb.AppendLine(string.Format("Role: {0}", (string)mo["Role"]));
                sb.AppendLine(string.Format("SocketDesignation : {0}", mo["SocketDesignation"]).ToString());
                sb.AppendLine(string.Format("Status : {0}", (string)mo["Status"]));
                sb.AppendLine(string.Format("StatusInfo: {0}", (ushort)mo["StatusInfo"]));
                sb.AppendLine(string.Format("Stepping : {0}", (string)mo["Stepping"]));
                sb.AppendLine(string.Format("SystemCreationClassName : {0}", (string)mo["SystemCreationClassName"]));
                sb.AppendLine(string.Format("SystemName: {0}", (string)mo["SystemName"]));
                sb.AppendLine(string.Format("UniqueId : {0}", (string)mo["UniqueId"]));
                sb.AppendLine(string.Format("UpgradeMethod: {0}", (ushort)mo["UpgradeMethod"]));
                sb.AppendLine(string.Format("Version: {0}", (string)mo["Version"]));
                sb.AppendLine(string.Format("VoltageCaps : {0}", mo["VoltageCaps"]).ToString());
            }
            MessageBox.Show(sb.ToString());



        }

        private void gomb_excel_Click(object sender, RoutedEventArgs e)
        {
            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("Az excel nincs rendesen telepítve!!");
                return;
            }


            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            xlWorkSheet.Cells[1, 1] = "Számítógép neve:";
            xlWorkSheet.Cells[1, 2] = a1;
            xlWorkSheet.Cells[2, 1] = "Felhasználó neve:";
            xlWorkSheet.Cells[2, 2] = a2;
            xlWorkSheet.Cells[3, 1] = "Verzió:";
            xlWorkSheet.Cells[3, 2] = a3;
            xlWorkSheet.Cells[4, 1] = "Operációs rendszer platformja:";
            xlWorkSheet.Cells[4, 2] = a5;
            xlWorkSheet.Cells[5, 1] = "Processzor szálak száma:";
            xlWorkSheet.Cells[5, 2] = a6;
            xlWorkSheet.Cells[6, 1] = "Program mappája:";
            xlWorkSheet.Cells[6, 2] = a7;
            xlWorkSheet.Cells[7, 1] = "Rendszer mappája:";
            xlWorkSheet.Cells[7, 2] = a8;
            xlWorkSheet.Cells[8, 1] = "Domain név:";
            xlWorkSheet.Cells[8, 2] = a9;








            xlWorkBook.SaveAs("D:\\Eskola\\HardWare SoftWare Monitor\\data.xls", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

            MessageBox.Show("Az adatok sikeresen elmentve!");
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
