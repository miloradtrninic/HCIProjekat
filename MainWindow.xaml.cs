using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HCIProjekat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Point startPoint;
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
        private void List_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
            startPoint = e.GetPosition(null);
        }

        private void List_MouseMove(object sender, MouseEventArgs e)
        {
            if (startPoint.X != 0 && startPoint.X != 0)
            {
                Point mousePos = e.GetPosition(null);
                Vector diff = startPoint - mousePos;

                if (e.LeftButton == MouseButtonState.Pressed &&
                    Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                    Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance)
                {
                    ListView listView = sender as ListView;
                    if (listView != null)
                    {
                        ListViewItem listViewItem = FindAnchestor<ListViewItem>((DependencyObject) e.OriginalSource);
                        if (listViewItem != null)
                        {
                            Spomenik spomenik =
                                (Spomenik) listView.ItemContainerGenerator.ItemFromContainer(listViewItem);

                            DataObject dragData = new DataObject("myFormat", spomenik);
                            DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
                        }
                    }
                }
            }
        }


        private static T FindAnchestor<T>(DependencyObject current)
        where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        private void DropMapa_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") ||
                sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }
        private void DropMapa_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat"))
            {
                Spomenik spomenik = e.Data.GetData("myFormat") as Spomenik;
                /*
                 * TODO PRIPREMI STACK PANEL TAKO DA SE U NJEGA MOZE DODATI ELEMENT
                ListView listView = sender as ListView;
                listView.Items.Add(contact);*/
                StackPanel stackMapa = sender as StackPanel;
                Image slikaImage = new Image();
                
                Uri putanjaUri = new Uri(spomenik.IkonicaPath, UriKind.Absolute);
                slikaImage.Source = new BitmapImage(putanjaUri);
                slikaImage.Width = 50;
                slikaImage.Height = 50;
                TextBlock textIme = new TextBlock();
                textIme.Text = spomenik.Ime;
                stackMapa.Children.Add(slikaImage);
                stackMapa.Children.Add(textIme);

            }
        }


        private void SpomeniciLista_OnClick(object sender, RoutedEventArgs e)
        {
            SpomeniciTabela tabela = new SpomeniciTabela();
            tabela.ShowDialog();
        }
        private void TipoviLista_OnClick(object sender, RoutedEventArgs e)
        {
            TipoviTabela tabela = new TipoviTabela();
            tabela.ShowDialog();
        }
        private void EtiketeLista_OnClick(object sender, RoutedEventArgs e)
        {
            EtiketeTabela tabela = new EtiketeTabela();
            tabela.ShowDialog();
        }
    }
} 
