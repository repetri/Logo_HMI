

#region Using
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
using System.Windows.Shapes;
using System.Threading;
using System.Diagnostics;
using Sharp7;
#endregion 


namespace Lock_Tech_operator_panel
{
    /// <summary>
    /// Interaction logic for Guest_Window.xaml
    /// </summary>
    public partial class Guest_Window : Window
    {
        public Guest_Window()
        {
            InitializeComponent();
        }

        #region Timer functions

        //Public boolean to check when the timer has to be active 
        public bool timer_value;
        
        /// <summary>
        /// Function that contains a timer that will exucte the function on line 202 every 10 seconds 
        /// </summary>
        /// <param name="timer"></param>
        /// <returns></returns>
        public bool Connection_timer(bool timer)
        {
            
            System.Windows.Threading.DispatcherTimer Con_timer = new System.Windows.Threading.DispatcherTimer();
            Con_timer.Tick += new EventHandler(Connectiontimer_Tick);
            Con_timer.Interval = new TimeSpan(0,0,8);

            if (timer.Equals(true))
            {
                Con_timer.Start();
                timer_value = true;
            }

            if (timer.Equals(false))
            {
                Con_timer.Stop();
                timer_value = false;
                
            }

            return(bool)(timer) && (bool)(timer_value); 
           
            
        }

        #endregion

        #region Menu_contorls

        //On click File log out: Log-on-screen opens
        private void Log_out_Click(object sender, RoutedEventArgs e)
        {
            Log_on_screen log_out = new Log_on_screen();

            Mouse.SetCursor(Cursors.Wait);
            Thread.Sleep(500);
            this.Close();
            log_out.Show();
        }

        //On click File Close: Application closes
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Mouse.SetCursor(Cursors.Wait);
            Thread.Sleep(500);
            Application.Current.Shutdown();
        }

        //On click File open website: Firefox's starts and opens arduino websever
        private void Open_website_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("Firefox", "192.168.1.7");
        }

        //On click Connections Conect: Connection with PLC will be established
        private void Connect_Click(object sender, RoutedEventArgs e)
        {
            Connection_timer(true);
        }

        //On click Connections Disconnect: Connection with PLC will be terminated
        private void Discon_PLC_Click(object sender, RoutedEventArgs e)
        {
            Connection_timer(false);
            Disconnect();
        }

        #endregion

        #region Color calibration 

        //Sets the color to default (white)
        readonly Color ColDef = Color.FromRgb(255, 255, 255);
        //Sets the color to red
        readonly Color ColRed = Color.FromRgb(255, 0, 0);
        //Sets the color to green 
        readonly Color ColGreen = Color.FromRgb(0, 255, 0);
        //Sets the color to orange 
        readonly Color ColOrange = Color.FromRgb(255, 95, 0);

        #endregion 

        #region Communication with PLC

        //Set Client as new s7client
        S7Client Client = new S7Client();

        //Set ipaddress and Local_TSAP & Remote_TSAP belonging to the plc 
        public string ipaddress = "192.168.1.10";
        public ushort Local_TSAP = 0x0200;
        public ushort Remote_TSAP = 0x0300;

        /// <summary>
        /// Function that sets up the connection parameters 
        /// </summary>
        /// <param name="ipaddress"></param>
        /// <param name="Local_TSAP"></param>
        /// <param name="Remote_TSAP"></param>
        private void Connect (string ipaddress, ushort Local_TSAP, ushort Remote_TSAP)
        {
            Client.SetConnectionParams(ipaddress,Local_TSAP,Remote_TSAP);
            Connection_check();
        }

        //Check if the connction syntax is vaild before connection or throw error
        private void Connection_check()
        {
            int error = Client.Connect();

            if (error == 0)
            {
                Client.Connect();
                LED_Connection.Fill = new SolidColorBrush(ColGreen);
                TB_errors.Clear();
                
            }

            if (error > 0)
            {
                LED_Connection.Fill = new SolidColorBrush(ColRed);
                TB_errors.AppendText(Client.ErrorText(error));
               
            }

        }

        //Terminates the connction with the PLC
        private void Disconnect()
        {
            Connection_timer(false);
            LED_Connection.Fill = new SolidColorBrush(ColDef);
            TB_errors.Clear();
            Client.Disconnect();
          

        }

       /// <summary>
       /// Function that makes a buffer to write into PLC VB memory
       /// </summary>
       /// <param name="address"></param>
       /// <param name="bitNR"></param>
       /// <returns></returns>
        private bool Read_bit(int address, int bitNR)
        {
            if (bitNR > 7) { bitNR = 7; }
            if (bitNR < 0) { bitNR = 0; }
            if (address < 0) { address = 0; }

            byte[] buffer = new byte[1];

            int error = Client.ReadArea(Sharp7.S7Consts.S7AreaDB, 1, bitNR, 1, Sharp7.S7Consts.S7WLBit, buffer);
            if (error > 0) { TB_errors.Text = Client.ErrorText(error); }

            return (bool)(buffer[0] > 0);
        }


        #endregion

        #region Timer contorls

        //Timed function that ensures connection to the PLC is kept alive 
        private void Connectiontimer_Tick(object sender, EventArgs e)
        {

            if (Client.Connected)
            {
                Connection_timer(false);
            }

            if (timer_value.Equals(true))
            {
                Connect(ipaddress, Local_TSAP, Remote_TSAP);
            }

            if (timer_value.Equals(false) && Client.Connected.Equals(false)) 
            {
                Disconnect();
            }

        }
        # endregion

        #region Window Contorls

        //Stops a cycle when it is running 
        private void BT_stop_Click(object sender, RoutedEventArgs e)
        {

        }

        //Starts a full cycle and keeps flashing LED_busy until the cycle is completed 
        private void BT_start_Click(object sender, RoutedEventArgs e)
        {
            Connect(ipaddress,Local_TSAP,Remote_TSAP);

            while (Read_bit(0, 0).Equals(true))

            {
                LED_Busy.Fill = new SolidColorBrush(ColOrange);
                Thread.Sleep(500);
                LED_Busy.Fill = new SolidColorBrush(ColDef);

                if (Read_bit(0, 0).Equals(false)) { break;  }
            }
          
        }

        //Allows Error textbox to autoscroll down to last message 
        private void TB_errors_TextChanged(object sender, TextChangedEventArgs e)
        {
            TB_errors.SelectionStart = TB_errors.Text.Length;
            TB_errors.ScrollToEnd();
        }



        #endregion

       
    }
}
