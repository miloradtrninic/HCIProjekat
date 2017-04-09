using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace HCIProjekat
{
    /// <summary>
    /// Interaction logic for NewEtiketa.xaml
    /// </summary>
    /// 
    /// TODO ISPITATI PRI UNOSU NOVOG DA LI VEC POSTOJI U LISTI SA ISTOM OZNAKOM
    public partial class NewEtiketa : Window, INotifyPropertyChanged
    {
        private Etiketa trenutnaEtiketa;
        private string _oznaka;
        private string _opis;
        private Color? _boja;
        
        public NewEtiketa(Etiketa trenutnaEtiketa)
        {
            
            if (trenutnaEtiketa == null)
            {
                trenutnaEtiketa = new Etiketa();
                _oznaka = "";
                _opis = "";
                _boja = null;
            }
            else
            {
                this.trenutnaEtiketa = trenutnaEtiketa;
                _oznaka = trenutnaEtiketa.Oznaka;
                _opis = trenutnaEtiketa.Opis;
                _boja = trenutnaEtiketa.Boja;
            }
            
            InitializeComponent();
            this.DataContext = this;

        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
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

        public string Opis
        {
            get { return _opis; }
            set { _opis = value; }
        }

        public Color? Boja
        {
            get { return _boja; }
            set { _boja = value; }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Button okButton = (Button) sender;
            try
            {
                OznakaBox.GetBindingExpression(TextBox.TextProperty).UpdateSource();

                if (ColorBox.SelectedColor != null && !Validation.GetHasError(OznakaBox))
                {
                    Etiketa novaEtiketa = new Etiketa(OznakaBox.Text, ColorBox.SelectedColor.Value, OpisBox.Text);
                    if (Main.GetInstance().HasEtiketa(novaEtiketa))
                    {
                        //replace nema?
                        Main.GetInstance().EtiketaLista.Single(x => x.Oznaka.Equals(novaEtiketa.Oznaka)).Opis = novaEtiketa.Opis;
                        Main.GetInstance().EtiketaLista.Single(x => x.Oznaka.Equals(novaEtiketa.Oznaka)).Boja = novaEtiketa.Boja;

                        //MessageBox.Show("Uspesno ste izmenili etiketu.", "Izmenjena etiketa.", MessageBoxButton.OK,
                       // MessageBoxImage.Asterisk);
                    }
                    else
                    {
                        Main.GetInstance().EtiketaLista.Add(novaEtiketa);
                       // MessageBox.Show("Uspesno ste snimili novu etiketu.", "Dodata nova etiketa.", MessageBoxButton.OK,
                       // MessageBoxImage.Asterisk);
                    }
                    
                    NovaEtiketaDialog.Close();

                }
                else
                {
                    MessageBox.Show("Molimo Vas da popunite polja oznacena sa *.", "Nepotpun unos.",
                        MessageBoxButton.OK, MessageBoxImage.Warning);

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show("Molimo Vas kontaktirajte administratora.", "Sistemska greska!",
                        MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO DA LI STE SIGURNI MESSAGE BOX
            NovaEtiketaDialog.Close();
        }


        
    }
}
