﻿using MegaCastingWPF.Views;
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

namespace MegaCastingWPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Event

        /// <summary>
        /// Permet un retour à la page d'accueil
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonHome_Click(object sender, RoutedEventArgs e)
        {
            this.CleanPanel();
            ViewMain viewmain = new ViewMain();
            this.dockPanelMain.Children.Add(viewmain);
        }

        /// <summary>
        /// Permet de quitter le client lourd
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Action d'ouverture du panel des annonceurs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonAnnouncer_Click(object sender, RoutedEventArgs e)
        {
            this.CleanPanel();
            ViewAnnouncer viewAnnouncer = new ViewAnnouncer();
            this.dockPanelMain.Children.Add(viewAnnouncer);
        }

        /// <summary>
        /// Action d'ouverture du panel des offres
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonOffer_Click(object sender, RoutedEventArgs e)
        {
            this.CleanPanel();
            ViewOffer viewOffer = new ViewOffer();
            this.dockPanelMain.Children.Add(viewOffer);
        }

        /// <summary>
        /// Action d'ouverture du panel des types de contrat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonContractType_Click(object sender, RoutedEventArgs e)
        {
            this.CleanPanel();
            ViewContractType viewContractType = new ViewContractType();
            this.dockPanelMain.Children.Add(viewContractType);
        }

        /// <summary>
        ///Action d'ouverture du panel des métiers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonJob_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// Permet de nettoyer le dockPanelMain 
        /// </summary>
        private void CleanPanel()
        {
            this.dockPanelMain.Children.Clear();
        }

        #endregion
    }
}