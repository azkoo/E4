using MegaCasting.DBLib;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace MegaCastingWPF.ViewModels
{
    class ViewModelOffer : ViewModelBase
    {
        #region Attributes

        /// <summary>
        /// Liste observable des offres
        /// </summary>
        private ObservableCollection<Offer> _Offers;

        private Offer _SelectedOffer;

        private ObservableCollection<ContractType> _contractTypes;

        private ContractType _selectedContractType;

        private ObservableCollection<Job> _jobs;

        private Job _selectedJob;

        private ObservableCollection<Producer> _Producers;

        private Producer _selectedProducer;
        #endregion

        #region Properties

        /// <summary>
        /// Obtient ou définis les offres
        /// </summary>
        public ObservableCollection<Offer> Offers
        {
            get { return _Offers; }
            set { _Offers = value; }
        }

        /// <summary>
        ///  Obtient ou définis les offres sélectionné
        /// </summary>
        public Offer SelectedOffer
        {
            get { return _SelectedOffer; }
            set { _SelectedOffer = value; }

        }

        public ObservableCollection<ContractType> ContractTypes
        {
            get { return _contractTypes; }
            set { _contractTypes = value; }
        }

        public ContractType SelectedContractType
        {
            get { return _selectedContractType; }
            set { _selectedContractType = value; }
        }

        public ObservableCollection<Job> Jobs
        {
            get { return _jobs; }
            set { _jobs = value; }
        }

        public Job SelectedJob
        {
            get { return _selectedJob; }
            set { _selectedJob = value; }
        }

        public Producer SelectedProducer
        {
            get { return _selectedProducer; }
            set { _selectedProducer = value; }
        }

        public ObservableCollection<Producer> Producers
        {
            get { return _Producers; }
            set { _Producers = value; }
        }
        #endregion

        #region Constructor

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public ViewModelOffer()
        {
            Offers = new ObservableCollection<Offer>(this.Entities.Offers);
            ContractTypes = new ObservableCollection<ContractType>(this.Entities.ContractTypes);
            Jobs = new ObservableCollection<Job>(this.Entities.Jobs);
            Producers = new ObservableCollection<Producer>(this.Entities.Producers);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Permet l'ajout d'une offre en BDD
        /// </summary>
        /// <param name="textBox"></param>
        public void AddOffer(TextBox NameOffer, TextBox ReferenceOffer, TextBox DescriptionOffer, TextBox PeriodOffer, TextBox PostNumberOffer, DatePicker datePicker, Image TB_DiagResult)
        {

            try
            {
                //, ComboBox ...
                // On crée une nouvelle instance
                Offer offer = new Offer();
                // On attribue le texte contenu dans la textbox
                offer.Name = NameOffer.Text;
                offer.Reference = ReferenceOffer.Text;
                offer.Description = DescriptionOffer.Text;

                bool tp = Int32.TryParse(PostNumberOffer.Text, out Int32 Postnumber);
                if (tp)
                {
                    offer.PostNumber = Postnumber;
                }
                offer.Period = PeriodOffer.Text;
                offer.ContractStart = datePicker.SelectedDate;
                offer.PublicationStart = DateTime.Now;
                offer.Picture = Convertimg(TB_DiagResult.Source as BitmapImage);

                offer.IdJob = SelectedJob.Id;
                Offers.Where(Offers => Offers.Id.Equals(SelectedOffer.Id));

                offer.IdContractType = SelectedContractType.Id;
                Offers.Where(Offers => Offers.Id.Equals(SelectedOffer.Id));

                offer.IdProducer = SelectedProducer.Id;
                Offers.Where(Offers => Offers.Id.Equals(SelectedOffer.Id));

                this.Entities.Offers.Add(offer);
                // On ajoute le producteur à la BDD
                this.Offers.Add(offer);
                // On sauvegarde les modifications dans la BDD
                this.Entities.SaveChanges();
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            
        }

        /// <summary>
        /// Permet la suppression d'une offre en BDD
        /// </summary>
        /// <returns>Retourne un booléen qui permet de contrôler l'affichage de MessageBox dans ViewOffer.xaml.cs</returns>
        public Boolean DeleteOffer()
        {
            Boolean boolean = false;
            // On vérifie qu'une offre à bien été sélectionné
            if (SelectedOffer != null)
            {
                boolean = true;
                this.Entities.Offers.Remove(SelectedOffer);
                // On supprime l'offre de la BDD
                this.Offers.Remove(SelectedOffer);
                // On sauvegarde les modifications dans la BDD
                this.Entities.SaveChanges();
            }
            else
            {
                MessageBox.Show("Aucune offre a été sélectionné");
            }
            return boolean;
        }

        /// <summary>
        /// Permet de sauvegarder un producteur
        /// </summary>
        public void UpdateOffer()
        {
            // On sauvegarde les modifications dans la BDD
            this.Entities.SaveChanges();
        }

        public void AfficherFileName( Image TB_DiagResult)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Title = "image selection";
            openFileDialog1.Filter = "JPG(.jpg)|*.jpg|PNG(.png)|*.png|JPEG(.jpeg)|*.jpeg";

            if (openFileDialog1.ShowDialog() == true)
            {
                TB_DiagResult.Source = new BitmapImage(new Uri(openFileDialog1.FileName));
            }

            //byte[] bytes;
            
            //if (openFileDialog1.ShowDialog() == true)
            //{
            //    string fileName = openFileDialog1.FileName;
            //     bytes = File.ReadAllBytes(fileName);
            //    string contentType = "";
            //    //Set the contenttype based on File Extension

            //    switch (System.IO.Path.GetExtension(fileName))
            //    {
            //        case ".jpg":
            //            contentType = "image/jpeg";
            //            break;
            //        case ".png":
            //            contentType = "image/png";
            //            break;
            //        case ".gif":
            //            contentType = "image/gif";
            //            break;
            //        case ".bmp":
            //            contentType = "image/bmp";
            //            break;
            //    }
            //    TB_DiagResult.Source = bytes;
            //}


        }

        public byte[] Convertimg(BitmapImage imageC)
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            return memStream.ToArray();
        }

        #endregion
    }
}
