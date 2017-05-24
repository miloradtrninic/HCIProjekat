using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace HCIProjekat
{
    [Serializable]
    public class Main : INotifyPropertyChanged
    {
        private ObservableCollection<Spomenik> spomeniciLista;
        private ObservableCollection<TipSpomenika> _tipspomenikaLista;

        private ObservableCollection<Etiketa> _etiketaLista;
        private ObservableCollection<SpomenikMapa> _spomenikMapas;

        private bool _saved = false;
        private string _savepath = null;

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        
        private static Main instance = null;

        private Main()
        {
            spomeniciLista = new ObservableCollection<Spomenik>();
            spomeniciLista.CollectionChanged += list_changed;
            _tipspomenikaLista = new ObservableCollection<TipSpomenika>();
            _tipspomenikaLista.CollectionChanged += list_changed;
            _etiketaLista = new ObservableCollection<Etiketa>();
            _etiketaLista.CollectionChanged += list_changed;
            _spomenikMapas = new ObservableCollection<SpomenikMapa>();
            _spomenikMapas.CollectionChanged += list_changed;

        }
        public static Main GetInstance()
        {
            if (instance == null)
            {
                instance = new Main();
                return instance;
            }
            else
            {
                return instance;
            }
        }

     

        public ObservableCollection<TipSpomenika> TipspomenikaLista
        {
            get { return _tipspomenikaLista; }
            set
            {
                _tipspomenikaLista = value;
                OnPropertyChanged("TipspomenikaLista");
                
            }
        }
        public ObservableCollection<Etiketa> EtiketaLista
        {
            get { return _etiketaLista; }
            set
            {
                _etiketaLista = value;
                OnPropertyChanged("EtiketaLista");
            }
        }

       


        public ObservableCollection<Spomenik> GetSpomenikLista
        {
            get { return spomeniciLista; }
            set
            {
                spomeniciLista = value;
                OnPropertyChanged("GetSpomenikLista");
            }
        }

        public ObservableCollection<SpomenikMapa> SpomenikMapas
        {
            get { return _spomenikMapas; }
            set
            {
                _spomenikMapas = value;
                OnPropertyChanged("SpomenikMapas");
            }
        }

        public bool Saved
        {
            get { return _saved; }
            set { _saved = value; }
        }

        public string Savepath
        {
            get { return _savepath; }
            set { _savepath = value; }
        }

        public void list_changed(object sender, NotifyCollectionChangedEventArgs eventArgs)
        {
            if (sender != null)
            {
                Saved = false;
            }
        }

        public void Snimi(string filePath)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
            Savepath = filePath;
            Saved = true;
            formatter.Serialize(stream, instance);
            stream.Close();
            
         

        }

        public bool Load(string filePath)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None);
            var deserialized = formatter.Deserialize(stream) as Main;
            instance.GetSpomenikLista = deserialized.GetSpomenikLista;
            instance.GetSpomenikLista.CollectionChanged += list_changed;

            instance.EtiketaLista = deserialized.EtiketaLista;
            instance.EtiketaLista.CollectionChanged += list_changed;

            instance.SpomenikMapas = deserialized.SpomenikMapas;
            instance.SpomenikMapas.CollectionChanged += list_changed;

            instance.TipspomenikaLista = deserialized.TipspomenikaLista;
            instance.TipspomenikaLista.CollectionChanged += list_changed;
            instance.Saved = deserialized.Saved;
            instance.Savepath = deserialized.Savepath;
            if (instance != null)
            {
                Saved = true;
                return true;

            }
            return false;
        }

        public bool HasSpomenik(Spomenik spomenik)
        {
            foreach (var spomenikTrenutni in spomeniciLista)
            {
                if (spomenikTrenutni.Oznaka.Equals(spomenik.Oznaka))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasSpomenik(string oznaka)
        {
            foreach (var spomenikTrenutni in spomeniciLista)
            {
                if (spomenikTrenutni.Oznaka.Equals(oznaka))
                {
                    return true;
                }
            }
            return false;
        }
        public bool HasTipSpomenika(TipSpomenika tip)
        {
            foreach (var tipTrenutni in _tipspomenikaLista)
            {
                if (tipTrenutni.Oznaka.Equals(tip.Oznaka))
                {
                    return true;
                }
            }
            return false;
        }
        public bool HasTipSpomenika(string oznaka)
        {
            foreach (var tipTrenutni in _tipspomenikaLista)
            {
                if (tipTrenutni.Oznaka.Equals(oznaka))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasEtiketa(Etiketa etiketa)
        {
            foreach (var etiketaTrenutni in _etiketaLista)
            {
                if (etiketaTrenutni.Oznaka.Equals(etiketa.Oznaka))
                {
                    return true;
                }
            }
            return false;
        }

    }

    
}
