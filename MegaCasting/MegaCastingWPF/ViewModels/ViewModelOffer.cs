using MegaCasting.DBLib;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace MegaCastingWPF.ViewModels
{
    class ViewModelOffer : ViewModelBase
    {
        #region Attributes

        /// <summary>
        /// Liste observable des offres
        /// </summary>
        private ObservableCollection<Offer> _Offers;

        private Offer _SelectedOffer;

        #endregion

        #region Properties

        /// <summary>
        /// Obtient ou définis les offres
        /// </summary>
        public ObservableCollection<Offer> Offers
        {
            get { return _Offers; }
            set { _Offers = value; }
        }

        /// <summary>
        ///  Obtient ou définis les offres sélectionné
        /// </summary>
        public Offer SelectedOffer
        {
            get { return _SelectedOffer; }
            set { _SelectedOffer = value; }

        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public ViewModelOffer()
        {
            Offers = new ObservableCollection<Offer>(this.Entities.Offers);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Permet l'ajout d'une offre en BDD
        /// </summary>
        /// <param name="textBox"></param>
        public void AddOffer(TextBox NameOffer, TextBox ReferenceOffer, TextBox DescriptionOffer, TextBox PeriodOffer)
        {
            //, ComboBox ...
            // On crée une nouvelle instance
            Offer offer = new Offer();
            // On attribue le texte contenu dans la textbox
            offer.Name = NameOffer.Text;
            offer.Reference = ReferenceOffer.Text;
            offer.Description = DescriptionOffer.Text;
            //offer.PostNumber = PostNumberOffer.Text;
            //offer.Period = PeriodOffer.Text;
            this.Entities.Offers.Add(offer);
            // On ajoute le producteur à la BDD
            this.Offers.Add(offer);
            // On sauvegarde les modifications dans la BDD
            this.Entities.SaveChanges();
        }

        /// <summary>
        /// Permet la suppression d'une offre en BDD
        /// </summary>
        /// <returns>Retourne un booléen qui permet de contrôler l'affichage de MessageBox dans ViewOffer.xaml.cs</returns>
        public Boolean DeleteOffer()
        {
            Boolean boolean = false;
            // On vérifie qu'une offre à bien été sélectionné
            if (SelectedOffer != null)
            {
                boolean = true;
                this.Entities.Offers.Remove(SelectedOffer);
                // On supprime l'offre de la BDD
                this.Offers.Remove(SelectedOffer);
                // On sauvegarde les modifications dans la BDD
                this.Entities.SaveChanges();
            }
            else
            {
                MessageBox.Show("Aucune offre a été sélectionné");
            }
            return boolean;
        }

        /// <summary>
        /// Permet de sauvegarder un producteur
        /// </summary>
        public void UpdateOffer()
        {
            // On sauvegarde les modifications dans la BDD
            this.Entities.SaveChanges();
        }

        #endregion
    }
}
