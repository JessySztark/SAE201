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
            // ComboCatMed.ItemsSource = typeof(CategorieMedicament).GetProperties();
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
            m.Idmedicament = Int32.Parse(DelMedText.Text);

            foreach (Medicament med in ApplicationData.listeMedicaments)
            {
                if (m.Idmedicament == med.Idmedicament)
                {
                    ApplicationData.listeMedicaments.Remove(med);
                    m.Delete(med.Idmedicament);
                    break;
                }
            }

            //ApplicationData.listeMedicaments.Remove(m);
            lvMedicament.Items.Refresh();
        }

        private void UpdateMedicament(object sender, RoutedEventArgs e)
        {
            Medicament m = new Medicament(Int32.Parse(UpdateMedText.Text), UpdateNameMedText.Text);
            foreach (Medicament med in ApplicationData.listeMedicaments)
            {
                if (m.Idmedicament == med.Idmedicament)
                {

                    m.Update(Int32.Parse(UpdateMedText.Text), UpdateNameMedText.Text);
                    MessageBox.Show($"{m.NomMedicament}");
                    break;
                }
            }
            
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
        private void DeleteMaladie(object sender, RoutedEventArgs e)
        {
            Maladie m = new Maladie();
            m.Delete(Int32.Parse(DelMaladieText.Text));
            ApplicationData.listeMaladies.Remove(m);
            lvMaladie.Items.Refresh();
        }

        private void Gerer(object sender, RoutedEventArgs e) {
            Autorisation autorisation = new Autorisation();
            autorisation.ShowDialog();
        }

        private void SupprimerCatMedicament(object sender, RoutedEventArgs e)
        {
            CategorieMedicament m = new CategorieMedicament();
            m.IdCategorie = Int32.Parse(DelMedText.Text);

            foreach (CategorieMedicament med in ApplicationData.listeCategories)
            {
                if (m.IdCategorie == med.IdCategorie)
                {
                    ApplicationData.listeCategories.Remove(med);
                    m.Delete(med.IdCategorie);
                    break;
                }
            }

            //ApplicationData.listeMedicaments.Remove(m);
            lvCategorie.Items.Refresh();
        }
    }
}