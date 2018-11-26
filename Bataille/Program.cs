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
		private static void Main(string[] args)
		{
			//on créer l'instance d'EnginDeCartes
			EnginDeCartes engin = new EnginDeCartes();

			// variale temporaire de list de list de cartes
			List<List<Carte>> deuxPaquets = engin.RetourneDeuxPaquets();

			// récupération de chaque paquet de cartes, pour le joueur et l'ordinateur
			List<Carte> cartesJoueur = deuxPaquets[0];
			List<Carte> cartesOrdi = deuxPaquets[1];	

			// création de 2 colonnes Joueur et ordi 
			int posHor = 0;
			
			// tant que les joueurs ont des cartes on boucle
			while (cartesJoueur.Count > 0 && cartesOrdi.Count > 0)
			{

				AfficheNomsJoueursEtCartes(posHor, cartesJoueur, cartesOrdi);				
				
                // saut de ligne 
				//posHor++;

				// Affichage gagnant
				// si il y a bataille
				if (cartesJoueur[0].Valeur == cartesOrdi[0].Valeur)
				{
					Console.WriteLine("Egalité! le joueur gagne pour l'instant");
					cartesJoueur.Add(cartesOrdi[0]);
					cartesOrdi.RemoveAt(0);

				}
				// si le joueur gagne
				else if (cartesJoueur[0].Valeur > cartesOrdi[0].Valeur)
				{
					Console.WriteLine("Joueur gagne!");
					cartesJoueur.Add(cartesOrdi[0]);
					cartesOrdi.RemoveAt(0);
				}
				// si l'Ordi gagne
				else
				{
					Console.WriteLine("Ordi gagne!");
					cartesOrdi.Add(cartesJoueur[0]);
					cartesJoueur.RemoveAt(0);
				}
				posHor++;
				posHor++;

				Console.ReadLine();
			}

			// Affichage final du gagnant
		 if (cartesOrdi.Count == 0)
			{
				Console.WriteLine("Le Joueur a gagné !");
			}
			else
	{
		Console.WriteLine("L'Ordinateur a gagné !");
	}
			Console.ReadLine();

		 
		}

		private static void AfficheNomsJoueursEtCartes(int posHor, List<Carte> cartesJoueur, List<Carte> cartesOrdi )
		{
			// Affichage noms des joueurs 
			Console.SetCursorPosition(0, posHor);
			Console.WriteLine(string.Format("Joueur ({0})", cartesJoueur.Count));

			Console.SetCursorPosition(20, posHor);
			Console.WriteLine(string.Format("Ordi ({0})", cartesOrdi.Count));
			posHor++;

			// Affichage des cartes des joueurs, la 1ere du paquet
			Console.SetCursorPosition(0, posHor);
			Console.WriteLine(cartesJoueur[0].Nom);
			Console.SetCursorPosition(20, posHor);
			Console.WriteLine(cartesOrdi[0].Nom);
			posHor++;
		}
	}
}
