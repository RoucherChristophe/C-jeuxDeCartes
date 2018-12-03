using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiblioCartes;
using BiblioBataille;

namespace Bataille
{
    class Program
    {
        private static void Main(string[] args)
        {

            Console.WriteLine("Pressez la touche N pour commencer une nouvelle partie");
            if (Console.ReadKey().Key!=ConsoleKey.N)
            {
                    return;
            }
            Console.Clear();
            Console.WriteLine("Nouvelle partie commencé, pressez une touche pour jouer");

            JeuxBataille jeuBataille = new JeuxBataille();
            jeuBataille.NouvellePartie();

            while (jeuBataille.EtatJeu != EtatsJeu.Termine)
            {
                Console.ReadKey();
                jeuBataille.JouerUnTour();
                Console.Clear();
                Console.SetCursorPosition(0, 0);
                Console.WriteLine("Etat du jeu: {0}", jeuBataille.EtatJeu.ToString());
                Console.SetCursorPosition(0, 1);
                Console.WriteLine("Gagnant dernier tour: {0}", jeuBataille.GagnantDernierTour.ToString());
                Console.SetCursorPosition(0, 2);
                Console.WriteLine("Nombre cartes joueur: {0}", jeuBataille.NombreCartesJoueur);
                Console.SetCursorPosition(40, 2);
                Console.WriteLine("Nombre cartes ordinateur: {0}", jeuBataille.NombreCartesOrdi);
                Console.SetCursorPosition(0, 3);
                Console.WriteLine("Nombre cartes bataille joueur: {0}", jeuBataille.NombreCartesBatailleJoueur);
                Console.SetCursorPosition(40, 3);
                Console.WriteLine("Nombre cartes bataille ordinateur: {0}", jeuBataille.NombreCartesBatailleOrdi);
                Console.SetCursorPosition(0, 4);
                Console.WriteLine("Valeur carte bataille: {0}", jeuBataille.ValeurCarteBataille);

                Console.SetCursorPosition(0, 6);
                Console.WriteLine("Joueur");
                Console.SetCursorPosition(20, 6);
                Console.WriteLine("Ordinateur");
                Console.SetCursorPosition(0, 7);
                Console.WriteLine(jeuBataille.CarteEnCourJoueur.Nom);
                Console.SetCursorPosition(20, 7);
                Console.WriteLine(jeuBataille.CarteEnCourOrdi.Nom);

            }
            Console.SetCursorPosition(0, 9);
            Console.WriteLine("La partie est terminée!!!");
            Console.SetCursorPosition(0, 10);
            if (jeuBataille.GagnantDernierTour == TypesJoueur.Joueur)
            {
                Console.WriteLine("Le joueur a gagné!!!");
            }
            else
            {
                Console.WriteLine("L'Ordinateur a gagné!!!");
            }
            Console.Read();
           
        }

    }
}
