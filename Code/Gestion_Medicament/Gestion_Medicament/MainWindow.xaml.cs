﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace Gestion_Medicament
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ApplicationData.loadApplicationData();
            lvMaladie.ItemsSource = ApplicationData.listeMaladies;
            lvCategorie.ItemsSource = ApplicationData.listeCategories;
            lvMedicament.ItemsSource = ApplicationData.listeMedicaments;
            lvDate.ItemsSource = ApplicationData.listeDates;
            lvAutorisation.ItemsSource = ApplicationData.listeAutorisations;
            this.DataContext = this;
        }

        private void AjouterMedicament(object sender, RoutedEventArgs e)
        {
            Medicament m = new Medicament(Int32.Parse(AddIDCatMedicament.Text), AddNomMedicament.Text);
            m.AddMedicament();
            lvMedicament.Items.Refresh();
        }

        private void lvMedicament_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lvMedicament.Items.Refresh();
        }

    }
}
