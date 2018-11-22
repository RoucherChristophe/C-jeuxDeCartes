using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JeuxDeCarte
{
    class Program
    {
        static void Main(string[] args)
        {

            // création du jeux de cartes
            // list dynamique
            List<string> Cartes = new List<string>();

            List<string> typesCartes = new List<string>() { "coeur", "carreau", "piques", "trefle" };

            for (int typeCarte = 0; typeCarte < 4; typeCarte++)
            {
                Cartes.Add(string.Format("As de {0}", typesCartes[typeCarte]));

                for (int i = 2; i < 11; i++)
                {
                    Cartes.Add(string.Format("{0} de {1}", i, typesCartes[typeCarte]));
                }

                Cartes.Add(string.Format("Valet de {0}", typesCartes[typeCarte]));
                Cartes.Add(string.Format("Dame de {0}", typesCartes[typeCarte]));
                Cartes.Add(string.Format("Roi de {0}", typesCartes[typeCarte]));
            }


            // création du jeux de cartes brassées
            // List dynamique

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

            for (int i = 0; i < 52; i++)
            {
                Console.WriteLine(CartesBrassees[i]);
                Console.ReadLine();
            }


            }
        }
    }