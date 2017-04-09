using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace HCIProjekat
{
    /// <summary>
    /// Interaction logic for SpomeniciTabela.xaml
    /// </summary>
    public partial class SpomeniciTabela : Window,INotifyPropertyChanged
    {
        private ICollectionView _listView;
        private bool _searchEnable;
        private string _searchString;
        public SpomeniciTabela()
        {
            InitializeComponent();
            _searchEnable = false;
            //view 2 nad getspomeniklista.  CollectionViewSource.Default vracao uvek isti view i menjao se na nivou celog programa
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
                if (spomenik != null && spomenik.Oznaka.Equals(_searchString))
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
            if (SearchString.Equals(""))
            {
                _searchEnable = false;
            }
            else
            {
                _searchEnable = true;
            }
            _listView.Refresh();
        }

        
    }
}
