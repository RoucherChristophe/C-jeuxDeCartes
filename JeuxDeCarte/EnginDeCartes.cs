using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuxDeCarte
{
   
    public class EnginDeCartes
    {

        // création de l'enum
        public enum TypesCartes
        {
            Coeur = 0,
            Carreau = 1,
            Piques = 2,
            Trefle = 3
        }

        // fonction qui retourne le texte de l'enum
        public string RetourneCarteTexte(TypesCartes typeCarte)
        {
            switch (typeCarte)
            {
                case TypesCartes.Coeur: { return "coeur"; }
                case TypesCartes.Carreau: { return "carreau"; }
                case TypesCartes.Piques: { return "piques"; }
                case TypesCartes.Trefle: { return "trèfle"; }
                default: { return null; }
            }
        }





        // fonction qui créer un jeux de cartes
        public List<string> RetournerNouveauPaquet()
        {
            // création du jeux de cartes
            // list dynamique
            List<string> Cartes = new List<string>();

            List<string> typesCartes = new List<string>() { "coeur", "carreau", "piques", "trefle" };

            for (TypesCartes typeCarte = 0; typeCarte <= TypesCartes.Trefle; typeCarte++)
            {
                Cartes.Add(string.Format("As de {0}",RetourneCarteTexte(typeCarte)));

                for (int i = 2; i < 11; i++)
                {
                    Cartes.Add(string.Format("{0} de {1}", i, RetourneCarteTexte(typeCarte)));
                }

                Cartes.Add(string.Format("Valet de {0}", RetourneCarteTexte(typeCarte)));
                Cartes.Add(string.Format("Dame de {0}", RetourneCarteTexte(typeCarte)));
                Cartes.Add(string.Format("Roi de {0}", RetourneCarteTexte(typeCarte)));
            }
            // on retourne les cartes
            return Cartes;
        }


        // on créer une fonction pour brasséer les cartes
        // c'est une liste de type string qui reçoit en parametre une list string que l'on appelle Cartes
        public List<string> BrassCarte(List<string> Cartes)
        {
            List<string> CartesBrassees = new List<string>();
            // on créer un nombre aléatoire
            Random rnd = new Random();

            // tant que CarteBrassees est inférieur à 52
            while (CartesBrassees.Count < 52)
            {
                int i = rnd.Next(0, 52); // on obtient un chiffre entre 0 et 52
                // si CarteBrassees ne contient pas la carte sélectionnée, on l'ajoute au paquet de CarteBrassees
                if (!CartesBrassees.Contains(Cartes[i]))
                {
                    CartesBrassees.Add(Cartes[i]);
                }
            }

            return CartesBrassees;
        }




    }
}
