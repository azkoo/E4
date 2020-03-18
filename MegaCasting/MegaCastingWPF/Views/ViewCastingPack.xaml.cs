using MegaCastingWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MegaCastingWPF.Views
{
    /// <summary>
    /// Logique d'interaction pour ViewCastingPack.xaml
    /// </summary>
    public partial class ViewCastingPack : UserControl
    {
        public ViewCastingPack()
        {
            InitializeComponent();
            this.DataContext = new ViewModelCastingPack();
        }

        #region Event

        /// <summary>
        /// Permet de sauvegarder un pack de metier en BDD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Souhaitez-vous confirmer l'ajout", "Ajout d'un annonceur", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // On ajoute le producteur en BDD
                ((ViewModelCastingPack)this.DataContext).AddCastingPack(CastingPackName, CastingPackSize);
                MessageBox.Show("Le pack " + CastingPackName + " a bien été ajouté");
            }
            else
            {
                MessageBox.Show("Le pack " + CastingPackName + " n'a pas été ajouté");
            }

        }

        /// <summary>
        /// Permet de supprimer un pack de casting en BDD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Souhaitez-vous confirmer la suppression", "Suppression d'un pack de casting", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // La fonction DeleteCastingPack retourne un booléen qui vérifie si un pack de casting a bien été sélectionné
                Boolean boolean = ((ViewModelCastingPack)this.DataContext).DeleteCastingPack();
                // Si un pack de casting est sélectionné il est automatiquement supprimé par DeleteCastingPack
                if (boolean)
                {
                    MessageBox.Show("Le pack de casting a bien été supprimé");
                }
            }
            else
            {
                MessageBox.Show("Le pack de casting n'a pas été supprimé");
            }
        }

        /// <summary>
        /// Permet d'ajouter un pack de casting en BDD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Souhaitez-vous confirmer la sauvegarde", "Confirmation sauvegarde", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // On sauvegarde les modifications en BDD
                ((ViewModelCastingPack)this.DataContext).UpdateCastingPack();
                MessageBox.Show("Le pack de casting " + CastingPackName.Text + " a bien été sauvegardé");
            }
            else
            {
                MessageBox.Show("Le type de contrat  " + CastingPackName.Text + " n'a pas été sauvegardé");
            }
        }

        #endregion
    }
}
