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
    class ViewModelContractType : ViewModelBase
    {
        #region Attribute

        /// <summary>
        /// Liste observable des types de contrats
        /// </summary>
        private ObservableCollection<ContractType> _ContractTypes;

        private ContractType _SelectedContractType;

        #endregion

        #region Properties

        /// <summary>
        /// Obtient ou définis le type de contrat
        /// </summary>
        public ObservableCollection<ContractType> ContractTypes
        {
            get { return _ContractTypes; }
            set { _ContractTypes = value; }
        }

        /// <summary>
        /// Obtient ou définis le type de contrat sélectionné
        /// </summary>
        public ContractType SelectedContractType
        {
            get { return _SelectedContractType; }
            set { _SelectedContractType = value; }

        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public ViewModelContractType()
        {
            ContractTypes = new ObservableCollection<ContractType>(this.Entities.ContractTypes);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Permet d'ajouter un type de contrat
        /// </summary>
        /// <param name="textBox"></param>
        public void AddContractType(TextBox textBox)
        {
            // On crée une nouvelle instance
            ContractType contractType = new ContractType();
            // On attribue le texte contenu dans la textbox
            contractType.Name = textBox.Text;
            this.Entities.ContractTypes.Add(contractType);
            // On ajoute le type de contrat à la BDD
            this.ContractTypes.Add(contractType);
            // On sauvegarde les modifications dans la BDD
            this.Entities.SaveChanges();
        }

        /// <summary>
        /// Permet de supprimer un type de contrat
        /// </summary>
        /// <returns>Retourne un booléen qui permet de contrôler l'affichage de MessageBox dans ViewContractType.xaml.cs</returns>
        public Boolean DeleteContractType()
        {
            Boolean boolean = false;
            // On vérifie qu'un type de contrat à bien été sélectionné
            if (SelectedContractType != null)
            {
                boolean = true;
                this.Entities.ContractTypes.Remove(SelectedContractType);
                // On supprime le type de contrat de la BDD
                this.ContractTypes.Remove(SelectedContractType);
                // On sauvegarde les modifications dans la BDD
                this.Entities.SaveChanges();
            }
            else
            {
                MessageBox.Show("Aucun type de contrat a été sélectionné");
            }
            return boolean;

        }

        /// <summary>
        /// Permet de sauvegarder un type de contrat
        /// </summary>
        public void UpdateContractType()
        {
            // On sauvegarde les modifications dans la BDD
            this.Entities.SaveChanges();
        }

        #endregion
    }
}
