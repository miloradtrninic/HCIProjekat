﻿using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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
            viewSpomenika.Filter += o =>
            {
                Spomenik spomenik = o as Spomenik;
                bool filterTip = TipoviFilter.SelectedItem != null;
                bool filterEtiketa = EtiketeFilter.SelectedItem != null;

                if (filterTip && !filterEtiketa)
                {
                    return spomenik != null &&
                           spomenik.Tip.Oznaka.Equals(((TipSpomenika) TipoviFilter.SelectedItem).Oznaka);
                }
                if (!filterTip && filterEtiketa)
                {
                    return spomenik != null &&
                           spomenik.Etikete.Contains((Etiketa) EtiketeFilter.SelectedItem);
                }
                if (filterTip && filterEtiketa)
                {
                    return spomenik != null && spomenik.Etikete.Contains((Etiketa) EtiketeFilter.SelectedItem) &&
                           spomenik.Tip.Oznaka.Equals(((TipSpomenika) TipoviFilter.SelectedItem).Oznaka);
                }

                return false;
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
