using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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

namespace HCIProjekat
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private string username;
        private string password;

        public Login()
        {
            InitializeComponent();
            DataContext = this;
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string pass = "ftn";
            string user = "korisnik";
            if (UserBox.Text.Equals(user))
            {
                if (PasswordBox.Password.Equals(pass))
                {
                    MainWindow main = new MainWindow();
                    this.Close();
                    main.Show();
                }
                else
                {
                    PasswordBox.BorderBrush = new SolidColorBrush(Colors.Red);
                    PassBoxError.Visibility = Visibility.Visible;
                }
            }
            else
            {
                UserBox.BorderBrush = new SolidColorBrush(Colors.Red);
                UserBoxError.Visibility = Visibility.Visible;
            }
        }

        private void UserBox_OnGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            UserBox.ClearValue(BorderBrushProperty);
            UserBoxError.Visibility = Visibility.Hidden;
        }
        private void PasswordBox_OnGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            PasswordBox.ClearValue(BorderBrushProperty);
            PassBoxError.Visibility = Visibility.Hidden;
        }
        private void Accept_OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
