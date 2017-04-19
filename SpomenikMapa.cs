using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HCIProjekat
{
    [Serializable]
    public class SpomenikMapa : INotifyPropertyChanged
    {
        private Spomenik _spomenikNaMapi;
        private Point _koordinatePoint;

        public SpomenikMapa()
        {
            _spomenikNaMapi = new Spomenik();
            _koordinatePoint = new Point(0,0);
        }

        public SpomenikMapa(Spomenik spomenik, Point koordinatePoint)
        {
            _spomenikNaMapi = spomenik;
            _koordinatePoint = koordinatePoint;
        }



        public Spomenik SpomenikNaMapi
        {
            get { return _spomenikNaMapi; }
            set
            {
                _spomenikNaMapi = value;
                OnPropertyChanged("SpomenikNaMapi");
            }
        }

        public Point KoordinatePoint
        {
            get { return _koordinatePoint; }
            set
            {
                _koordinatePoint = value;
                OnPropertyChanged("KoordinatePoint");
            }
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
