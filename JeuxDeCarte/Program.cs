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
            //on creer l'instance d'EnginDeCartes
            EnginDeCartes engin = new EnginDeCartes();

            // Cartes reçoit le nouveau paquet de cartes
            List<Carte> Cartes = engin.RetournerNouveauPaquet();

            // création du jeux de cartes brassées
            // CarteBrassees reçoit une liste demandé à l'engin BrassCarte avec en parametre un nouveau paquet de carte

           // List<string> CartesBrassees = engin.BrassCarte(Cartes);
           

            for (int i = 0; i < 52; i++)
            {
                Console.WriteLine(string.Format("Nom de la carte: {0} - Valeur: {1}", Cartes[i].Nom, Cartes[i].Valeur));
                Console.ReadLine();
            }

            }
        }
    }