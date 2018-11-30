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

	public enum TypesJoueur
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
        private List<Carte> _cartesBatailleJoueur;
        private List<Carte> _cartesBatailleOrdi;
		private EtatsJeu _etatJeu;
		private Carte _carteEnCoursJoueur;
		private Carte _carteEnCoursOrdi;
		private TypesJoueur _gagnantDernierTour;
        private int _valeurCarteBataille;

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

		public TypesJoueur GagnantDernierTour
		{
			get { return _gagnantDernierTour; }
		}

		public int NombreCartesJoueur
		{
			get { return _cartesJoueur.Count; }
		}

		public int NombreCartesOrdi
		{
			get { return _cartesOrdi.Count; }
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
            _cartesBatailleJoueur = new List<Carte>();
            _cartesBatailleOrdi = new List<Carte>();
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

                if (_carteEnCoursJoueur.Valeur == _carteEnCoursOrdi.Valeur)
                {
                    _etatJeu = EtatsJeu.Bataille;
                    _valeurCarteBataille = _carteEnCoursJoueur.Valeur;
                }
                else if (_carteEnCoursJoueur.Valeur > _carteEnCoursOrdi.Valeur)
				{
					_engin.PlacerCarteSousPaquet(ref _carteEnCoursOrdi, _cartesJoueur);
					_engin.PlacerCarteSousPaquet(ref _carteEnCoursJoueur, _cartesJoueur);
					_gagnantDernierTour = TypesJoueur.Joueur;
				}                				
				else
				{
					_engin.PlacerCarteSousPaquet(ref _carteEnCoursJoueur, _cartesOrdi);
					_engin.PlacerCarteSousPaquet(ref _carteEnCoursOrdi, _cartesOrdi);
					_gagnantDernierTour = TypesJoueur.Ordi;
				}


            } if (_etatJeu == EtatsJeu.Bataille)
            {
                if (_cartesJoueur.Count > 0 && _cartesOrdi.Count >0)
                {
                    _engin.DeplacerCarteDessusDessus(_cartesJoueur, _cartesBatailleJoueur);
                    _engin.DeplacerCarteDessusDessus(_cartesOrdi, _cartesBatailleOrdi);
                }

                else if (_cartesJoueur.Count == 0)
                {
                    _engin.DeplacerCarteDessusDessus(_cartesOrdi, _cartesBatailleJoueur);
                    _engin.DeplacerCarteDessusDessus(_cartesOrdi, _cartesBatailleOrdi);
                }
                else if (_cartesOrdi.Count == 0)
                {
                    _engin.DeplacerCarteDessusDessus(_cartesJoueur, _cartesBatailleJoueur);
                    _engin.DeplacerCarteDessusDessus(_cartesJoueur, _cartesBatailleOrdi);
                }

                _carteEnCoursJoueur = _cartesBatailleJoueur[0];
                _carteEnCoursOrdi = _cartesBatailleOrdi[0];


            }


		}

		 
	}
}
