using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
using Microsoft.Win32;

namespace HCIProjekat
{
    /// <summary>
    /// Interaction logic for NewTip.xaml
    /// </summary>
    public partial class NewTip : Window, INotifyPropertyChanged
    {
        private string _oznaka;
        private string _filePath;
        private string _opis;
        private string _ime;

        public NewTip(TipSpomenika tipSpomenika)
        {
            InitializeComponent();
            if (tipSpomenika == null)
            {
                _oznaka = "";
                _filePath = @"resources\NoImg300x225.jpg";
                _ime = "";
                _opis = "";
            }
            else
            {
                OznakaBox.IsEnabled = false;
                _oznaka = tipSpomenika.Oznaka;
                _filePath = tipSpomenika.IkonicaPath;
                _ime = tipSpomenika.Ime;
                _opis = tipSpomenika.Opis;
            }
            
            this.DataContext = this;
            
        }

        public string OznakaTip
        {
            get { return _oznaka; }
            set
            {
                if (!value.Equals(_oznaka))
                {
                    _oznaka = value;
                    OnPropertyChanged("OznakaTip");
                }
            }
        }

        public string FilePathTip
        {
            get { return _filePath; }
            set
            {
                if (!value.Equals(_filePath))
                {
                    _filePath = value;
                    OnPropertyChanged("FilePathTip");
                }
            }
        }

        public string ImeTip
        {
            get { return _ime; }
            set
            {
                if (!value.Equals(_ime))
                {
                    _ime = value;
                    OnPropertyChanged("ImeTip");
                }
            }
        }

        public string Opis
        {
            get { return _opis; }
            set
            {
                _opis = value;
                OnPropertyChanged("Opis");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (OznakaBox.IsEnabled)
                    OznakaBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();

                ImeBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();

                //FileBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                if (Validation.GetHasError(ImeBox) /*|| Validation.GetHasError(FileBox)*/)
                {
                   /* MessageBox.Show("Molimo Vas da popunite polja oznacena sa *.", "Nepotpun unos.",
                        MessageBoxButton.OK, MessageBoxImage.Warning);*/
                }
                else if (Validation.GetHasError(OznakaBox) && OznakaBox.IsEnabled)
                {

                }
                else if (FilePathTip.Equals(@"resources\NoImg300x225.jpg"))
                {
                    MessageBox.Show("Molimo Vas da odaberete sliku tipa", "Nepotpun unos.",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                }
                else
                {
                    //TODO Proveri da li fajl postoji
                    TipSpomenika newTipSpomenika = new TipSpomenika(OznakaBox.Text, ImeBox.Text, _filePath,
                        OpisBox.Text);
                    if (Main.GetInstance().HasTipSpomenika(newTipSpomenika))
                    {
                        Main.GetInstance().TipspomenikaLista.Single(x => x.Oznaka.Equals(newTipSpomenika.Oznaka)).Opis =
                            newTipSpomenika.Opis;
                        Main.GetInstance()
                            .TipspomenikaLista.Single(x => x.Oznaka.Equals(newTipSpomenika.Oznaka))
                            .IkonicaPath = newTipSpomenika.IkonicaPath;
                        Main.GetInstance().TipspomenikaLista.Single(x => x.Oznaka.Equals(newTipSpomenika.Oznaka)).Ime =
                            newTipSpomenika.Ime;
                        Main.GetInstance().TipspomenikaLista.Single(x => x.Oznaka.Equals(newTipSpomenika.Oznaka)).Oznaka
                            = newTipSpomenika.Oznaka;
                       /* MessageBox.Show("Uspesno ste izmenili tip spomenika.", "Izmenjen tip spomenika.",
                            MessageBoxButton.OK,
                            MessageBoxImage.Asterisk);*/
                    }
                    else
                    {
                        Main.GetInstance().TipspomenikaLista.Add(newTipSpomenika);
                       /* MessageBox.Show("Uspesno ste dodali novi tip spomenika.", "Dodat novi tip spomenika.",
                            MessageBoxButton.OK,
                            MessageBoxImage.Asterisk);*/
                    }
                    NewTipWindow.Close();
                }
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("Molimo Vas kontaktirajte administratora.", "Sistemska greska!",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO DA LI STE SIGURNI MESSAGE BOX
            NewTipWindow.Close();
        }

        private void DialogButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            
            //TODO VISE FORMATA SLIKA?
            fileDialog.Filter = "Slike (*.jpg, *.gif, *.jpeg, *.jpe, *.png) | *.jpg;*.gif;*.jpeg;*.jpe;*.png";
            fileDialog.Multiselect = false;
            //KAKO RADI OVO?
            fileDialog.CheckFileExists = true;
            fileDialog.CheckPathExists = true;

            var result = fileDialog.ShowDialog();

             //Process open file dialog box results
            if (result == true)
            {
                FilePathTip = fileDialog.FileName;
                //FileBox.Text = fileDialog.FileName;
            }
        }

        
    }
}
