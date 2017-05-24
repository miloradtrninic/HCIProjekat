using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace HCIProjekat
{
    /// <summary>
    /// Interaction logic for EtiketeLista.xaml
    /// </summary>
    /// 
    public partial class EtiketeTabela : Page, INotifyPropertyChanged
    {
        private ICollectionView _etiketeView;
        private bool _enableSearch;
        private string _searchString;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        public EtiketeTabela()
        {
            _etiketeView = new CollectionViewSource {Source = Main.GetInstance().EtiketaLista}.View;
            _etiketeView.Filter = Filter;
            _enableSearch = false;
            InitializeComponent();
            DataContext = this;

        }

        private bool Filter(object o)
        {
            Etiketa etiketa = o as Etiketa;
            if (_enableSearch)
            {
                if (etiketa != null && etiketa.Oznaka.StartsWith(Pretraga.Text))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        public ICollectionView EtiketeView
        {
            get { return _etiketeView; }
            set
            {
                _etiketeView = value;
                OnPropertyChanged("EtiketeView");
            }
        }

        public string SearchString
        {
            get { return _searchString; }
            set
            {
                _searchString = value;
                OnPropertyChanged("SearchString");
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (Pretraga.Text.Trim().Equals(""))
            {
                _enableSearch = false;
            }
            else
            {
                _enableSearch = true;
            }
            _etiketeView.Refresh();
        }
        private void Pretraga_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            _enableSearch = true;
            _etiketeView.Refresh();
            
        }
    }
}
