using System;
using System.Collections.Generic;
using System.IO;
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

namespace HCIProjekat
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        private string _ime;
        private string _prezime;
        private string _userName;
        private string _password;

        private List<User> sviKorisnici = new List<User>();

        public Register()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public string Ime
        {
            get { return _ime; }
            set { _ime = value; }
        }

        public string Prezime
        {
            get { return _prezime; }
            set { _prezime = value; }
        }

        public string UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private void Accept_OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void Escape_OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Register_Button_Click(object sender, RoutedEventArgs e)
        {
            User noviUser = new User();
            noviUser.Ime = Ime;
            noviUser.Prezime = Prezime;
            noviUser.Lozinka = PasswordBox.Password;
            noviUser.Username = UserName;

            sviKorisnici = ListUsers();

            if (HasUser(sviKorisnici, noviUser.Username) == null)
            {
                AddUser(noviUser);
                MessageBox.Show("Korisnik ušpesno registrovan!");
                var main = new MainWindow();
                this.Close();
                main.Show();
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

        private void Close_Button_Click(object sender, RoutedEventArgs e)
        { 
            var diag = new Login();
            this.Close();
            diag.Show();
        }

        public static List<User> ListUsers()
        {
            List<User> sviKorisnici = new List<User>();

            using (var fs = File.OpenRead(@"../../resources/userList.csv"))
            using(var reader = new StreamReader(fs))
            {
                while (!reader.EndOfStream)
                {
                    User user = new User();
                    var line = reader.ReadLine();
                    if (line != null)
                    {
                        var values = line.Split(',');

                        user.Ime = values[0];
                        user.Prezime = values[1];
                        user.Username = values[2];
                        user.Lozinka = values[3];
                    }
                    sviKorisnici.Add(user);
                }
            }
            return sviKorisnici;
        }

        public static User HasUser(List<User> listaUsers, string userName)
        {
            foreach (var user in listaUsers)
            {
                if (user.Username.Equals(userName))
                {
                    return user;
                }
            }
            return null;
        }

        public void AddUser(User noviUser)
        {
            var csv = new StringBuilder();
            var newLine = string.Format("{0},{1},{2},{3}", noviUser.Ime,noviUser.Prezime,noviUser.Username,noviUser.Lozinka);
            csv.AppendLine(newLine);
            File.AppendAllText(@"../../resources/userList.csv", csv.ToString());
        }

    }


}

