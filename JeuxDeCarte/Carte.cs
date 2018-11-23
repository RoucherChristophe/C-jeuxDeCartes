using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuxDeCarte
{
    // création de la Classe Carte pour pouvoir récupérer les caractéristiques des cartes
    public class Carte
    {
        // propriétés des cartes

        public string Nom
        {
            get 
            {
                switch (_valeur)
                {
                    case 1:
                        {
                            return string.Format("As de {0}", RetourneCarteTexte(_typeCarte));
                        }
                    case 11:
                        {
                            return string.Format("Valet de {0}", RetourneCarteTexte(_typeCarte));
                        }
                    case 12:
                        {
                            return string.Format("Dame de {0}", RetourneCarteTexte(_typeCarte));
                        }
                    case 13:
                        {
                            return string.Format("Roi de {0}", RetourneCarteTexte(_typeCarte));
                        }
                    default:
                        {
                            return string.Format("{0} de {1}", _valeur.ToString(), RetourneCarteTexte(_typeCarte));
                        }
                }

            }
        }

        private int _valeur;
        public int Valeur
        {
            get { return _valeur; }
            set { _valeur = value; }
        }
        
        // propriété qui donne le nom de façon générique
        private EnginDeCartes.TypesCartes _typeCarte;
        public EnginDeCartes.TypesCartes TypeCarte
        {
            get { return _typeCarte; }
            set { _typeCarte = value; }
        }

        // fonction qui retourne le texte de l'enum
        public string RetourneCarteTexte(EnginDeCartes.TypesCartes typeCarte)
        {
            switch (typeCarte)
            {
                case EnginDeCartes.TypesCartes.Coeur: { return "coeur"; }
                case EnginDeCartes.TypesCartes.Carreau: { return "carreau"; }
                case EnginDeCartes.TypesCartes.Piques: { return "piques"; }
                case EnginDeCartes.TypesCartes.Trefle: { return "trèfle"; }
                default: { return null; }
            }
        }



    }
}
