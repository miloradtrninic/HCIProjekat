using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for Tabele.xaml
    /// </summary>
    public partial class Tabele : Window
    {
        private ICollectionView _tipoView;
        private bool pressed;
        public Tabele()
        {
            _tipoView = new CollectionViewSource {Source = Main.GetInstance().TipspomenikaLista}.View;
            InitializeComponent();
            this.DataContext = this;
           
            
        }

        public ICollectionView TipoView
        {
            get { return _tipoView; }
            set { _tipoView = value; }
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
            viewSpomenika.Filter += o =>
            {
                Spomenik spomenik = o as Spomenik;
                return spomenik != null && spomenik.Tip.Oznaka.Equals(((TipSpomenika) TipoviFilter.SelectedItem).Oznaka);
            };
        }

        private void DeFiltriraj_Spomenike_OnClick(object sender, RoutedEventArgs e)
        {
            var contentTabele = (SpomeniciTabela)SpomeniciFrame.Content;
            ICollectionView viewSpomenika = contentTabele.View;
            viewSpomenika.Filter += o => { return true; };
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


    }
}
