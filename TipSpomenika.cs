using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HCIProjekat 
{
    [Serializable]  
    public class TipSpomenika : INotifyPropertyChanged
    {
        //Tip spomenika je opisan preko svoje jedinstvene ljudski-čitljive oznake koju unosi korisnik, imena, ikonice, i opisa. Ikonica je sličica koja se učitava i koja se koristi da se taj tip spomenika označi na mapi.

        private string oznaka;
        private string ime;
        private string ikonicaPath;
        private string opis;

        public TipSpomenika()
        {
            oznaka = "";
            ime = "";
            ikonicaPath = "";
            opis = "";
        }


        public TipSpomenika(string oznaka, string ime, string ikonicaPath, string opis)
        {
            this.oznaka = oznaka;
            this.ime = ime;
            this.ikonicaPath = ikonicaPath;
            this.opis = opis;
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

        public string Ime
        {
            get { return ime; }
            set
            {
                ime = value;
                OnPropertyChanged("Ime");
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

        public string Opis
        {
            get { return opis; }
            set
            {
                opis = value;
                OnPropertyChanged("Opis");
            }
        }

        public override string ToString()
        {
            return ime;
        }
        [field:NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
