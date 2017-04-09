using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace HCIProjekat
{
    /// <summary>
    /// Interaction logic for TipoviTabela.xaml
    /// </summary>
    public partial class TipoviTabela : Window, INotifyPropertyChanged
    {

        private ICollectionView _tipoviView;
        private string _searchString;
        private bool enableSearch;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        public TipoviTabela()
        {
            InitializeComponent();
            _searchString = "";
            enableSearch = false;
            this.DataContext = this;
            
            //view 2 nad getspomeniklista.  CollectionViewSource.Default vracao uvek isti view i menjao se na nivou celog programa
            _tipoviView = new CollectionViewSource { Source = Main.GetInstance().TipspomenikaLista }.View;
            _tipoviView.Filter = Filter;

        }

        private bool Filter(object o)
        {
            var obj = o as TipSpomenika;
            if (obj != null)
            {
                if (enableSearch)
                {
                    if (obj.Oznaka.Equals(_searchString))
                    {
                        Console.WriteLine(_searchString);
                        return true;
                    }
                    else
                        return false;
                }
                else
                {
                    return true;
                }
            }
            return false;
        }

       /* private void SearchFilter(object o, FilterEventArgs e)
        {
            var obj = e.Item as TipSpomenika;
            if (obj != null)
            {
                if (enableSearch)
                {
                    if (obj.Oznaka.Equals(Pretraga.Text))
                        e.Accepted = true;
                    else
                        e.Accepted = false;
                }
                else
                {
                    e.Accepted = true;
                }
            }
        }
        */
        public ICollectionView TipoviView
        {
            get { return _tipoviView; }
            set { _tipoviView = value; }
        }

        public string SearchString
        {
            get { return _searchString; }
            set
            {
                if (!_searchString.Equals(value))
                {

                    _searchString = value;
                    OnPropertyChanged("SearchString");
                }
            }
        }


        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (SearchString.Equals(""))
            {
                enableSearch = false;
            }
            else
            {
                enableSearch = true;
            }
            _tipoviView.Refresh();
        }

        
    }
}
