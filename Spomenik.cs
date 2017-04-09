using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HCIProjekat
{
    public class Spomenik : INotifyCollectionChanged, INotifyPropertyChanged
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
        private TipSpomenika tip;
        private List<Etiketa> etikete;

        public string eraPorekla;
        public string turistickiStatus;

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public DateTime DatumOtkrivanja
        {
            get { return datumOtkrivanja; }
            set
            {
                datumOtkrivanja = value;
                OnPropertyChanged("DatumOtkrivanja");
            }
        }
        public string Opis
        {
            get { return opis; }
            set
            {
                opis = value;
                OnPropertyChanged("Opis");
            }
        }
        public string EraPorekla
        {
            get { return eraPorekla; }
            set
            {
                eraPorekla = value;
                OnPropertyChanged("EraPorekla");
            }
        }
        public string Oznaka
        {
            get { return oznaka; }
            set
            {
                oznaka = value;
                OnPropertyChanged("Oznaka");
            }
        }

        public string GodisnjiPrihod
        {
            get { return godisnjiPrihod; }
            set
            {
                godisnjiPrihod = value;
                OnPropertyChanged("GodisnjiPrihod");
            }
        }

        public string IkonicaPath
        {
            get { return ikonicaPath; }
            set
            {
                ikonicaPath = value;
                OnPropertyChanged("IkonicaPath");
            }
        }

        public bool Naselje
        {
            get { return naselje; }
            set
            {
                naselje = value;
                OnPropertyChanged("Naselje");
            }
        }
        public string TuristickiStatus
        {
            get { return turistickiStatus; }
            set
            {
                turistickiStatus = value;
                OnPropertyChanged("TuristickiStatus");
            }
        }
        public string Ime
        {
            get { return ime; }
            set
            {
                ime = value;
                OnPropertyChanged("Ime");
            }
        }
        public bool Unesco
        {
            get { return unesco; }
            set
            {
                unesco = value;
                OnPropertyChanged("Unesco");
            }
        }

        public TipSpomenika Tip
        {
            get { return tip; }
            set
            {
                tip = value;
                OnPropertyChanged("Tip");
            }
        }

        public List<Etiketa> Etikete
        {
            get { return etikete; }
            set
            {
                etikete = value;
                OnPropertyChanged("Etikete");
            }
        }

        public bool Arheo
        {
            get { return arheo; }
            set
            {
                arheo = value;
                OnPropertyChanged("Arheo");
            }
        }

        public Spomenik(string oznaka, string ime, string opis, string eraPorekla, string turistickiStatus, string ikonicaPath, bool unesco, bool naselje, bool arheo,string godisnjiPrihod, DateTime datumOtkrivanja, TipSpomenika tipSpomenika, List<Etiketa> etiketeList)
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
            this.Etikete = etiketeList;

        }

        public Spomenik()
        {
            this.oznaka = "prazno";
            this.ime = "prazno";
            this.opis = "prazno";
            this.arheo = true;
            this.ikonicaPath = "prazno";
            this.unesco = true;
            this.naselje = true;
            this.godisnjiPrihod = "prazno";
          
        }

        public void DodajEtiketu(Etiketa novaEtiketa)
        {
            this.etikete.Add(novaEtiketa);
        }

        public override string ToString()
        {
            return Ime;
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
