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
    /// Logique d'interaction pour ViewJob.xaml
    /// </summary>
    public partial class ViewJob : UserControl
    {
        public ViewJob()
        {
            InitializeComponent();

            this.DataContext = new ViewModelJob();
        }

        #region Event

        /// <summary>
        /// Permet de sauvegarder un métier en BDD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddJob_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Souhaitez-vous confirmer l'ajout", "Ajout d'un métier", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // On ajoute le producteur en BDD
                ((ViewModelJob)this.DataContext).AddJob(JobName);
                MessageBox.Show("Le métier " + JobName.Text + " a bien été ajouté");
            }
            else
            {
                MessageBox.Show("Le métier " + JobName.Text + " n'a pas été ajouté");
            }
        }

        /// <summary>
        /// Permet de supprimer un métier en BDD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteJob_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Souhaitez-vous confirmer la suppression", "Suppression d'un métier", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // La fonction DeleteJob retourne un booléen qui vérifie si un métier a bien été sélectionné
                Boolean boolean = ((ViewModelJob)this.DataContext).DeleteJob();
                // Si un métier est sélectionné il est automatiquement supprimé par DeleteJob
                if (boolean)
                {
                    MessageBox.Show("Le métier a bien été supprimé");
                }
            }
            else
            {
                MessageBox.Show("Le métier n'a pas été supprimé");
            }
        }

        /// <summary>
        /// Permet d'ajouter un métier en BDD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveJob_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Souhaitez-vous confirmer la sauvegarde", "Confirmation sauvegarde", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // On sauvegarde les modifications en BDD
                ((ViewModelJob)this.DataContext).UpdateJob();
                MessageBox.Show("Le métier " + JobName.Text + " a bien été sauvegardé");
            }
            else
            {
                MessageBox.Show("Le métier  " + JobName.Text + " n'a pas été sauvegardé");
            }
        }
        #endregion
    }
}
