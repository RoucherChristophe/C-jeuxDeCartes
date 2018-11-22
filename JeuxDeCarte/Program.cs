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
            string[] Cartes = new string[52];

            string[] typesCartes = new string[4] { "coeur", "carreau", "piques", "trefle" };

            int index = 0;
            for (int typeCarte = 0; typeCarte < 4; typeCarte++)
            {
                Cartes[index] = string.Format("As de {0}", typesCartes[typeCarte]);
                index++;

                for (int i = 2; i < 11; i++)
                {
                    Cartes[index] = string.Format("{0} de {1}", i, typesCartes[typeCarte]);
                    index++;
                }

                Cartes[index] = string.Format("Valet de {0}", typesCartes[typeCarte]);
                index++;
                Cartes[index] = string.Format("Dame de {0}", typesCartes[typeCarte]);
                index++;
                Cartes[index] = string.Format("Roi de {0}", typesCartes[typeCarte]);
                index++;
            }


            // création du jeux de cartes brassées

            string[] CartesBrassees = new string[52];
            Random rnd = new Random();

            for (int i = 0; i < 52; i++)
            {
                bool cartePlacee = false;
                while (!cartePlacee)
                {
                    int j = rnd.Next(0, 52);
                    if (CartesBrassees[j] == null)
                    {
                        CartesBrassees[j] = Cartes[i];
                        cartePlacee = true;
                    }

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