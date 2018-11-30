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
            // on prevoit le nombre de lignes de sortie
            Console.BufferHeight = 10000;
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
                // les valeurs de posHor doivent être passées par référence, et non par valeur
                // il faut mettre 'ref' devant tous les 'posHor', que ce soit l'appelant ou l'appelé
                AfficheNomsJoueursEtCartes(ref posHor, cartesJoueur, cartesOrdi);								
                // saut de ligne pour chaque colonne
                posHor++;

                AfficheGagnant(ref posHor, engin, cartesJoueur, cartesOrdi);
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

        private static void AfficheNomsJoueursEtCartes(ref int posHor, List<Carte> cartesJoueur, List<Carte> cartesOrdi )
        {
            posHor++;
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

        private static void AfficheGagnant(ref int posHor, EnginDeCartes engin, List<Carte> cartesJoueur, List<Carte> cartesOrdi)
        {
            // Affichage gagnant
            // si il y a bataille
            if (cartesJoueur[0].Valeur == cartesOrdi[0].Valeur)
            {
                Bataille(ref posHor, engin,  cartesJoueur, cartesOrdi);
            }
            // si le joueur gagne
            else if (cartesJoueur[0].Valeur > cartesOrdi[0].Valeur)
            {
                Console.WriteLine("Joueur gagne!");
                engin.DeplacerCarteDessusDessous(cartesOrdi, cartesJoueur);
                engin.DeplacerCarteDessusDessous(cartesJoueur, cartesJoueur);
               
            }
            // si l'Ordi gagne
            else
            {
                Console.WriteLine("Ordi gagne!");
                engin.DeplacerCarteDessusDessous(cartesJoueur, cartesOrdi);
                engin.DeplacerCarteDessusDessous(cartesOrdi, cartesOrdi);
                
            }
        }


        // fonction pour gérer la bataille, le 1er qui sort la même carte que la bataille gagne les 2 paquets de bataille
        private static void Bataille(ref int posHor, EnginDeCartes engin, List<Carte> cartesJoueur, List<Carte> cartesOrdi)
        {
            //on récupère la valeur de la carte en bataille
            int valeurCarteBataille = cartesJoueur[0].Valeur; 

            // on créer 2 nouveaux paquets pour la bataille       
            List<Carte> cartesBatailleJoueur = new List<Carte>();
            List<Carte> cartesBatailleOrdi = new List<Carte>();

            DistribuerCartesBataille(engin, cartesJoueur, cartesOrdi, cartesBatailleJoueur, cartesBatailleOrdi);

            posHor++;
            // on positionne le curseur
            Console.SetCursorPosition(0, posHor);
            // on informe le jioueur qu'il est en bataille
            Console.WriteLine("B A T A I L L E ! ! !");
            posHor ++;
            Console.ReadLine();

            while (true)
            {
                DistribuerCartesBataille(engin, cartesJoueur, cartesOrdi, cartesBatailleJoueur, cartesBatailleOrdi);

                AfficheNomsJoueursEtCartes(ref posHor, cartesBatailleJoueur, cartesBatailleOrdi);

                posHor ++;

                // le 1er joueur qui sort la même carte que la bataille gagne
                if (cartesBatailleJoueur[0].Valeur == valeurCarteBataille)
                {
                    GagneBataille(ref posHor, cartesJoueur, cartesOrdi, cartesBatailleJoueur, cartesBatailleOrdi, true);
                    break;
                }
                else if (cartesBatailleOrdi[0].Valeur == valeurCarteBataille)
                {
                    GagneBataille(ref posHor, cartesJoueur, cartesOrdi, cartesBatailleJoueur, cartesBatailleOrdi, false);
                    break;
                }

                Console.SetCursorPosition(0, posHor);
                Console.WriteLine("Cartes Joueur:{0} | Cartes Ordi:{1}", cartesJoueur.Count, cartesOrdi.Count);
                posHor++;
                Console.ReadLine();
            }

        }

        private static void DistribuerCartesBataille(EnginDeCartes engin, List<Carte> cartesJoueur, List<Carte> cartesOrdi,
                                                     List<Carte> cartesBatailleJoueur, List<Carte> cartesBatailleOrdi)
        {
            // si le joueur n'a plus de cartes pour faire une bataille l'ordi lui en donne
            if (cartesJoueur.Count == 0)
            {
                engin.DeplacerCarteDessusDessus(cartesOrdi, cartesBatailleJoueur);
                engin.DeplacerCarteDessusDessus(cartesOrdi, cartesBatailleOrdi);
            }
            else if (cartesOrdi.Count == 0)
            {
                engin.DeplacerCarteDessusDessus(cartesJoueur, cartesBatailleJoueur);
                engin.DeplacerCarteDessusDessus(cartesJoueur, cartesBatailleOrdi);
            }
            else
            {
                engin.DeplacerCarteDessusDessus(cartesJoueur, cartesBatailleJoueur);
                engin.DeplacerCarteDessusDessus(cartesOrdi, cartesBatailleOrdi); 
            }
        }

        private static void GagneBataille(ref int posHor, List<Carte> cartesJoueur, List<Carte> cartesOrdi,
                                          List<Carte> cartesBatailleJoueur, List<Carte> cartesBatailleOrdi, bool joueurGagnant)
        {
            Console.SetCursorPosition(0, posHor);
            if (joueurGagnant)
            {
                Console.WriteLine("Le joueur a gagné la bataille");
                // on prend toutes les cartes du paquet bataille du joueur pour lui redonner
                // 'AddRange' permet d'ajouter des collections
                cartesJoueur.AddRange(cartesBatailleJoueur);              
                // on prend toutes les cartes du paquet bataille de l'ordi pour le donner au joueur
                cartesJoueur.AddRange(cartesBatailleOrdi);
            }
            else
            {
                Console.WriteLine("L'Ordi a gagné la bataille");
                // on prend toutes les cartes du paquet bataille de l'ordi pour lui redonner 
                cartesOrdi.AddRange(cartesBatailleJoueur);
                // on prend toutes les cartes du paquet bataille du joueur pour le donner a l'ordi
                cartesOrdi.AddRange(cartesBatailleOrdi);
            }
        }

    }
}
