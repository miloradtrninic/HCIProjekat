﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Microsoft.Win32;

namespace HCIProjekat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Point startPoint;
        private ICollectionView _spomeniciView;
        private ICollectionView _etiketeView;
        private ICollectionView _tipoviView;
        private ICollectionView _spomeniciMapaView;

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        public MainWindow()
        { 
            
            _spomeniciView = new CollectionViewSource{Source = Main.GetInstance().GetSpomenikLista}.View;
            _etiketeView = new CollectionViewSource { Source = Main.GetInstance().EtiketaLista }.View;
            _tipoviView = new CollectionViewSource { Source = Main.GetInstance().TipspomenikaLista }.View;
            _spomeniciMapaView = new CollectionViewSource { Source = Main.GetInstance().SpomenikMapas }.View;

            InitializeComponent();
            DataContext = this;
           
        }

        


        public ICollectionView SpomeniciView
        {
            get { return _spomeniciView; }
            set
            {
                _spomeniciView = value;
                OnPropertyChanged("SpomeniciView");
            }
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

        public ICollectionView TipoviView
        {
            get { return _tipoviView; }
            set
            {
                _tipoviView = value;
                OnPropertyChanged("TipoviView");
            }
        }

        public ICollectionView SpomeniciMapaView
        {
            get { return _spomeniciMapaView; }
            set
            {
                _spomeniciMapaView = value;
                OnPropertyChanged("SpomeniciMapaView");
            }
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

        private void OnMap_Preview_MouseLeft(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(MapCanvas);
        }


        private void ListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }


        private void OnMap_Mouse_Move(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;
            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                 Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                ItemsControl itemsControl = sender as ItemsControl;
                SpomenikMapa spomenikMapa = SearchPosition(startPoint);
                if (spomenikMapa != null)
                {

                    // Initialize the drag & drop operation
                    DataObject dragData = new DataObject("myFormat", spomenikMapa.SpomenikNaMapi);
                    DragDrop.DoDragDrop(itemsControl, dragData, DragDropEffects.Move);
                    // OBRISATI DA SE NE BI DUPLIRALI
                    Main.GetInstance().SpomenikMapas.Remove(spomenikMapa);
                }
            }

        }

        private SpomenikMapa SearchPosition(Point point)
        {
            foreach (SpomenikMapa spomenikMapa in Main.GetInstance().SpomenikMapas)
            {

                if (Math.Abs(point.X - spomenikMapa.KoordinatePoint.X) <= 90 && Math.Abs(point.Y - spomenikMapa.KoordinatePoint.Y) <= 90)
                {
                    return spomenikMapa;
                }
            }
            return null;
        }



        private void ListView_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                // Get the dragged ListViewItem
                ListView listView = sender as ListView;
                ListViewItem listViewItem =
                    FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);

                // Find the data behind the ListViewItem
                if (listView != null)
                {
                    if (listViewItem == null)
                    {
                        return;
                    }
                    Spomenik spomenik = listView.ItemContainerGenerator.
                        ItemFromContainer(listViewItem) as Spomenik;


                    if (spomenik == null)
                        return;

                    // Initialize the drag & drop operation
                    DataObject dragData = new DataObject("myFormat", spomenik);
                    
                    foreach (var trenutni in Main.GetInstance().SpomenikMapas)
                    {
                       if (trenutni.SpomenikNaMapi.Oznaka.Equals(spomenik.Oznaka))
                       {
                           DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.None);
                           return;
                       }
                    }


                    DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Copy);
                }
            }
        }

        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
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
            if (!e.Data.GetDataPresent("myFormat") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }
        private void DropMapa_Drop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("myFormat") /*&& e.Effects != DragDropEffects.None*/)
            {
                Spomenik spomenik = e.Data.GetData("myFormat") as Spomenik;
                Point currentPoint = new Point(e.GetPosition(MapCanvas).X, e.GetPosition(MapCanvas).Y);
                SpomenikMapa mapaSpom = new SpomenikMapa(spomenik, currentPoint);
                Main.GetInstance().SpomenikMapas.Add(mapaSpom);
                //SpomeniciMapaView.Refresh();
            }
        }

        private void MapCanvas_OnDragOver(object sender, DragEventArgs e)
        {
            SpomenikMapa okolniSpomenik = SearchPosition(e.GetPosition(MapCanvas));
            if (okolniSpomenik != null)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void ButtonTabele_OnClick(object sender, RoutedEventArgs e)
        {
            Tabele tabele = new Tabele();
            tabele.Show();
        }

        private void MenuItemOpen_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            string putanja;
            
            fileDialog.Filter = "Spomenici (*.mon) | *.mon";
            fileDialog.Multiselect = false;
            
            fileDialog.CheckFileExists = true;
            fileDialog.CheckPathExists = true;

            var result = fileDialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                putanja = fileDialog.FileName;
                Main.GetInstance().Load(putanja);
            }
            //mora da se refresuje glavni prozor zbog bindinga na liste u centru
            _spomeniciView.Refresh();
            EtiketeView = new CollectionViewSource {Source = Main.GetInstance().EtiketaLista}.View;
            EtiketeView.Refresh();
            TipoviView = new CollectionViewSource {Source = Main.GetInstance().TipspomenikaLista}.View;
            TipoviView.Refresh();
            SpomeniciMapaView = new CollectionViewSource { Source = Main.GetInstance().SpomenikMapas }.View;
            SpomeniciMapaView.Refresh();
            SpomeniciView = new CollectionViewSource { Source = Main.GetInstance().GetSpomenikLista }.View;
            SpomeniciView.Refresh();
            // this.DataContext = null;
            //this.DataContext = new MainWindow();
            /* MainWindow main = new MainWindow();
             main.Show();
             this.Close();*/


        }
        private void MenuItemSave_OnClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            string putanja;
            
            fileDialog.Filter = "Spomenici (*.mon) | *.mon";
            fileDialog.Multiselect = false;

            fileDialog.CheckFileExists = false;
            fileDialog.CheckPathExists = false;

            var result = fileDialog.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                putanja = fileDialog.FileName;
                Main.GetInstance().Snimi(putanja);
            }
            

        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
        }


        private void NewEtiketa_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void NewTip_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
       
        private void NewSpomenik_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }


        private void Open_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }


        
    }
} 
