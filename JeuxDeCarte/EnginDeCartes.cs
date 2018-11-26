using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioCartes
{
   
    public class EnginDeCartes
    {

        // fonction qui retourne 2 paquets (2 List) de cartes à partir d'1 paquet de carte créé
        public List<List<Carte>> RetourneDeuxPaquets()
        {
            // on créer une list qui contient une list de cartes temporaires
            List<List<Carte>> deuxPaquets = new List<List<Carte>>();

            // on récupère un nouveau paqiuet de cartes que l'on brasse
            List<Carte> paquetBrasse = BrassCarte(RetournerNouveauPaquet());

            // création des 2 paquets de cartes
            List<Carte> paquet1 = new List<Carte>();
            List<Carte> paquet2 = new List<Carte>();

            // création de 2 boucles pour distribuer le jeux de cartes brassées
            for (int i = 0; i < 26; i++)
            {
                paquet1.Add(paquetBrasse[i]);
            }
            deuxPaquets.Add(paquet1);

            for (int i = 26; i < 52; i++)
            {
                paquet2.Add(paquetBrasse[i]);
            }
            deuxPaquets.Add(paquet2);

            // on retourne les 2 paquets
            return deuxPaquets;
        }

        // fonction privée qui permet de créer une carte
        private Carte CreerCarte(Carte.TypesCartes typeCarte, int valeur)
        {
            return new Carte() { TypeCarte = typeCarte, Valeur = valeur };
        }

        // fonction qui créer un jeux de cartes
        public List<Carte> RetournerNouveauPaquet()
        {
            // création du jeux de cartes
            // list dynamique
            List<Carte> Cartes = new List<Carte>();

            for (Carte.TypesCartes typeCarte = 0; typeCarte <= Carte.TypesCartes.Trefle; typeCarte++)
            {
                // création des cartes 
                for (int i = 1; i < 14; i++)
                {
                    Cartes.Add(CreerCarte(typeCarte, i));
                }             
            }
            // on retourne les cartes
            return Cartes;
        }

        // on créer une fonction pour brasséer les cartes
        // c'est une liste de type string qui reçoit en parametre une list string que l'on appelle Cartes
        public List<Carte> BrassCarte(List<Carte> Cartes)
        {
            List<Carte> CartesBrassees = new List<Carte>();
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
