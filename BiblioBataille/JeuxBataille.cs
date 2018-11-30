using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BiblioCartes;

namespace BiblioBataille
{
    // création d'un 'enum' pour connaître l'état du jeu
    public enum EtatsJeu
    {
        AttenteNouvellePartie,
        Normal,
        Bataille,
        Termine

    }

    public enum TypeJoueur
    {
        Joueur,
        Ordi
    }


    public class JeuxBataille
    {
        // création de variables privées
        private EnginDeCartes _engin;
        private List<Carte> _cartesJoueur;
        private List<Carte> _cartesOrdi;
        private EtatsJeu _etatJeu;
        private Carte _carteEnCoursJoueur;
        private Carte _carteEnCoursOrdi;
        private TypeJoueurs _gagnantDernierTour;

        // constructeur
        public JeuxBataille()
        {
            // au départ '_etatJeu' est en 'AttenteNouvellePartie'
            _etatJeu = EtatsJeu.AttenteNouvellePartie;
        }

        // propriétés de l'enum 'EtatsJeu'
        public EtatsJeu EtatJeu
        {
            get { return _etatJeu; }
        }
         
        // propriétés pour demander à la librairie quel est la carte en cour de jeu
        public Carte CarteEnCourJoueur
        {
            get { return _carteEnCoursJoueur; }
        }

        public Carte CarteEnCourOrdi
        {
            get { return _carteEnCoursOrdi; }
        }

        // lancer une nouvelle partie
        public void NouvellePartie()
        {
            // instanciation
            _engin = new EnginDeCartes();
            List<List<Carte>> deuxPaquets = _engin.RetourneDeuxPaquets();
            _cartesJoueur = deuxPaquets[0];
            _cartesOrdi = deuxPaquets[1]; 
            _etatJeu = EtatsJeu.Normal;
        }

        public void JouerUnTour()
        {
            if (_etatJeu !=EtatsJeu.Normal && _etatJeu !=EtatsJeu.Bataille)
            {
                return;
            }

            if (_etatJeu ==EtatsJeu.Normal)
            {
                _engin.JouerCarte(_cartesJoueur, ref _carteEnCoursJoueur);
                _engin.JouerCarte(_cartesOrdi, ref _carteEnCoursOrdi);

                    if (_carteEnCoursJoueur.Valeur >= _carteEnCoursOrdi.Valeur)
	                {
		                _engin.PlacerCarteSousPaquet(ref _carteEnCoursOrdi, _cartesJoueur);
                        _engin.PlacerCarteSousPaquet(ref _carteEnCoursJoueur, _cartesJoueur);
	                }
            }


        }

         
    }
}
