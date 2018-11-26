using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiblioCartes;

namespace Bataille
{
	class Program
	{
		static void Main(string[] args)
		{
			//on creer l'instance d'EnginDeCartes
			EnginDeCartes engin = new EnginDeCartes();

            // variale temporaire de list de list de cartes
            List<List<Carte>> deuxPaquets = engin.RetourneDeuxPaquets();

			// récupération de chaque paquet de cartes, pour le joueur et l'ordinateur
            List<Carte> cartesJoueur = deuxPaquets[0];
            List<Carte> cartesOrdi = deuxPaquets[1];	

			// variables pour les points des joueurs
			int pointsJoueur = 0;
			int pointsOrdi = 0;

			// création de 2 colonnes Joueur et ordi 
			int posHor = 0;
			for (int i = 0; i < 26; i++)
			{
				// Affichage noms des joueurs 
				Console.SetCursorPosition(0, posHor);
				Console.WriteLine(string.Format("Joueur ({0})", pointsJoueur));

				Console.SetCursorPosition(20, posHor);
				Console.WriteLine(string.Format("Ordi ({0})", pointsOrdi));
				posHor++;

				// Affichage des cartes des joueurs
				Console.SetCursorPosition(0, posHor);
				Console.WriteLine(cartesJoueur[i].Nom);
				Console.SetCursorPosition(20, posHor);
				Console.WriteLine(cartesOrdi[i].Nom);
				posHor++;

				// Affichage gagnant
				if (cartesJoueur[i].Valeur == cartesOrdi[i].Valeur)
				{
					Console.WriteLine("Egalité!"); 
				}
				else if (cartesJoueur[i].Valeur > cartesOrdi[i].Valeur)
				{
					Console.WriteLine("Joueur gagne!");
					pointsJoueur++;
				}
				else
				{
					Console.WriteLine("Ordi gagne!");
					pointsOrdi++;
				}
				posHor++;
				posHor++;

				Console.ReadLine();
			}

			// Affichage final du gagnant
			if (pointsOrdi == pointsJoueur)
			{
				Console.WriteLine("Egalité !");
			}
			else if (pointsJoueur > pointsOrdi)
			{
				Console.WriteLine("Le Joueur a gagné ! {0} points à {1} points", pointsJoueur, pointsOrdi);
			}
			else
	{
		Console.WriteLine("L'Ordinateur a gagné ! {0} points à {1} points", pointsOrdi, pointsJoueur);
	}
			Console.ReadLine();

		 
		}
	}
}
