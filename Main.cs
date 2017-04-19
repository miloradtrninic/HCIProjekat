using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class Main
    {
        private ObservableCollection<Spomenik> spomeniciLista;
        private ObservableCollection<TipSpomenika> _tipspomenikaLista;

        private ObservableCollection<Etiketa> _etiketaLista;
        private ObservableCollection<SpomenikMapa> _spomenikMapas;

       
        private static Main instance = null;

        private Main()
        {
            spomeniciLista = new ObservableCollection<Spomenik>();
            _tipspomenikaLista = new ObservableCollection<TipSpomenika>();
            _etiketaLista = new ObservableCollection<Etiketa>();
            _spomenikMapas = new ObservableCollection<SpomenikMapa>();
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
        }
        public ObservableCollection<Etiketa> EtiketaLista
        {
            get { return _etiketaLista; }
        }

       


        public ObservableCollection<Spomenik> GetSpomenikLista
        {
            get { return spomeniciLista; }
        }

        public ObservableCollection<SpomenikMapa> SpomenikMapas
        {
            get { return _spomenikMapas; }
            set { _spomenikMapas = value; }
        }

        public void Snimi(string filePath)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, instance);
            stream.Close();  
        }

        public bool Load(string filePath)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.None);

            instance = formatter.Deserialize(stream) as Main;
            if (instance != null)
            {
                return true;
            }
           
            return true;
            
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
