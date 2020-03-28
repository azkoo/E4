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
    class ViewModelViewAnnouncer : ViewModelBase
    {
        #region Attributes

        /// <summary>
        /// Liste observable des Annonceurs
        /// </summary>
        private ObservableCollection<Producer> _Producers;

        private Producer _SelectedProducer;

        private ObservableCollection<CastingPack> _castingPacks;

        private CastingPack _selectedCastingPack;





        #endregion

        #region Properties

        /// <summary>
        /// Obtient ou définis les producteurs
        /// </summary>
        public ObservableCollection<Producer> Producers
        {
            get { return _Producers; }
            set { _Producers = value; }
        }

        /// <summary>
        ///  Obtient ou définis les producteurs sélectionné
        /// </summary>
        public Producer SelectedProducer
        {
            get { return _SelectedProducer; }
            set { _SelectedProducer = value; }

        }

        public ObservableCollection<CastingPack> CastingPacks
        {
            get { return _castingPacks; }
            set { _castingPacks = value; }
        }

        public CastingPack SelectedCastingPack
        {
            get { return _selectedCastingPack; }
            set { _selectedCastingPack = value; }
        }
        #endregion

        #region Constructor

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public ViewModelViewAnnouncer()
        {
            Producers = new ObservableCollection<Producer>(this.Entities.Producers);
            CastingPacks = new ObservableCollection<CastingPack>(this.Entities.CastingPacks);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Permet l'ajout d'un producteur en BDD
        /// </summary>
        /// <param name="textBox"></param>
        public void AddProducer(TextBox NameProducer, TextBox PasswordProducer, TextBox EmailProducer, TextBox WebsiteProducer, TextBox PhoneProducer, TextBox FaxProducer, TextBox CityProducer, TextBox AddressProducer)
        {
            //, ComboBox SubscribeProducer
            // On crée une nouvelle instance
            Producer producer = new Producer();
            // On attribue le texte contenu dans la textbox
            producer.Name = NameProducer.Text;
            producer.Password = PasswordProducer.Text;
            producer.Email = EmailProducer.Text;
            producer.Website = WebsiteProducer.Text;
            producer.Phone = PhoneProducer.Text;
            producer.Fax = FaxProducer.Text;
            producer.City = CityProducer.Text;
            producer.Address1 = AddressProducer.Text;

            producer.IdCastingPack = SelectedCastingPack.Id;
            Producers.Where(Producers => Producers.Id.Equals(SelectedProducer.Id));
            //producer.IdCastingPack = SubscribeProducer.GetValue(Id);
            this.Entities.Producers.Add(producer);
            // On ajoute le producteur à la BDD
            this.Producers.Add(producer);
            // On sauvegarde les modifications dans la BDD
            this.Entities.SaveChanges();
        }

        /// <summary>
        /// Permet la suppression d'un producteur en BDD
        /// </summary>
        /// <returns>Retourne un booléen qui permet de contrôler l'affichage de MessageBox dans ViewAnnouncer.xaml.cs</returns>
        public Boolean DeleteProducer()
        {
            Boolean boolean = false;
            // On vérifie qu'un producteur à bien été sélectionné
            if (SelectedProducer != null)
            {
                boolean = true;
                this.Entities.Producers.Remove(SelectedProducer);
                // On supprime le producteur de la BDD
                this.Producers.Remove(SelectedProducer);
                // On sauvegarde les modifications dans la BDD
                this.Entities.SaveChanges();
            }
            else
            {
                MessageBox.Show("Aucun producteur a été sélectionné");
            }
            return boolean;
        }

        /// <summary>
        /// Permet de sauvegarder un producteur
        /// </summary>
        public void UpdateProducer()
        {
            // On sauvegarde les modifications dans la BDD
            this.Entities.SaveChanges();
        }
        #endregion
    }
}
