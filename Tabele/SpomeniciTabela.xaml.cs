using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace HCIProjekat
{
    /// <summary>
    /// Interaction logic for SpomeniciTabela.xaml
    /// </summary>
    public partial class SpomeniciTabela : Page,INotifyPropertyChanged
    {
        private ICollectionView _listView;
        private bool _searchEnable;
        private string _searchString;
        public SpomeniciTabela()
        {
            InitializeComponent();
            _searchEnable = false;
            _listView = new CollectionViewSource { Source = Main.GetInstance().GetSpomenikLista }.View;
            DataContext = this;
            _listView.Filter += Filter;
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public ICollectionView View
        {
            get { return _listView; }
            set { _listView = value; }
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

        private bool Filter(object o)
        {
            Spomenik spomenik = o as Spomenik;
            if (_searchEnable)
            {
                if (spomenik != null && spomenik.Oznaka.StartsWith(Pretraga.Text.Trim()))
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

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (Pretraga.Text.Trim().Equals(""))
            {
                _searchEnable = false;
            }
            else
            {
                _searchEnable = true;
            }
            _listView.Refresh();
        }
        private void Pretraga_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            _searchEnable = true;
            _listView.Refresh();
        }
   
    }
}
