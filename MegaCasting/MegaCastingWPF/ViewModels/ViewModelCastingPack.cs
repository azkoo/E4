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
    class ViewModelCastingPack : ViewModelBase
    {
        #region Attribute

        /// <summary>
        /// Liste observable des packs de casting
        /// </summary>
        private ObservableCollection<CastingPack> _CastingPacks;

        private CastingPack _SelectedCastingPack;

        #endregion

        #region Properties

        /// <summary>
        /// Obtient ou définis un pack de casting
        /// </summary>
        public ObservableCollection<CastingPack> CastingPacks
        {
            get { return _CastingPacks; }
            set { _CastingPacks = value; }
        }

        /// <summary>
        /// Obtient ou définis un pack de casting sélectionné
        /// </summary>
        public CastingPack SelectedCastingPack
        {
            get { return _SelectedCastingPack; }
            set { _SelectedCastingPack = value; }

        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public ViewModelCastingPack()
        {
            CastingPacks = new ObservableCollection<CastingPack>(this.Entities.CastingPacks);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Permet d'ajouter un pack de casting
        /// </summary>
        /// <param name="textBox"></param>
        public void AddCastingPack(TextBox Name, TextBox Size)
        {
            // On crée une nouvelle instance
            CastingPack castingPack = new CastingPack();
            // On attribue le texte contenu dans la textbox
            castingPack.Name = Name.Text;
            this.Entities.CastingPacks.Add(castingPack);
            // On ajoute le type de contrat à la BDD
            this.CastingPacks.Add(castingPack);
            // On sauvegarde les modifications dans la BDD
            this.Entities.SaveChanges();
        }

        /// <summary>
        /// Permet de supprimer un pack de casting
        /// </summary>
        /// <returns>Retourne un booléen qui permet de contrôler l'affichage de MessageBox dans ViewCastingPack.xaml.cs</returns>
        public Boolean DeleteCastingPack()
        {
            Boolean boolean = false;
            // On vérifie qu'un pack de casting à bien été sélectionné
            if (SelectedCastingPack != null)
            {
                boolean = true;
                this.Entities.CastingPacks.Remove(SelectedCastingPack);
                // On supprime un pack de casting de la BDD
                this.CastingPacks.Remove(SelectedCastingPack);
                // On sauvegarde les modifications dans la BDD
                this.Entities.SaveChanges();
            }
            else
            {
                MessageBox.Show("Aucun pack de casting a été sélectionné");
            }
            return boolean;

        }

        /// <summary>
        /// Permet de sauvegarder un pack de casting
        /// </summary>
        public void UpdateCastingPack()
        {
            // On sauvegarde les modifications dans la BDD
            this.Entities.SaveChanges();
        }

        #endregion
    }
}
