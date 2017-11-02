

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
#endregion


namespace Lock_Tech_operator_panel
{
    /// <summary>
    /// Interaction logic for Log_on_screen.xaml
    /// </summary>
    public partial class Log_on_screen : Window
    {
        public Log_on_screen()
        {
            InitializeComponent();
        }
        
        #region Globals
    
       //Define Operator as Mainwindow 
       MainWindow Operator = new MainWindow();
       //Define Guest as Guest_window
       Guest_Window Guest = new Guest_Window();

       //Set string for the username  
       public string Username_Admin = "Admin";
       //Set stirn fot the password to its corresponding hash
       public string password_Admin = "QaxpsSYQeoT948EoTWPEX1MMrbg090mcdE59b3KYsWURwD81Kbaykz+DhnN/IpqY33jPOQ1TWaXoY/9mUl+XZw==";
       //Set string for the username to username Operator
       public string username_operator = "Operator";
       //Set string for the username to username Guest 
       public string username_Guest = "Guest01";
       //Set string for the password to its corresponding hash
       public string password_operator = "I7lCNSz+JD0+fjOSxFsjOzGKMcYV7qGHXUinZGUXYZ0k3RcebkPiASJlTOkBPVa7S/7QZ0+C6TDL6soq982E4g==";
       //Set string for the password to its corresponding hash 
       public string password_Guest = "2gfAiiwu83EOaIv/R2qKCdUtbTS27jxBpLH1jylJeS7yAHlWXKDXjidYsztQoTyYKcCL32cNyALmJ/KJNk0gOg==";
       //Set the login status to default false 
       public bool login = false;
        #endregion

        #region Core_Functions

        /// <summary>
        /// Function to hash password for validation using the SHA-512 algoritme 
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public string Hasing_funtion(string password)
        {
            //Uses UTF 8 encoding and get the bytes from the enterted password
            var bytes = new UTF8Encoding().GetBytes(password);
            //Set var hashbyte to type byte
            byte[] hashbyte;
            //Define the used crypto algoritme
            using (var Hash_algoritme = new System.Security.Cryptography.SHA512Managed())
            {
                //var hashbyte is the amount of bytes outputed by SHA512
                hashbyte = Hash_algoritme.ComputeHash(bytes);

            }

            //Converts the bytes into a string of length 64 and returns this as function output 
            return Convert.ToBase64String(hashbyte);
 
        }

        
        /// <summary>
        /// Function to check if a username and password are correct
        /// </summary>
        private void LOGIN()
        {
            //Sets the parameter string password form the hash function to the string thats entered in the PSW_BOX
            var hash = Hasing_funtion(PSW_BOX.Password);
            
            //When username and password for the operator are correct open operator window
            if (hash.Equals(password_operator) && USER_NAME_TB.Text.Equals(username_operator))
            {
                login = true;
                Mouse.SetCursor(Cursors.Wait);
                Thread.Sleep(500);
                Operator.Show();
                this.Close();
                

            }

           //When username and password for the guest are correct open the guest window
           if(hash.Equals(password_Guest) && USER_NAME_TB.Text.Equals(username_Guest))
            {
                login = true;
                Mouse.SetCursor(Cursors.Wait);
                Thread.Sleep(500);
                Guest.Show();
                this.Close();
            }

            //When username and password for the admin are correct open all the windows 
            if (hash.Equals(password_Admin) && USER_NAME_TB.Text.Equals(Username_Admin))
            {
                login = true;
                Mouse.SetCursor(Cursors.Wait);
                Thread.Sleep(500);
                Operator.Show();
                Guest.Show();
                this.Close();
            }

            // when either of the above statements is false show messagebox and clear text & Passwordbox
            if (login.Equals(false))
            {
                PSW_BOX.Clear();
                Mouse.SetCursor(Cursors.Wait);
                Thread.Sleep(200);
                MessageBoxResult result = MessageBox.Show("Incorrect password or username", "Login error", MessageBoxButton.OKCancel, MessageBoxImage.Warning);

                if (result == MessageBoxResult.OK) { return; }
                if (result == MessageBoxResult.Cancel) { Application.Current.Shutdown(); }
            }
        }
        #endregion

        #region Window_Controls

       
        /// <summary>
        /// function that will preform login on click button by calling LOGIN
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LOGIN_BT_Click(object sender, RoutedEventArgs e)
        {
           
            LOGIN();
            
        }

        /// <summary>
        /// function that will show the user a message box,
        /// in the event that they forgot thier password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RESET_BT_Click(object sender, RoutedEventArgs e)
        {
            
            MessageBox.Show("If you forgot youre password, please contact system admin for a password reset", "information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// On pressing the enter key call function login
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param> 
        private void PSW_BOX_KeyDown(object sender, KeyEventArgs e)
        {
            // When Caps-lock is toggeld show label
            if (Keyboard.GetKeyStates(Key.CapsLock) == KeyStates.Toggled)
            {
                LB_CAPS_LOCK.Visibility = Visibility.Visible;
            }

            // When Caps-lock is off hide label
            if (Keyboard.GetKeyStates(Key.CapsLock) == KeyStates.None)
            {
                LB_CAPS_LOCK.Visibility = Visibility.Hidden;

            }
            // When enter is pressed inside the password box call login 
            if (e.Key.Equals(Key.Enter))
            {
                LOGIN();
            }
        }
       
        /// <summary>
        /// On pressing the enter key call function login 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void USER_NAME_TB_KeyDown(object sender, KeyEventArgs e)
        {
            // When Caps-lock is toggeld show label
            if (Keyboard.GetKeyStates(Key.CapsLock) == KeyStates.Toggled)
            {
                LB_CAPS_LOCK.Visibility = Visibility.Visible;
            }

            // When Caps-lock is not toggeld hide label
            if (Keyboard.GetKeyStates(Key.CapsLock) == KeyStates.None)
            {
                LB_CAPS_LOCK.Visibility = Visibility.Hidden;

            }
            
            //when enter is pressed in the user textbox call login 
            if (e.Key.Equals(Key.Enter))
            {
                LOGIN();
            }
        }
        #endregion

        #region Window_menu

        /// <summary>
        /// On clicking this menu item the application will close
        /// </summary>
        private void App_close_Click(object sender, RoutedEventArgs e)
        {
            
            Mouse.SetCursor(Cursors.Wait);
            Thread.Sleep(500);
            Application.Current.Shutdown();
        }

        #endregion

        
    }
}
