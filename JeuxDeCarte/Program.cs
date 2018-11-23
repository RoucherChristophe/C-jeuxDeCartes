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

            List<Carte> CartesBrassees = engin.BrassCarte(Cartes);

            for (int i = 0; i < 52; i++)
            {
                Console.WriteLine(string.Format("Valeur: {0}", CartesBrassees[i].Valeur));
                Console.WriteLine(string.Format("Type: {0}", CartesBrassees[i].RetourneCarteTexte(CartesBrassees[i].TypeCarte)));
                Console.WriteLine(string.Format("Nom: {0}", CartesBrassees[i].Nom));
                Console.ReadLine();
            }

         }
     }
}