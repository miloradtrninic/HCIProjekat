using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace HCIProjekat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
        }
       

        private void Button_NoviSpomenik(object sender, RoutedEventArgs e)
        {
            NewSpomenik spomenikDialog = new NewSpomenik(null);
            spomenikDialog.ShowDialog();
        }

        private void Button_NovaEtiketa(object sender, RoutedEventArgs e)
        {
            NewEtiketa etiketaDialog = new NewEtiketa(null);
            etiketaDialog.ShowDialog();
        }


        private void Button_NoviTip(object sender, RoutedEventArgs e)
        {
           NewTip tipDialog = new NewTip(null);
           tipDialog.ShowDialog();
        }

        private void SpomeniciLista_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var lista = sender as ListView;
            if (lista == null)
            {
                return;

            }

            var spomenik = lista.SelectedItem as Spomenik;
            if (spomenik == null)
            {
                return;
            }

            NewSpomenik editDialog = new NewSpomenik(spomenik);
            editDialog.ShowDialog();
        }

        private void TipLista_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var lista = sender as ListView;
            if (lista == null)
            {
                return;

            }

            var tip = lista.SelectedItem as TipSpomenika;
            if (tip == null)
            {
                return;
            }

            NewTip editDialog = new NewTip(tip);
            editDialog.ShowDialog();
        }

        private void EtiketaLista_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var lista = sender as ListView;
            if (lista == null)
            {
                return;

            }
            
            var etiketa = lista.SelectedItem as Etiketa;
            if (etiketa == null)
            {
                return;
            }
           
            NewEtiketa editDialog = new NewEtiketa(etiketa);
            editDialog.ShowDialog();

        }
    }
} 
