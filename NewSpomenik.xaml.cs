using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        //TODO DUGME ZA UKLANJANJE SLIKE
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
        private DateTime _datumOtkrivanja;

        


        private bool _unescoChecked;
        private bool _naseljeChecked;
        private bool _areheoChecked;

        //TODO 2. BIND ZA LISTU SELEKTOVANIH ETIKETA
        //TODO 3. AKO POSTOJI VEC SPOMENIK, TIP, ETIKETA SA ISTOM OZNAKOM PRI DODAVANJU OZNACITI VALIDACIJOM


        private TipSpomenika _tipSpomenika;
        private Spomenik _toEdit;

        public NewSpomenik(Spomenik spomenik)
        {
            InitializeComponent();
          
            _eraPorekla = new List<string>(new string[] { "Paleolit", "Neolit", "Stari vek","Srednji vek","Renesansa","Moderno doba" });
            _turistickiStatus = new List<string>(new string[] { "Dostupan", "Nedostupan", "Eksploatisan" });
            _toEdit = spomenik;
            if (spomenik == null)
            {
                _prihod = 0.0;
                _oznaka = "";
                _ime = "";
                _imagePath = @"resources\NoImg300x225.jpg";
                _opis = "";
                _unescoChecked = false;
                _naseljeChecked = false;
                _areheoChecked = false;
                _tipSpomenika = new TipSpomenika();
                _era = "Paleolit";
                _turizam = "Dostupan";
                _datumOtkrivanja = DateTime.Today.Date;
            }
            else
            {
                
                
                OznakaBox.IsEnabled = false;
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
                _datumOtkrivanja = spomenik.DatumOtkrivanja.Date;
                foreach (var etiketa in spomenik.Etikete)
                {
                    EtiketaBox.SelectedItems.Add(etiketa);
                }
               
            }
            this.DataContext = this;
            Kalendar.DisplayDateEnd = Convert.ToDateTime(DateTime.Now.ToShortTimeString()).Date;
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
            set
            {
                if (!value.Equals(_imagePath))
                {
                    _imagePath = value;
                    OnPropertyChanged("ImagePath");
                }
            }
        }

        public TipSpomenika Spomenika
        {
            get { return _tipSpomenika; }
            set
            {
                if (value != null  && !value.Equals(_tipSpomenika))
                {
                    _tipSpomenika = value;
                    if (_toEdit != null && _toEdit.SlikaTip)
                    {
                        ImagePath = _tipSpomenika.IkonicaPath;
                    }
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

        public DateTime DatumOtkrivanja
        {
            get { return _datumOtkrivanja; }
            set
            {
                _datumOtkrivanja = value;
                OnPropertyChanged("DatumOtkiravanja");
            }
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
                ImagePath = fileDialog.FileName;
                //FileBox.Text = fileDialog.FileName;
            }
            if (_toEdit != null)
            {
                _toEdit.SlikaTip = false;
            }
        }
       



        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            
            //TODO DA LI TREBA DA BUDE ETIKETA OBAVEZNA i KAKO TREBA ETIKETA DA IZGLEDA
            try
            {
                //ispaljuje event na silu, jer bi inace mogao da prodje bez provere
                if(OznakaBox.IsEnabled)
                {
                    var o = OznakaBox.GetBindingExpression(TextBox.TextProperty);
                    if (o != null)
                        o.UpdateSource();
                }

                var bindingExpression = ImeBox.GetBindingExpression(TextBox.TextProperty);
                if (bindingExpression != null)
                    bindingExpression.UpdateSource();
                var expression = PrihodBox.GetBindingExpression(TextBox.TextProperty);
                if (expression != null)
                    expression.UpdateSource();


                bool canSnimi = true;
                if (Validation.GetHasError(ImeBox) ||
                    Validation.GetHasError(PrihodBox) || Kalendar.SelectedDate == null)
                {
                    canSnimi = false;
                    /* MessageBox.Show("Postoje greske u unosu. Molimo ispravite i pokusajte ponovo", "Unos neispravan",
                         MessageBoxButton.OK, MessageBoxImage.Warning);*/
                } 
                if (Validation.GetHasError(OznakaBox) && OznakaBox.IsEnabled)
                {
                    canSnimi = false;
                }
                if (TipBox.SelectedIndex == -1)
                {
                    //MessageBox.Show("Postoje greske u unosu. Molimo izaberite tip spomenika", "Unos neispravan",
                        //MessageBoxButton.OK, MessageBoxImage.Warning);
                    canSnimi = false;
                    ErrorTip.Visibility = Visibility.Visible;
                }
                if (EtiketaBox.SelectedIndex == -1)
                {
                    canSnimi = false;
                    ErrorEtiketa.Visibility = Visibility.Visible;
                    EtiketaBox.BorderBrush = Brushes.Red;
                    EtiketaBox.BorderThickness = new Thickness(2, 2, 2, 2); 
                }
                if(canSnimi)
                {
                    bool unseco = _unescoChecked;
                    bool naselje = _naseljeChecked;
                    bool arheo = _areheoChecked;
                    var selectedItems = EtiketaBox.SelectedItems;
                   
                    if (_toEdit !=null)
                    {
                        _toEdit.Etikete.Clear();
                        foreach (var item in selectedItems)
                        {
                            _toEdit.Etikete.Add((Etiketa)item);
                        }
                        _toEdit.Oznaka = Oznaka;
                        _toEdit.GodisnjiPrihod = _prihod.ToString();
                        _toEdit.Ime = Ime;

                        _toEdit.EraPorekla = Era;
                        _toEdit.TuristickiStatus = Turizam;

                        _toEdit.Opis = _opis;
                        _toEdit.DatumOtkrivanja = DatumOtkrivanja;

                        _toEdit.Unesco = UnescoChecked ;
                        _toEdit.Naselje = NaseljeChecked;

                        _toEdit.Arheo = AreheoChecked;
                        _toEdit.IkonicaPath = ImagePath;
                        _toEdit.Tip = Spomenika;
                        //promenio tip spomenika nakaci novi listener
                        
                        //  MessageBox.Show("Uspesno ste izmenili spomenik.", "Izmenjen spomenik.",
                        //MessageBoxButton.OK, MessageBoxImage.Asterisk);

                    }
                    else
                    {
                        Spomenik newSpomenik = new Spomenik(_oznaka, _ime, _opis, _era, _turizam, _imagePath, unseco, naselje, arheo, _prihod.ToString(),Kalendar.SelectedDate.Value, _tipSpomenika);
                        foreach (var item in selectedItems)
                        {
                            newSpomenik.Etikete.Add((Etiketa)item);
                        }
                        newSpomenik.Tip = _tipSpomenika;
                        if (ImagePath.Equals(@"resources\NoImg300x225.jpg"))
                        {
                            newSpomenik.SlikaTip = true;
                            newSpomenik.IkonicaPath = _tipSpomenika.IkonicaPath;
                        }

                        Main.GetInstance().GetSpomenikLista.Add(newSpomenik);
                        // Console.WriteLine(Main.GetInstance().GetSpomenikLista.Count);
                        // MessageBox.Show("Uspesno ste dodali novi spomenika.", "Dodat novi spomenik.",
                        // MessageBoxButton.OK, MessageBoxImage.Asterisk);
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


        private void ButtonNoviTip_OnClick(object sender, RoutedEventArgs e)
        {
            NewTip tipDialog = new NewTip(null);
            tipDialog.Show();
        }

        private void ButtonNovaEtiketa_OnClick(object sender, RoutedEventArgs e)
        {
            NewEtiketa etiketaDialog = new NewEtiketa(null);
            etiketaDialog.ShowDialog();
        }
        private void Accept_OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void Escape_OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void HelpCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (Application.Current != null)
            {

                IInputElement focusedControl = FocusManager.GetFocusedElement(this);

                if (focusedControl is DependencyObject)
                {
                    string str = HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                    HelpProvider.ShowHelp(str, this);
                }
                if (focusedControl == null)
                {
                    string str = HelpProvider.GetHelpKey(this);
                    HelpProvider.ShowHelp(str, this);
                }
            }
        }

        private void EtiketaBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EtiketaBox.SelectedItems.Count == 0)
            {
                ErrorEtiketa.Visibility = Visibility.Visible;
                EtiketaBox.BorderBrush = Brushes.Red;
                EtiketaBox.BorderThickness = new Thickness(2, 2, 2, 2); 
            }
            else
            {
                ErrorEtiketa.Visibility = Visibility.Collapsed;
                EtiketaBox.BorderBrush = Brushes.Gray;
                EtiketaBox.BorderThickness = new Thickness(1); 
            }
        }

        private void TipBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TipBox.SelectedIndex == -1)
            {
                ErrorTip.Visibility = Visibility.Visible;
            }
            else
            {
                ErrorTip.Visibility = Visibility.Collapsed;
            }

           
        }

    }
}
