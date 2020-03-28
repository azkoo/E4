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
    class ViewModelJobType : ViewModelBase
    {
        #region Attributes
        private JobType _selectedJobType;

        private ObservableCollection<JobType> _jobTypes;

        #endregion

        #region Properties
        public JobType SelectedJobType
        {
            get { return _selectedJobType; }
            set { _selectedJobType = value; }
        }

        public ObservableCollection<JobType> JobTypes
        {
            get { return _jobTypes; }
            set { _jobTypes = value; }
        }
        #endregion

        #region Constructor
        public ViewModelJobType()
        {
            JobTypes = new ObservableCollection<JobType>(this.Entities.JobTypes);
        }
        #endregion

        #region Methods

        public void AddJobType(TextBox Name)
        {
            // On crée une nouvelle instance
            JobType jobtype = new JobType();
            // On attribue le texte contenu dans la textbox
            jobtype.Name = Name.Text;
            this.Entities.JobTypes.Add(jobtype);
            // On ajoute le métier à la BDD
            this.JobTypes.Add(jobtype);
            // On sauvegarde les modifications dans la BDD
            this.Entities.SaveChanges();
        }

        public Boolean DeleteJobType()
        {
            Boolean boolean = false;
            // On vérifie qu'une offre à bien été sélectionné
            if (SelectedJobType != null)
            {
                boolean = true;
                this.Entities.JobTypes.Remove(SelectedJobType);
                // On supprime l'offre de la BDD
                this.JobTypes.Remove(SelectedJobType);
                // On sauvegarde les modifications dans la BDD
                this.Entities.SaveChanges();
            }
            else
            {
                MessageBox.Show("Aucun type de métier a été sélectionné");
            }
            return boolean;
        }

        /// <summary>
        /// Permet de sauvegarder un producteur
        /// </summary>
        public void UpdateJobType()
        {
            // On sauvegarde les modifications dans la BDD
            this.Entities.SaveChanges();
        }

        #endregion
    }
}
