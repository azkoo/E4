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
    /// Logique d'interaction pour ViewAnnouncer.xaml
    /// </summary>
    public partial class ViewAnnouncer : UserControl
    {
        public ViewAnnouncer()
        {
            InitializeComponent();

            this.DataContext = new ViewModelViewAnnouncer();
            
        }

        #region Event

        /// <summary>
        /// Permet d'ajouter un producteur en BDD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAddProducteur_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Souhaitez-vous confirmer l'ajout", "Ajout d'un annonceur", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // On ajoute le producteur en BDD
                ((ViewModelViewAnnouncer)this.DataContext).AddProducer(NameProducer, PasswordProducer, EmailProducer, WebsiteProducer, PhoneProducer, FaxProducer, CityProducer, AddressProducer);
                MessageBox.Show("L'utilisateur " + NameProducer.Text + " a bien été ajouté");
            }
            else
            {
                MessageBox.Show("L'utilisateur " + NameProducer.Text + " n'a pas été ajouté");
            }
        }

        /// <summary>
        /// Permet de supprimer un producteur en BDD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDeleteProducteur_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Souhaitez-vous confirmer la suppression", "Suppression d'un annonceur", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // La fonction DeleteProducer retourne un booléen qui vérifie si un producteur a bien été sélectionné
                Boolean boolean = ((ViewModelViewAnnouncer)this.DataContext).DeleteProducer();
                // Si un producteur est sélectionné il est automatiquement supprimé par DeleteProducer
                if (boolean)
                {
                    MessageBox.Show("L'utilisateur a bien été supprimé");
                }
            }
            else
            {
                MessageBox.Show("L'utilisateur n'a pas été supprimé");
            }
        }

        /// <summary>
        /// Permet de sauvegarder un annonceur en BDD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSaveProducteur_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Souhaitez-vous confirmer la sauvegarde", "Confirmation sauvegarde", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // On sauvegarde les modifications en BDD
                ((ViewModelViewAnnouncer)this.DataContext).UpdateProducer();
                MessageBox.Show("L'annonceur " + NameProducer.Text + " a bien été sauvegardé");
            }
            else
            {
                MessageBox.Show("L'annonceur  " + NameProducer.Text + " n'a pas été sauvegardé");
            }
        }

        /// <summary>
        /// Génère un mot de passe aléatoire pour le producteur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonPassword_Click(object sender, RoutedEventArgs e)
        {
        }

        #endregion
    }
}
