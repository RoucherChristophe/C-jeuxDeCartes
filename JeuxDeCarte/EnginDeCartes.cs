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

        public void DeplacerCarteDessusDessous(List<Carte> paquet1, List<Carte> paquet2)
        {
            paquet2.Add(paquet1[0]); // on récupère la carte du paquet1 et on la place en dessous du paquet2
            paquet1.RemoveAt(0); // la carte du paquet1 est suprimmé 

        }

        public void DeplacerCarteDessusDessus(List<Carte> paquet1, List<Carte> paquet2)
        {
            // insert permet de choisir ou on veut positionner la carte dans le paquet
            // on met la carte au dessus du paquet de bataille pour pouvoir les confronter
            paquet2.Insert(0, paquet1[0]); // on retire la 1ere carte du paquet1 pour la mettre au dessus du paquet2
            paquet1.RemoveAt(0); // on retire la carte du paquet1 
        }

        public void DeplacerPaquetDessous(List<Carte> paquet1, List<Carte> paquet2)
        {
            paquet2.AddRange(paquet1);
            paquet1.Clear();
        }

        public void JouerCarte(List<Carte> paquet, ref Carte carte)
        {
            carte = paquet[0];
            paquet.RemoveAt(0);
        }

        public void PlacerCarteSousPaquet(ref Carte carte, List<Carte> paquet)
        {
            paquet.Add(carte);
        }




    }
}
