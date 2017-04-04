using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HCIProjekat
{
    public class Etiketa : INotifyPropertyChanged
    {
        
        private string oznaka;
        private Color boja;
        private string bojaKod;
        private string opis;


        public string Oznaka
        {
            get { return oznaka; }
            set
            {
                oznaka = value;
                OnPropertyChanged("Oznaka");
            }
        }

        public Color Boja
        {
            get { return boja; }
            set
            {
                boja = value;
                bojaKod = boja.ToString();
                OnPropertyChanged("BojaKod");
                OnPropertyChanged("Boja");
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

        public string BojaKod
        {
            get { return bojaKod; }
            set
            {
                bojaKod = value; 
                OnPropertyChanged("BojaKod");

            }
        }

        public Etiketa(string oznaka, Color boja, string opis)
        {
            this.oznaka = oznaka;
            this.bojaKod = boja.ToString();
            this.boja = boja;
            this.opis = opis;
        }

        public Etiketa()
        {
            oznaka = "";
            bojaKod = "";
            opis = "";

        }


        public override string ToString()
        {
            return oznaka + boja.ToString();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
