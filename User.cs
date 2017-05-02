using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCIProjekat
{
    public class User
    {
        private string _ime;
        private string _prezime;
        private string _username;
        private string _lozinka;

        public User()
        {
            _ime = "";
            _prezime = "";
            _username = "";
            _lozinka = "";
        }

        public string Ime
        {
            get { return _ime; }
            set { _ime = value; }
        }

        public string Prezime
        {
            get { return _prezime; }
            set { _prezime = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Lozinka
        {
            get { return _lozinka; }
            set { _lozinka = value; }
        }
    }
}
