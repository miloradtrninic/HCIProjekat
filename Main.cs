using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIProjekat
{
    public class Main
    {
        private ObservableCollection<Spomenik> spomeniciLista;
        private ObservableCollection<TipSpomenika> _tipspomenikaLista;

        private ObservableCollection<Etiketa> _etiketaLista;
        private static Main instance = null;

        private Main()
        {
            spomeniciLista = new ObservableCollection<Spomenik>();
            _tipspomenikaLista = new ObservableCollection<TipSpomenika>();
            _etiketaLista = new ObservableCollection<Etiketa>();
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
