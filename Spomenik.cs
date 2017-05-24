using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace HCIProjekat
{
    [Serializable]  
    public class Spomenik :  INotifyPropertyChanged
    {

        private string oznaka;
        private string ime;
        private string opis; 
        private string ikonicaPath;
        private bool unesco;
        private bool naselje;
        private bool arheo;
        private string godisnjiPrihod;     
        private DateTime datumOtkrivanja;
        private bool slikaTip;
        private TipSpomenika tip;
       
        private ObservableCollection<Etiketa> etikete;

        public string eraPorekla;
        public string turistickiStatus;

        public DateTime DatumOtkrivanja
        {
            get { return datumOtkrivanja; }
            set
            {
                datumOtkrivanja = value;
                Main.GetInstance().Saved = false;
                OnPropertyChanged("DatumOtkrivanja");
            }
        }
        public string Opis
        {
            get { return opis; }
            set
            {
                opis = value;
                Main.GetInstance().Saved = false;
                OnPropertyChanged("Opis");
            }
        }
        public string EraPorekla
        {
            get { return eraPorekla; }
            set
            {
                eraPorekla = value;
                Main.GetInstance().Saved = false;
                OnPropertyChanged("EraPorekla");
            }
        }
        public string Oznaka
        {
            get { return oznaka; }
            set
            {
                oznaka = value;
                Main.GetInstance().Saved = false;
                OnPropertyChanged("Oznaka");
            }
        }

        public string GodisnjiPrihod
        {
            get { return godisnjiPrihod; }
            set
            {
                godisnjiPrihod = value;
                Main.GetInstance().Saved = false;
                OnPropertyChanged("GodisnjiPrihod");
            }
        }

        public string IkonicaPath
        {
            get { return ikonicaPath; }
            set
            {
                ikonicaPath = value;
                Main.GetInstance().Saved = false;
                OnPropertyChanged("IkonicaPath");
            }
        }

        public bool Naselje
        {
            get { return naselje; }
            set
            {
                naselje = value;
                Main.GetInstance().Saved = false;
                OnPropertyChanged("Naselje");
            }
        }
        public string TuristickiStatus
        {
            get { return turistickiStatus; }
            set
            {
                turistickiStatus = value;
                Main.GetInstance().Saved = false;
                OnPropertyChanged("TuristickiStatus");
            }
        }
        public string Ime
        {
            get { return ime; }
            set
            {
                ime = value;
                Main.GetInstance().Saved = false;
                OnPropertyChanged("Ime");
            }
        }
        public bool Unesco
        {
            get { return unesco; }
            set
            {
                unesco = value;
                Main.GetInstance().Saved = false;
                OnPropertyChanged("Unesco");
            }
        }

        public TipSpomenika Tip
        {
            get { return tip; }
            set
            {
                tip = value;
                Main.GetInstance().Saved = false;
                OnPropertyChanged("Tip");
            }
        }

        public ObservableCollection<Etiketa> Etikete
        {
            get { return etikete; }
            set
            {
                etikete = value;
                Main.GetInstance().Saved = false;
                OnPropertyChanged("Etikete");
            }
        }

        public bool Arheo
        {
            get { return arheo; }
            set
            {
                arheo = value;
                Main.GetInstance().Saved = false;
                OnPropertyChanged("Arheo");
            }
        }

        public bool SlikaTip
        {
            get { return slikaTip; }
            set
            {
                slikaTip = value;
                Main.GetInstance().Saved = false;
                OnPropertyChanged("SlikaTip");
            }
        }

        public Spomenik(string oznaka, string ime, string opis, string eraPorekla, string turistickiStatus,
            string ikonicaPath, bool unesco, bool naselje, bool arheo, string godisnjiPrihod, DateTime datumOtkrivanja, TipSpomenika tipSpomenika)
        {
            this.oznaka = oznaka;
            this.ime = ime;
            this.opis = opis;
            this.eraPorekla = eraPorekla;
            this.turistickiStatus = turistickiStatus;
            this.arheo = arheo;
            this.ikonicaPath = ikonicaPath;
            this.unesco = unesco;
            this.tip = tipSpomenika;
            this.naselje = naselje;
            this.godisnjiPrihod = godisnjiPrihod;
            this.datumOtkrivanja = datumOtkrivanja;
            Etikete = new ObservableCollection<Etiketa>();

        }

        public Spomenik()
        {
            this.slikaTip = false;
            this.oznaka = "prazno";
            this.ime = "prazno";
            this.opis = "prazno";
            this.arheo = true;
            this.ikonicaPath = "prazno";
            this.unesco = true;
            this.naselje = true;
            this.godisnjiPrihod = "prazno";
            Etikete = new ObservableCollection<Etiketa>();
          
        }

        public void DodajEtiketu(Etiketa novaEtiketa)
        {
            this.etikete.Add(novaEtiketa);
        }

        public override string ToString()
        {
            return Ime;
        }

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
