

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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.IO;
using System.Diagnostics;
using Sharp7;
#endregion


namespace Lock_Tech_operator_panel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Sensor Values

        public bool Water_Sensor()
        {
            return Read_bit_out_VB_mem(30, 0) == true;
        }

        public bool Bridge1_Sensor()
        {
            return Read_bit_out_VB_mem(13, 0) == true;
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

        #region Timer functions

        //Public boolean to check when the timer has to be active 
        public bool timer_value;

        /// <summary>
        /// Function that contains a timer that will exucte the function on line 292 every 10 seconds 
        /// </summary>
        /// <param name="timer"></param>
        /// <returns></returns>
        public bool Connection_timer(bool timer)
        {

            System.Windows.Threading.DispatcherTimer Con_timer = new System.Windows.Threading.DispatcherTimer();
            Con_timer.Tick += new EventHandler(CON_Timer_Tick);
            Con_timer.Interval = new TimeSpan(0, 0, 8);

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

            return (bool)(timer) && (bool)(timer_value);


        }

        #endregion

        #region PLC Comunication


        //Set Client as new S7client
        S7Client Client = new S7Client();

        //Set IP address and Local TSAP & Remote TSAP belonging to the PLC 
        public string IPaddress = "192.168.1.10";
        public ushort Local_TSAP = 0x0200;
        public ushort Remote_TSAP = 0x0300;

        /// <summary>
        /// Function that will set parameters for connection and call connect
        /// </summary>
        /// <param name="IPaddress"/> takes the PLC ip adress
        /// <param name="Local_TSAP"/> takes the PLC local TSAP
        /// <param name="Remote_TSAP"/> takes the PLC remote TSAP
        private void Connection_Parameters(string IPaddress, ushort Local_TSAP, ushort Remote_TSAP)
        {
            Client.SetConnectionParams(IPaddress, Local_TSAP, Remote_TSAP);
            Connection_check();
        }

        /// <summary>
        /// Function that checks if there is no connection error
        /// </summary>
        private void Connection_check()
        {
            int Con_error = Client.Connect();

            if (Con_error == 0)
            {
                Connection_status.Fill = new SolidColorBrush(ColGreen);
                TB_errors_main.Clear();

            }

            if (Con_error > 0)
            {
                Connection_status.Fill = new SolidColorBrush(ColRed);
                TB_errors_main.AppendText(Client.ErrorText(Con_error));

            }

            
        }


        public bool Read_bit_out_VB_mem(int address, int BitNR)
        {
            // Make sure the input values do not exceed max
            if (BitNR > 7) { BitNR = 7; }
            if (BitNR < 0) { BitNR = 0; }
            if (address < 0) { address = 0; }

            // Ensure a connection to the LOGO
            int error_Bit = Client.Connect();
            if (error_Bit > 0)
            {
                TB_errors_main.Text = Client.ErrorText(error_Bit);
                
            }
            // Calculate the bit's address in bits MAY CAUSE PROBLEM!!!
            int bitAddr = address * 8 + BitNR;

            // Prepare a buffer to read into
            byte[] buffer = new byte[1];

            // Read the variable
            int error = Client.ReadArea(Sharp7.S7Consts.S7AreaDB, 1, 0, 1, Sharp7.S7Consts.S7WLBit, buffer);
            // throw an exception if there is a communication error
            if (error > 0) {TB_errors_main.AppendText(Client.ErrorText(error));}

            // convert read bit to boolean value and return
          
            return (bool)(buffer[0] > 0);


        }


        /// <summary>
        /// function that will preform login on click button
        /// </summary>
        /// <param name="address"/> takes the memory address (1/7)
        /// <param name="BitNR"/> takes the BitNR (0)
        private void Write_bit_to_VB_mem(int address, int BitNR, bool status)
        {
            // Make sure the input values do not exceed max
            if (BitNR > 7) { BitNR = 7; }
            if (BitNR < 0) { BitNR = 0; }
            if (address < 0) { address = 0; }

            // Ensure a connection to the LOGO
            int error_Bit = Client.Connect();
            if (error_Bit > 0)
            {
                TB_errors_main.Text = Client.ErrorText(error_Bit);
                return;
            }
            // Calculate the bit's address in bits
            int bitAddr = address * 8 + BitNR;

            // Prepare a buffer to write from
            byte[] buffer = new byte[1];

            // Set the value in the buffer according to the bit value
            if (status) { buffer[0] = 0x01; }
            else { buffer[0] = 0x00; }


        }

        //Terminates connection with the PLC 
        private void disconnect()
        {
            Connection_timer(false);
            Connection_status.Fill = new SolidColorBrush(ColDef);
            TB_errors_main.Clear();
            Client.Disconnect();
        }



        #endregion

        #region Window_menu

        /// <summary>
        /// On clicking this menu item the application will close 
        /// </summary>
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Mouse.SetCursor(Cursors.Wait);
            Thread.Sleep(500);
            Application.Current.Shutdown();
        }

        /// <summary>
        /// On clicking this menu item the log-on window will show
        /// </summary>
        private void Log_out_Click(object sender, RoutedEventArgs e)
        {
            Log_on_screen log_on = new Log_on_screen();
            Mouse.SetCursor(Cursors.Wait);
            Thread.Sleep(500);
            this.Close();
            log_on.Show();
        }

        /// <summary>
        /// On clicking this menu item the arduino webserver will be opend
        /// </summary>
        private void Open_web_Click(object sender, RoutedEventArgs e)
        {
            Process.Start("Firefox", "192.168.1.7");
        }




        #endregion

        #region Windowcontrol

        /// <summary>
        /// Function that scrolls to the last error message 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TB_errors_main_TextChanged(object sender, TextChangedEventArgs e)
        {
            TB_errors_main.SelectionStart = TB_errors_main.Text.Length;
            TB_errors_main.ScrollToEnd();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start_selection_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Water_level_Click(object sender, RoutedEventArgs e)
        {
            Read_bit_out_VB_mem(30, 0);
        }

        private void Bridge_1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Gate_1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Gate_2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Bridge_2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Arrow_up_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Arrow_down_Click(object sender, RoutedEventArgs e)
        {

        }
        #endregion

        #region Timer control
        /// <summary>
        /// Keep alive connection with the plc 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CON_Timer_Tick(object sender, EventArgs e)
        {

            if (Client.Connected)
            {
                Connection_timer(false);
            }


            if (timer_value.Equals(true)||Client.Connected.Equals(false))
            {
                Connection_Parameters(IPaddress, Local_TSAP, Remote_TSAP);

            }

            if (timer_value.Equals(false) && Client.Connected.Equals(false)) 
            {
                disconnect();

            }



        }

        #endregion  

        #region Window menu

        /// <summary>
        /// Onclik set timer connection to true and connect to PLC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Con_PLC_Click(object sender, RoutedEventArgs e)
        {
            Connection_timer(true);
        }

        /// <summary>
        /// Onclick set timer connection to false and disconnect form PLC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DisCon_PLC_Click(object sender, RoutedEventArgs e)
        {
            Connection_timer(false);
            disconnect();
        }

        #endregion

        #region Voids
        //Stores the Values for running the Interface viewbox
        private void Grapical_interface_Loaded(object sender, RoutedEventArgs e)
        {

        }
        #endregion
    }
}
