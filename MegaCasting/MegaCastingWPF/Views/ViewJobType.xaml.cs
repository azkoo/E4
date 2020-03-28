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
    /// Logique d'interaction pour ViewJobType.xaml
    /// </summary>
    public partial class ViewJobType : UserControl
    {
        public ViewJobType()
        {
            InitializeComponent();
            this.DataContext = new ViewModelJobType();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Souhaitez-vous confirmer l'ajout", "Ajout d'un type de métier", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // On ajoute le producteur en BDD
                ((ViewModelJobType)this.DataContext).AddJobType(NameJobType);
                MessageBox.Show("Le type de métier " + NameJobType.Text + " a bien été ajouté");
            }
            else
            {
                MessageBox.Show("Le type de métier " + NameJobType.Text + " n'a pas été ajouté");
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Souhaitez-vous confirmer la suppression", "Suppression d'un métier", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // La fonction DeleteJob retourne un booléen qui vérifie si un métier a bien été sélectionné
                Boolean boolean = ((ViewModelJobType)this.DataContext).DeleteJobType();
                // Si un métier est sélectionné il est automatiquement supprimé par DeleteJob
                if (boolean)
                {
                    MessageBox.Show("Le type de métier a bien été supprimé");
                }
            }
            else
            {
                MessageBox.Show("Le type de métier n'a pas été supprimé");
            }
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Souhaitez-vous confirmer la sauvegarde", "Confirmation sauvegarde", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                // On sauvegarde les modifications en BDD
                ((ViewModelJobType)this.DataContext).UpdateJobType();
                MessageBox.Show("Le type de métier " + NameJobType.Text + " a bien été sauvegardé");
            }
            else
            {
                MessageBox.Show("Le type de métier  " + NameJobType.Text + " n'a pas été sauvegardé");
            }
        }
    }
}
