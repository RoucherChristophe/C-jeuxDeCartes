using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuxDeCarte
{
    public class Carte
    {
        private string _nom;

        public string Nom
        {
            get { return _nom;  }
            set { _nom = value; }
        }

        private int _valeur;
        public int Valeur
        {
            get { return _valeur; }
            set { _valeur = value; }
        }
    }
}
