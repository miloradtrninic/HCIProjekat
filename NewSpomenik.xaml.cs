using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
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
using Microsoft.Win32;

namespace HCIProjekat
{
    /// <summary>
    /// Interaction logic for NewSpomenik.xaml
    /// </summary>
    public partial class NewSpomenik : Window,INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private List<string> _eraPorekla;
        private List<string> _turistickiStatus;

        //TODO NAMESTI ETIKETU U EDITU
        private double _prihod;
        private string _oznaka;
        private string _ime;
        private string _imagePath;
        private string _opis;
        private string _era;
        private string _turizam;

        private bool _unescoChecked;
        private bool _naseljeChecked;
        private bool _areheoChecked;

        private TipSpomenika _tipSpomenika;

        public NewSpomenik(Spomenik spomenik)
        {
            InitializeComponent();
                     
            _eraPorekla = new List<string>(new string[] { "Paleolit", "Neolit", "Stari vek","Srednji vek","Renesansa","Moderno doba" });
            _turistickiStatus = new List<string>(new string[] { "Dostupan", "Nedostupan", "Eksploatisan" });
            if (spomenik == null)
            {
                _prihod = 0.0;
                _oznaka = "";
                _ime = "";
                _imagePath = "";
                _opis = "";
                _unescoChecked = true;
                _naseljeChecked = true;
                _areheoChecked = true;
                _tipSpomenika = new TipSpomenika();
                _era = "Paleolit";
                _turizam = "Dostupan";
            }
            else
            {
                _prihod = Double.Parse(spomenik.GodisnjiPrihod);
                _oznaka = spomenik.Oznaka;
                _imagePath = spomenik.IkonicaPath;
                _opis = spomenik.Opis;
                _ime = spomenik.Ime;
                _unescoChecked = spomenik.Unesco;
                _naseljeChecked = spomenik.Unesco;
                _areheoChecked = spomenik.Unesco;
                _tipSpomenika = spomenik.Tip;
                _era = spomenik.EraPorekla;
                _turizam = spomenik.TuristickiStatus;

            }
            this.DataContext = this;
        }

      
        public double Prihod
        {
            get { return _prihod; }
            set
            {
                if (value != _prihod)
                {
                    _prihod = value;
                    OnPropertyChanged("Prihod");
                }
            }
        }

        public string Oznaka
        {
            get { return _oznaka; }
            set 
            {
                if (!value.Equals(_oznaka))
                {
                    _oznaka = value;
                    OnPropertyChanged("Oznaka");
                }
            }
        }

        public string Ime
        {
            get { return _ime; }
            set
            {
                if (!value.Equals(_ime))
                {
                    _ime = value;
                    OnPropertyChanged("Ime");
                }
            }
        }

        public string ImagePath
        {
            get { return _imagePath; }
            set { _imagePath = value; }
        }

        public TipSpomenika Spomenika
        {
            get { return _tipSpomenika; }
            set
            {
                _tipSpomenika = value;
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

        public bool UnescoChecked
        {
            get { return _unescoChecked; }
            set { _unescoChecked = value; }
        }

        public bool NaseljeChecked
        {
            get { return _naseljeChecked; }
            set { _naseljeChecked = value; }
        }

        public bool AreheoChecked
        {
            get { return _areheoChecked; }
            set { _areheoChecked = value; }
        }

        public string Era
        {
            get { return _era; }
            set { _era = value; }
        }

        public string Turizam
        {
            get { return _turizam; }
            set { _turizam = value; }
        }

        public List<string> EraPorekla
        {
            get { return _eraPorekla; }
            set { _eraPorekla = value; }
        }

        public List<string> TuristickiStatus
        {
            get { return _turistickiStatus; }
            set { _turistickiStatus = value; }
        }


        /*  public void IsCheckedUnesco(object sender, RoutedEventArgs eventArgs)
        {
            var radioButton = sender as RadioButton;
            if (radioButton != null)
            {
                _unescoChecked = (string) radioButton.Content;
               
            }
        }

        public void IsCheckedNaselje(object sender, RoutedEventArgs eventArgs)
        {
            var radioButton = sender as RadioButton;
            if (radioButton != null) _naseljeChecked = (string) radioButton.Content;
        }
        public void IsCheckedArheo(object sender, RoutedEventArgs eventArgs)
        {
            var radioButton = sender as RadioButton;
            if (radioButton != null) _areheoChecked = (string)radioButton.Content;
        }
        */

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

            // Process open file dialog box results
            if (result == true)
            {
                FileBox.Text = fileDialog.FileName;
            }
        }
       



        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
            //TODO DA LI TREBA DA BUDE ETIKETA OBAVEZNA i KAKO TREBA ETIKETA DA IZGLEDA
            try
            {
                //ispaljuje event na silu, jer bi inace mogao da prodje bez provere
                OznakaBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                ImeBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                PrihodBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                
                if (Validation.GetHasError(OznakaBox) || Validation.GetHasError(ImeBox) ||
                    Validation.GetHasError(PrihodBox) || Kalendar.SelectedDate == null)
                {
                    MessageBox.Show("Postoje greske u unosu. Molimo ispravite i pokusajte ponovo", "Unos neispravan",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                } else if (TipBox.SelectedIndex == -1)
                {
                    MessageBox.Show("Postoje greske u unosu. Molimo izaberite tip spomenika", "Unos neispravan",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                } 
                else
                {
                    bool unseco = _unescoChecked;
                    bool naselje = _naseljeChecked;
                    bool arheo = _areheoChecked;
                    Spomenik newSpomenik = new Spomenik(_oznaka, _ime, _opis, _era,
                        _turizam, _imagePath, unseco, naselje, arheo, _prihod.ToString(), 
                        Kalendar.SelectedDate.Value, _tipSpomenika);
                    if (Main.GetInstance().HasSpomenik(newSpomenik))
                    {
                        Main.GetInstance().GetSpomenikLista.Single(x => x.Oznaka.Equals(newSpomenik.Oznaka)).Oznaka =
                            newSpomenik.Oznaka;
                        Main.GetInstance()
                            .GetSpomenikLista.Single(x => x.Oznaka.Equals(newSpomenik.Oznaka))
                            .GodisnjiPrihod = newSpomenik.GodisnjiPrihod;
                        Main.GetInstance().GetSpomenikLista.Single(x => x.Oznaka.Equals(newSpomenik.Oznaka)).Ime =
                            newSpomenik.Ime;
                        Main.GetInstance().GetSpomenikLista.Single(x => x.Oznaka.Equals(newSpomenik.Oznaka)).EraPorekla
                            = newSpomenik.EraPorekla;
                        Main.GetInstance()
                            .GetSpomenikLista.Single(x => x.Oznaka.Equals(newSpomenik.Oznaka))
                            .TuristickiStatus = newSpomenik.TuristickiStatus;
                        Main.GetInstance().GetSpomenikLista.Single(x => x.Oznaka.Equals(newSpomenik.Oznaka)).IkonicaPath
                            = newSpomenik.IkonicaPath;

                        Main.GetInstance().GetSpomenikLista.Single(x => x.Oznaka.Equals(newSpomenik.Oznaka)).Opis =
                            newSpomenik.Opis;
                        Main.GetInstance()
                            .GetSpomenikLista.Single(x => x.Oznaka.Equals(newSpomenik.Oznaka))
                            .DatumOtkrivanja = newSpomenik.DatumOtkrivanja;

                        Main.GetInstance().GetSpomenikLista.Single(x => x.Oznaka.Equals(newSpomenik.Oznaka)).Tip =
                            newSpomenik.Tip;
                        Main.GetInstance().GetSpomenikLista.Single(x => x.Oznaka.Equals(newSpomenik.Oznaka)).Etikete =
                            newSpomenik.Etikete;

                        Main.GetInstance().GetSpomenikLista.Single(x => x.Oznaka.Equals(newSpomenik.Oznaka)).Unesco =
                            newSpomenik.Unesco;
                        Main.GetInstance().GetSpomenikLista.Single(x => x.Oznaka.Equals(newSpomenik.Oznaka)).Naselje =
                            newSpomenik.Naselje;
                        Main.GetInstance().GetSpomenikLista.Single(x => x.Oznaka.Equals(newSpomenik.Oznaka)).Arheo =
                            newSpomenik.Arheo;
                        MessageBox.Show("Uspesno ste izmenili spomenik.", "Izmenjen spomenik.",
                            MessageBoxButton.OK, MessageBoxImage.Asterisk);

                    }
                    else
                    {
                        newSpomenik.Tip = _tipSpomenika;
                        if (FileBox.Text.Equals(""))
                        {
                            ;
                            newSpomenik.IkonicaPath = _tipSpomenika.IkonicaPath;
                        }
                        Main.GetInstance().GetSpomenikLista.Add(newSpomenik);
                        // Console.WriteLine(Main.GetInstance().GetSpomenikLista.Count);
                        MessageBox.Show("Uspesno ste dodali novi spomenika.", "Dodat novi spomenik.",
                            MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    }
                    NewSpomenikWindow.Close();
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Molimo Vas kontaktirajte administratora.", "Sistemska greska!",
                        MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            NewSpomenikWindow.Close();
        }

       

       
    }
}
