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

        // fonction qui créer un jeux de cartes
        public List<Carte> RetournerNouveauPaquet()
        {
            // création du jeux de cartes
            // list dynamique
            List<Carte> Cartes = new List<Carte>();

            for (TypesCartes typeCarte = 0; typeCarte <= TypesCartes.Trefle; typeCarte++)
            {
                // création de l'AS
                Carte carte = new Carte();
                carte.TypeCarte = typeCarte; //on passe le type de carte en cour (le nom)
                carte.Valeur = 1;
                Cartes.Add(carte);

                // création des cartes de 2 à 10
                for (int i = 2; i < 11; i++)
                {
                    carte = new Carte(); //on réassigne la carte
                    carte.TypeCarte = typeCarte; //on passe le type de carte en cour (le nom)
                    carte.Valeur = i;
                    Cartes.Add(carte);
                }

                // création des valets
                carte = new Carte(); //on réassigne la carte
                carte.TypeCarte = typeCarte; //on passe le type de carte en cour (le nom)
                carte.Valeur = 11;
                Cartes.Add(carte);
                // création des dames
                carte = new Carte(); //on réassigne la carte
                carte.TypeCarte = typeCarte;//on passe le type de carte en cour (le nom)
                carte.Valeur = 12;
                Cartes.Add(carte);
                // création des rois
                carte = new Carte(); //on réassigne la carte
                carte.TypeCarte = typeCarte; //on passe le type de carte en cour (le nom)
                carte.Valeur = 13;
                Cartes.Add(carte);
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
