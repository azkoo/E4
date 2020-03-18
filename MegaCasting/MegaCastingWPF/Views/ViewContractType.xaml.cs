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
    /// Logique d'interaction pour ViewContractType.xaml
    /// </summary>
    public partial class ViewContractType : UserControl
    {
        public ViewContractType()
        {
            InitializeComponent();

            this.DataContext = new ViewModelContractType();
        }

        #region Event

        /// <summary>
        /// Permet d'ajouter un type de contrat en BDD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Souhaitez-vous confirmer l'ajout", "Ajout d'un type de contrat ", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // On ajoute le type de contrat en BDD
                ((ViewModelContractType)this.DataContext).AddContractType(NameContractType);
                MessageBox.Show("Le type de contrat " + NameContractType.Text + " a bien été ajouté");
            }
            else
            {
                MessageBox.Show("Le type de contrat  " + NameContractType.Text + " n'a pas été ajouté");
            }
        }

        /// <summary>
        /// Permet de supprimer un type de contrat en BDD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Souhaitez-vous confirmer la suppression", "Suppression d'un type de contrat", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // La fonction DeleteContractType retourne un booléen qui vérifie si un type de contrat a bien été sélectionné
                Boolean boolean = ((ViewModelContractType)this.DataContext).DeleteContractType();
                // Si un type de contrat est sélectionné il est automatiquement supprimé par DeleteContractType
                if (boolean)
                {
                    MessageBox.Show("Le type de contrat a bien été supprimé");
                }
            }
            else
            {
                MessageBox.Show("Le type de contrat n'a pas été supprimé");
            }
        }

        /// <summary>
        /// Permet de mettre à jour un producteur en BDD
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Souhaitez-vous confirmer la sauvegarde", "Confirmation sauvegarde", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // On sauvegarde les modifications en BDD
                ((ViewModelContractType)this.DataContext).UpdateContractType();
                MessageBox.Show("Le type de contrat " + NameContractType.Text + " a bien été sauvegardé");
            }
            else
            {
                MessageBox.Show("Le type de contrat  " + NameContractType.Text + " n'a pas été sauvegardé");
            }
        }

        #endregion


    }
}
