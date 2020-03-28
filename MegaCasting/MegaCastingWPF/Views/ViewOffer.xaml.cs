using MegaCastingWPF.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Logique d'interaction pour ViewOffer.xaml
    /// </summary>
    public partial class ViewOffer : UserControl
    {
        public ViewOffer()
        {
            InitializeComponent();

            this.DataContext = new ViewModelOffer();
        }

        #region Event

        /// <summary>
        /// Permet d'ajouter une offre en BDD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddOffer_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Souhaitez-vous confirmer l'ajout", "Ajout d'une offre", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // On ajoute l'offre en BDD
                ((ViewModelOffer)this.DataContext).AddOffer(NameOffer, ReferenceOffer, DescriptionOffer, PeriodOffer, PostNumberOffer, DatePickerContractStart, TB_DiagResult);
                MessageBox.Show("L'offre " + NameOffer.Text + " a bien été ajouté");
            }
            else
            {
                MessageBox.Show("L'offre " + NameOffer.Text + " n'a pas été ajouté");
            }
        }

        /// <summary>
        /// Permet de supprimer une offre en BDD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteOffer_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Souhaitez-vous confirmer la suppression", "Suppression d'une offre", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // La fonction DeleteOffer retourne un booléen qui vérifie si une offre a bien été sélectionné
                Boolean boolean = ((ViewModelOffer)this.DataContext).DeleteOffer();
                // Si un producteur est sélectionné il est automatiquement supprimé par DeleteOffer
                if (boolean)
                {
                    MessageBox.Show("L'offre a bien été supprimé");
                }
            }
            else
            {
                MessageBox.Show("L'offre n'a pas été supprimé");
            }
        }

        /// <summary>
        /// Permet de sauvegarder une offre en BDD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveOffer_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Souhaitez-vous confirmer la sauvegarde", "Confirmation sauvegarde", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // On sauvegarde les modifications en BDD
                ((ViewModelOffer)this.DataContext).UpdateOffer();
                MessageBox.Show("L'offre " + NameOffer.Text + " a bien été sauvegardé");
            }
            else
            {
                MessageBox.Show("L'offre  " + NameOffer.Text + " n'a pas été sauvegardé");
            }
        }

        private void BTN_ParcourirImage_Click(object sender, RoutedEventArgs e)
        {
           ((ViewModelOffer)this.DataContext).AfficherFileName(TB_DiagResult);

        }
        #endregion


    }
}
