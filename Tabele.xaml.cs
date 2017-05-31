using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace HCIProjekat
{
    /// <summary>
    /// Interaction logic for Tabele.xaml
    /// </summary>
    public partial class Tabele : Window
    {
        private ICollectionView _tipoView;
        private ICollectionView _etiketeView;
        private bool pressed;
        public Tabele()
        {
            _tipoView = new CollectionViewSource {Source = Main.GetInstance().TipspomenikaLista}.View;
            _etiketeView = new CollectionViewSource { Source = Main.GetInstance().EtiketaLista }.View;
            
            InitializeComponent();
            EtiketeFilter.SelectedIndex = -1;
        
            TipoviFilter.SelectedIndex = -1;
            this.DataContext = this;
           
            
        }
        public ICollectionView TipoView
        {
            get { return _tipoView; }
            set { _tipoView = value; }
        }

        public ICollectionView EtiketeView
        {
            get { return _etiketeView; }
            set { _etiketeView = value; }
        }

        private void ButtonNewSpomenik_OnClick(object sender, RoutedEventArgs e)
        {
            NewSpomenik spomenikDialog = new NewSpomenik(null);
            spomenikDialog.ShowDialog();
        }
        private void ButtonIzmeniSpomenik_OnClick(object sender, RoutedEventArgs e)
        {
            var contentTabele = (SpomeniciTabela)SpomeniciFrame.Content;
            DataGrid tabelaSpomenika = (DataGrid)contentTabele.FindName("TabelaSpomenika");
            if (tabelaSpomenika != null && (tabelaSpomenika.SelectedItem != null && tabelaSpomenika.SelectedItem.GetType() == typeof(Spomenik)))
            {
                NewSpomenik newSpomenikDialog = new NewSpomenik((Spomenik)tabelaSpomenika.SelectedItem);
                newSpomenikDialog.ShowDialog();
            }
            else
            {
                MessageBox.Show("Molimo Vas odaberite spomenik koji želite da izmenite!", "Izmena spomenika", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }
        private void ButtonObrisiSpomenik_OnClick(object sender, RoutedEventArgs e)
        {
            var contentTabele = (SpomeniciTabela)SpomeniciFrame.Content;
            DataGrid tabelaSpomenika = (DataGrid)contentTabele.FindName("TabelaSpomenika");
            if (tabelaSpomenika != null && (tabelaSpomenika.SelectedItem != null && tabelaSpomenika.SelectedItem.GetType() == typeof(Spomenik)))
            {
                Main.GetInstance().GetSpomenikLista.Remove((Spomenik)tabelaSpomenika.SelectedItem);
            }
            else
            {
                MessageBox.Show("Molimo Vas odaberite etiketu koju želite da obrišete!", "Brisanje spomenika", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
        private void Filtriraj_Spomenike_OnClick(object sender, RoutedEventArgs e)
        {
            var contentTabele = (SpomeniciTabela)SpomeniciFrame.Content;
            ICollectionView viewSpomenika = contentTabele.View;
            viewSpomenika.Filter += Filter;
            viewSpomenika.Refresh();
        }
        public bool Filter(object o)
        {
            Spomenik spomenik = o as Spomenik;
            bool filterEtiketa = EtiketeEnabled.IsChecked != null && EtiketeEnabled.IsChecked.Value;
            bool filterTip = TipoviEnabled.IsChecked != null && TipoviEnabled.IsChecked.Value;
            var contentTabele = (SpomeniciTabela)SpomeniciFrame.Content;
            if (filterTip && !filterEtiketa)
            {
                var tipSpomenika = TipoviFilter.SelectedItem as TipSpomenika;
                return tipSpomenika != null && spomenik != null && spomenik.Tip.Oznaka.Equals(tipSpomenika.Oznaka) && contentTabele.Filter(o);
            }
            if (!filterTip && filterEtiketa)
            {
                var etiketeFilterSelectedItem = (Etiketa)EtiketeFilter.SelectedItem;
                return etiketeFilterSelectedItem != null && spomenik != null && spomenik.Etikete.Contains(etiketeFilterSelectedItem) && contentTabele.Filter(o);
            }
            if (filterTip && filterEtiketa)
            {
                var etiketeFilterSelectedItem = (Etiketa)EtiketeFilter.SelectedItem;
                var tipoviFilterSelectedItem = (TipSpomenika)TipoviFilter.SelectedItem;
                return etiketeFilterSelectedItem != null && tipoviFilterSelectedItem != null && spomenik != null && spomenik.Etikete.Contains(etiketeFilterSelectedItem) &&
                                                                                                  spomenik.Tip.Oznaka.Equals(tipoviFilterSelectedItem.Oznaka) && contentTabele.Filter(o);
            }
            return contentTabele.Filter(o);
        }


        private void DeFiltriraj_Spomenike_OnClick(object sender, RoutedEventArgs e)
        {
            var contentTabele = (SpomeniciTabela)SpomeniciFrame.Content;
            ICollectionView viewSpomenika = contentTabele.View;
            viewSpomenika.Filter += o => contentTabele.Filter(o);
            viewSpomenika.Refresh();
        }
        private void ButtonNewTip_OnClick(object sender, RoutedEventArgs e)
        {
            NewTip newTipDialog = new NewTip(null);
            newTipDialog.ShowDialog();
        }
        private void ButtonIzmeniTip_OnClick(object sender, RoutedEventArgs e)
        {
            var contentTabele = (TipoviTabela)TipFrame.Content;
            DataGrid tabelaTipova = (DataGrid)contentTabele.FindName("TabelaTipova");
            if (tabelaTipova != null && (tabelaTipova.SelectedItem != null && tabelaTipova.SelectedItem.GetType() == typeof(TipSpomenika)))
            {
                NewTip newTip = new NewTip((TipSpomenika)tabelaTipova.SelectedItem);
                newTip.ShowDialog();
            }
            else
            {
                MessageBox.Show("Molimo Vas odaberite etiketu koju želite da izmenite!", "Izmena tipa", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        private void ButtonObrisiTip_OnClick(object sender, RoutedEventArgs e)
        {
            var contentTabele = (TipoviTabela)TipFrame.Content;
            DataGrid tabelaTipova = (DataGrid)contentTabele.FindName("TabelaTipova");
            if (tabelaTipova != null && (tabelaTipova.SelectedItem != null && tabelaTipova.SelectedItem.GetType() == typeof(TipSpomenika)))
            {
                foreach (var spomenik in Main.GetInstance().GetSpomenikLista)
                {
                    if (spomenik.Tip.Equals((TipSpomenika) tabelaTipova.SelectedItem))
                    {
                        MessageBox.Show("Odabrani tip se koriti!", "Brisanje tipa", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }
                Main.GetInstance().TipspomenikaLista.Remove((TipSpomenika)tabelaTipova.SelectedItem);
            }
            else
            {
                MessageBox.Show("Molimo Vas odaberite etiketu koju želite da obrišete!", "Brisanje tipa", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ButtonNewEtiketa_OnClick(object sender, RoutedEventArgs e)
        {
            NewEtiketa newEtiketaDialog = new NewEtiketa(null);
            newEtiketaDialog.ShowDialog();
        }

        private void ButtonIzmeniEtiketu_OnClick(object sender, RoutedEventArgs e)
        {
            var contentTabele = (EtiketeTabela)EtiketaFrame.Content;
            DataGrid tabelaEtiketa = (DataGrid) contentTabele.FindName("TabelaEtiketa");
            if (tabelaEtiketa != null && (tabelaEtiketa.SelectedItem != null && tabelaEtiketa.SelectedItem.GetType() == typeof(Etiketa)))
            {
                NewEtiketa newEtiketaDialog = new NewEtiketa((Etiketa) tabelaEtiketa.SelectedItem);
                newEtiketaDialog.ShowDialog();
            }
            else
            {
                MessageBox.Show("Molimo Vas odaberite etiketu koju želite da izmenite!", "Izmena etikete",MessageBoxButton.OK,MessageBoxImage.Warning);
            }
        }

        private void ButtonObrisiEtiketu_OnClick(object sender, RoutedEventArgs e)
        {
            var contentTabele = (EtiketeTabela)EtiketaFrame.Content;
            DataGrid tabelaEtiketa = (DataGrid)contentTabele.FindName("TabelaEtiketa");
            if (tabelaEtiketa != null && (tabelaEtiketa.SelectedItem != null && tabelaEtiketa.SelectedItem.GetType() == typeof(Etiketa)))
            {
                foreach (var spomenik in Main.GetInstance().GetSpomenikLista)
                {
                    if (spomenik.Etikete.Contains((Etiketa)tabelaEtiketa.SelectedItem))
                    {
                        MessageBox.Show("Odabrana etiketa se koriti!", "Brisanje etikete", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }
                }
                Main.GetInstance().EtiketaLista.Remove((Etiketa) tabelaEtiketa.SelectedItem);
            }
            else
            {
                MessageBox.Show("Molimo Vas odaberite etiketu koju želite da obrišete!", "Brisanje etikete", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void HelpCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (Application.Current != null)
            {
               // IInputElement focusedControl = FocusManager.GetFocusedElement(this);
                TabItem ti = TabControl.SelectedItem as TabItem;
                if (ti is DependencyObject)
                {
                    string str = HelpProvider.GetHelpKey((DependencyObject)ti);
                    HelpProvider.ShowHelp(str, this);
                }
                if (ti == null)
                {
                    string str = HelpProvider.GetHelpKey(this);
                    HelpProvider.ShowHelp(str, this);
                }
            }
        }

    }
}
