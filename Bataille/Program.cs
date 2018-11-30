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

                AfficheGagnant(ref posHor, cartesJoueur, cartesOrdi);
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

        private static void AfficheGagnant(ref int posHor, List<Carte> cartesJoueur, List<Carte> cartesOrdi)
        {
            // Affichage gagnant
            // si il y a bataille
            if (cartesJoueur[0].Valeur == cartesOrdi[0].Valeur)
            {
                Bataille(ref posHor,  cartesJoueur, cartesOrdi);
            }
            // si le joueur gagne
            else if (cartesJoueur[0].Valeur > cartesOrdi[0].Valeur)
            {
                Console.WriteLine("Joueur gagne!");
                cartesJoueur.Add(cartesOrdi[0]); // on récupère la carte de l'ordi et on la place en dessous du paquet
                cartesJoueur.Add(cartesJoueur[0]); // le joueur récupère sa carte et la place en dessous du paquet
                cartesJoueur.RemoveAt(0); // la carte du joueur est en double on supprime le doublon
                cartesOrdi.RemoveAt(0); // la carte de l'ordi est suprimmé de son paquet
            }
            // si l'Ordi gagne
            else
            {
                Console.WriteLine("Ordi gagne!");
                cartesOrdi.Add(cartesJoueur[0]);
                cartesOrdi.Add(cartesOrdi[0]);
                cartesOrdi.RemoveAt(0);
                cartesJoueur.RemoveAt(0);
            }
        }


        // fonction pour gérer la bataille, le 1er qui sort la même carte que la bataille gagne les 2 paquets de bataille
        private static void Bataille(ref int posHor, List<Carte> cartesJoueur, List<Carte> cartesOrdi)
        {
            //on récupère la valeur de la carte en bataille
            int valeurCarteBataille = cartesJoueur[0].Valeur; 

            // on créer 2 nouveaux paquets pour la bataille       
            List<Carte> cartesBatailleJoueur = new List<Carte>();
            List<Carte> cartesBatailleOrdi = new List<Carte>();

            DistribuerCartesBataille(cartesJoueur, cartesOrdi, cartesBatailleJoueur, cartesBatailleOrdi);

            posHor++;
            // on positionne le curseur
            Console.SetCursorPosition(0, posHor);
            // on informe le jioueur qu'il est en bataille
            Console.WriteLine("B A T A I L L E ! ! !");
            posHor ++;
            Console.ReadLine();

            while (true)
            {
                DistribuerCartesBataille(cartesJoueur, cartesOrdi, cartesBatailleJoueur, cartesBatailleOrdi);

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

        private static void DistribuerCartesBataille(List<Carte> cartesJoueur, List<Carte> cartesOrdi,
                                                     List<Carte> carteBatailleJoueur, List<Carte> cartesBatailleOrdi)
        {
            // si le joueur n'a plus de cartes pour faire une bataille l'ordi lui en donne
            if (cartesJoueur.Count == 0)
            {
                carteBatailleJoueur.Insert(0, cartesOrdi[0]);
                cartesOrdi.RemoveAt(0);
                cartesBatailleOrdi.Insert(0, cartesOrdi[0]);
                cartesOrdi.RemoveAt(0);
            }
            else if (cartesOrdi.Count == 0)
            {
                carteBatailleJoueur.Insert(0, cartesJoueur[0]);
                cartesJoueur.RemoveAt(0);
                cartesBatailleOrdi.Insert(0, cartesJoueur[0]);
                cartesJoueur.RemoveAt(0);
            }
            else
            {
                // insert permet de choisir ou on veut positionner la carte dans le paquet
                // on met la carte au dessus du paquet de bataille pour pouvoir les confronter
                carteBatailleJoueur.Insert(0, cartesJoueur[0]);
                cartesJoueur.RemoveAt(0); // on retire les cartes du paquet principale du joueur
                cartesBatailleOrdi.Insert(0, cartesOrdi[0]);
                cartesOrdi.RemoveAt(0); // on retire les cartes du paquet principale de l'ordi
            }
        }



        private static void GagneBataille(ref int posHor, List<Carte> cartesJoueur, List<Carte> cartesOrdi,
                                          List<Carte> carteBatailleJoueur, List<Carte> carteBatailleOrdi, bool joueurGagnant)
        {
            Console.SetCursorPosition(0, posHor);
            if (joueurGagnant)
            {
                Console.WriteLine("Le joueur a gagné la bataille");
                // on prend toutes les cartes du paquet bataille du joueur pour lui redonner
                // 'AddRange' permet d'ajouter des collections
                cartesJoueur.AddRange(carteBatailleJoueur);              
                // on prend toutes les cartes du paquet bataille de l'ordi pour le donner au joueur
                cartesJoueur.AddRange(carteBatailleOrdi);
            }
            else
            {
                Console.WriteLine("L'Ordi a gagné la bataille");
                // on prend toutes les cartes du paquet bataille de l'ordi pour lui redonner 
                cartesOrdi.AddRange(carteBatailleJoueur);
                // on prend toutes les cartes du paquet bataille du joueur pour le donner a l'ordi
                cartesOrdi.AddRange(carteBatailleOrdi);
            }
        }

    }
}
