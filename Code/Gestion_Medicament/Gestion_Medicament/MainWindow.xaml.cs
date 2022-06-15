using System;
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
            //lvDate.ItemsSource = ApplicationData.listeDates;
            lvAutorisation.ItemsSource = ApplicationData.listeAutorisations;
            this.DataContext = this;
        }

        private void AjouterMedicament(object sender, RoutedEventArgs e)
        {
            Medicament m = new Medicament(Int32.Parse(AddCatMed.Text), AddNomMed.Text);
            m.Create();
            ApplicationData.listeMedicaments.Add(m);
            lvMedicament.Items.Refresh();
        }

        private void lvMedicament_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lvMedicament.Items.Refresh();
        }

        private void SupprimerMedicament(object sender, RoutedEventArgs e) {
            Medicament m = new Medicament();
            m.Delete(Int32.Parse(DelMedText.Text));
            ApplicationData.listeMedicaments.Remove(m);
            lvMedicament.Items.Refresh();
        }

        private void ViderMedicament(object sender, RoutedEventArgs e) {
            Medicament m = new Medicament();
            m.Trunc();
            lvMedicament.Items.Refresh();
        }

        private void AjouterMaladie(object sender, RoutedEventArgs e)
        {
            Maladie m = new Maladie(AddNomMaladie.Text);
            m.Create();
            ApplicationData.listeMaladies.Add(m);
            lvMaladie.Items.Refresh();
        }
    }
}
