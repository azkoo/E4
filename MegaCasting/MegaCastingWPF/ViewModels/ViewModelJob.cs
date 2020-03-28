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
    class ViewModelJob : ViewModelBase
    {
        #region Attribute

        /// <summary>
        /// Liste observable des métiers
        /// </summary>
        private ObservableCollection<Job> _Jobs;

        private Job _SelectedJob;

        private ObservableCollection<JobType> _jobTypes;

        private JobType _selectedJobType;

        #endregion

        #region Properties

        /// <summary>
        /// Obtient ou définis le métier
        /// </summary>
        public ObservableCollection<Job> Jobs
        {
            get { return _Jobs; }
            set { _Jobs = value; }
        }

        /// <summary>
        /// Obtient ou définis le métier sélectionné
        /// </summary>
        public Job SelectedJob
        {
            get { return _SelectedJob; }
            set { _SelectedJob = value; }

        }

        public ObservableCollection<JobType> JobTypes
        {
            get { return _jobTypes; }
            set { _jobTypes = value; }
        }


        public JobType SelectedJobType
        {
            get { return _selectedJobType; }
            set { _selectedJobType = value; }
        }
        #endregion

        #region Constructor

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public ViewModelJob()
        {
            Jobs = new ObservableCollection<Job>(this.Entities.Jobs);
            JobTypes = new ObservableCollection<JobType>(this.Entities.JobTypes);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Permet d'ajouter un métier
        /// </summary>
        /// <param name="textBox"></param>
        public void AddJob(TextBox textBox)
        {
            // On crée une nouvelle instance
            Job job = new Job();
            // On attribue le texte contenu dans la textbox
            job.Name = textBox.Text;
            job.IdJobType = SelectedJobType.Id;
            Jobs.Where(Jobs => Jobs.Id.Equals(SelectedJob.Id));
            this.Entities.Jobs.Add(job);
            // On ajoute le métier à la BDD
            this.Jobs.Add(job);
            // On sauvegarde les modifications dans la BDD
            this.Entities.SaveChanges();
        }

        /// <summary>
        /// Permet de supprimer un métier
        /// </summary>
        /// <returns>Retourne un booléen qui permet de contrôler l'affichage de MessageBox dans ViewJob.xaml.cs</returns>
        public Boolean DeleteJob()
        {
            Boolean boolean = false;
            // On vérifie qu'un métier à bien été sélectionné
            if (SelectedJob != null)
            {
                boolean = true;
                this.Entities.Jobs.Remove(SelectedJob);
                // On supprime le métier de la BDD
                this.Jobs.Remove(SelectedJob);
                // On sauvegarde les modifications dans la BDD
                this.Entities.SaveChanges();
            }
            else
            {
                MessageBox.Show("Aucun métier a été sélectionné");
            }
            return boolean;

        }

        /// <summary>
        /// Permet de sauvegarder un métier
        /// </summary>
        public void UpdateJob()
        {
            // On sauvegarde les modifications dans la BDD
            this.Entities.SaveChanges();
        }

        #endregion
    }
}
