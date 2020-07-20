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
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace MoonRockCrafting_Bot
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Int32 Bronze_BM2DM = 3;
        Int32 Steel_BM2DM = 3;
        Int32 Mithril_BM2DM = 4;
        Int32 Adamantium_BM2DM = 3;
        Int32 Silver_BM2DM = 2;
        Int32 Orihalcon_BM2DM = 2;
        Int32 Gold_BM2DM = 4;
        Int32 TA_multiplier = 3;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Filter input
                if (this.Qty_MoonRock.Text.All(char.IsDigit))
                {
                    Int32 Qty_MoonRocks = Int32.Parse(this.Qty_MoonRock.Text);
                    //BM Output
                    this.Qty_Bronze_BM.Text = ((Qty_MoonRocks * Bronze_BM2DM * TA_multiplier)).ToString();
                    this.Qty_Steel_BM.Text = (Qty_MoonRocks * Steel_BM2DM * TA_multiplier).ToString();
                    this.Qty_Mithril_BM.Text = (Qty_MoonRocks * Mithril_BM2DM * TA_multiplier).ToString();
                    this.Qty_Adamantium_BM.Text = (Qty_MoonRocks * Adamantium_BM2DM * TA_multiplier).ToString();
                    this.Qty_Silver_BM.Text = (Qty_MoonRocks * Silver_BM2DM * TA_multiplier).ToString();
                    this.Qty_Orihalcon_BM.Text = (Qty_MoonRocks * Orihalcon_BM2DM * TA_multiplier).ToString();
                    this.Qty_Gold_BM.Text = (Qty_MoonRocks * Gold_BM2DM * TA_multiplier).ToString();


                    //DM Output
                    this.Qty_Bronze_DM.Text = (Qty_MoonRocks * TA_multiplier).ToString();
                    this.Qty_Steel_DM.Text = (Qty_MoonRocks * TA_multiplier).ToString();
                    this.Qty_Mithril_DM.Text = (Qty_MoonRocks * TA_multiplier).ToString();
                    this.Qty_Adamantium_DM.Text = (Qty_MoonRocks * TA_multiplier).ToString();
                    this.Qty_Silver_DM.Text = (Qty_MoonRocks * TA_multiplier).ToString();
                    this.Qty_Orihalcon_DM.Text = (Qty_MoonRocks * TA_multiplier).ToString();
                    this.Qty_Gold_DM.Text = (Qty_MoonRocks * TA_multiplier).ToString();
                    this.Qty_Elixir_DM.Text = (Qty_MoonRocks).ToString();

                    //Mold Output
                    this.Qty_Basic.Text = (Qty_MoonRocks * TA_multiplier * 3).ToString();
                    this.Qty_Intermediate.Text = (Qty_MoonRocks * TA_multiplier * 4).ToString();
                    this.Qty_Advanced.Text = (Qty_MoonRocks * TA_multiplier * 0).ToString();
                    this.Qty_Superior.Text = (Qty_MoonRocks * TA_multiplier * 0).ToString();

                }
                else
                {
                    MessageBox.Show("Error, Please type in number only");
                }
            }
            catch(Exception Qty_MoonRock_Input)
            {
                MessageBox.Show(Qty_MoonRock_Input.Message);
            }


        }

        private void Run_Bot_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BringMainWindowToFront("MapleStory");
            }
            catch(Exception es)
            {
                MessageBox.Show(es.Message);
            }
                

        }



        //Focus on Another Application Code
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
        private static extern bool ShowWindow(IntPtr hWnd, ShowWindowEnum flags);

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hwnd);

        private enum ShowWindowEnum
        {
            Hide = 0,
            ShowNormal = 1, ShowMinimized = 2, ShowMaximized = 3,
            Maximize = 3, ShowNormalNoActivate = 4, Show = 5,
            Minimize = 6, ShowMinNoActivate = 7, ShowNoActivate = 8,
            Restore = 9, ShowDefault = 10, ForceMinimized = 11
        };

        public void BringMainWindowToFront(string processName)
        {
            // get the process
            Process bProcess = Process.GetProcessesByName(processName).FirstOrDefault();

            // check if the process is running
            if (bProcess != null)
            {
                // check if the window is hidden / minimized
                if (bProcess.MainWindowHandle == IntPtr.Zero)
                {
                    // the window is hidden so try to restore it before setting focus.
                    ShowWindow(bProcess.Handle, ShowWindowEnum.Restore);
                }

                // set user the focus to the window
                SetForegroundWindow(bProcess.MainWindowHandle);
            }
            else
            {
                // the process is not running, so start it
                Process.Start(processName);
            }
        }


    }

}

