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
using UtilitairesConsole;

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
            try {
                if(AddCatMed.Text.Length == 0)
                    MessageBox.Show("La catégorie de médicament n'est pas renseignée.", "Erreur !");
                else if (!Saisie.SaisieInt(AddCatMed.Text))
                    MessageBox.Show("La catégorie doit être un nombre entier.", "Erreur !");
                if(AddNomMed.Text.Length == 0)
                    MessageBox.Show("Le nom du médicament n'est pas renseigné.", "Erreur !");

                Medicament m = new Medicament(Int32.Parse(AddCatMed.Text), AddNomMed.Text);
                m.Create();
                ApplicationData.listeMedicaments.Add(m);
                lvMedicament.Items.Refresh();
            }
            catch (Exception) {
                MessageBox.Show("Un ou plusieurs champs ne sont pas renseignés, ou mal renseignés.", "Erreur !");
            }
        }

        private void lvMedicament_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lvMedicament.Items.Refresh();
        }

        private void SupprimerMedicament(object sender, RoutedEventArgs e) {
            try {
                if (!Saisie.SaisieInt(DelMedText.Text)) {
                    MessageBox.Show("L'ID du médicament doit être un nombre entier.", "Erreur !");
                }
                else {
                    Medicament m = new Medicament();
                    m.Idmedicament = Int32.Parse(DelMedText.Text);

                    foreach (Medicament med in ApplicationData.listeMedicaments) {
                        if (m.Idmedicament == med.Idmedicament) {
                            ApplicationData.listeMedicaments.Remove(med);
                            m.Delete(med.Idmedicament);
                            break;
                        }
                    }
                }
            }
            catch (Exception) {
                MessageBox.Show("Le champs n'est pas renseigné, ou mal renseigné.", "Erreur !");
            }

            //ApplicationData.listeMedicaments.Remove(m);
            lvMedicament.Items.Refresh();
        }

        private void UpdateMedicament(object sender, RoutedEventArgs e)
        {
            try {
                if (UpdateMedText.Text.Length == 0)
                    MessageBox.Show("L'ID du médicament doit être renseigné.", "Erreur !");
                else if (!Saisie.SaisieInt(UpdateMedText.Text))
                    MessageBox.Show("L'ID du médicament doit être un nombre entier.", "Erreur !");
                if (UpdateNameMedText.Text.Length == 0)
                    MessageBox.Show("Le nom du médicament doit être renseigné.", "Erreur !");
                Medicament m = new Medicament(Int32.Parse(UpdateMedText.Text), UpdateNameMedText.Text);
                foreach (Medicament med in ApplicationData.listeMedicaments) {
                    if (m.Idmedicament == med.Idmedicament) {
                        m.Update(Int32.Parse(UpdateMedText.Text), UpdateNameMedText.Text);
                        MessageBox.Show($"{m.NomMedicament}");
                        break;
                    }
                }
            }
            catch (Exception) {
                MessageBox.Show("Un ou plusieurs champs ne sont pas renseignés, ou mal renseignés.", "Erreur !");
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
            try {
                if (AddNomMaladie.Text.Length == 0)
                    MessageBox.Show("Le nom de la maladie n'est pas renseigné.", "Erreur !");
                else {
                    Maladie m = new Maladie(AddNomMaladie.Text);
                    m.Create();
                    ApplicationData.listeMaladies.Add(m);
                    lvMaladie.Items.Refresh();
                }
            }
            catch (Exception) {
                MessageBox.Show("Le champs n'est pas renseigné, ou mal renseigné.", "Erreur !");
            }
        }
        private void DeleteMaladie(object sender, RoutedEventArgs e)
        {
            try {
                if (DelMaladieText.Text.Length == 0)
                    MessageBox.Show("L'ID de la maladie n'est pas renseigné.", "Erreur !");
                else if (!Saisie.SaisieInt(DelMaladieText.Text))
                    MessageBox.Show("L'ID de la maladie doit être un nombre entier.", "Erreur !");
                else {
                    Maladie m = new Maladie();
                    m.Delete(Int32.Parse(DelMaladieText.Text));
                    ApplicationData.listeMaladies.Remove(m);
                    lvMaladie.Items.Refresh();
                }
            }
            catch (Exception) {
                MessageBox.Show("Le champs n'est pas renseigné, ou mal renseigné.", "Erreur !");
            }
        }

        private void Gerer(object sender, RoutedEventArgs e) {
            Autorisation autorisation = new Autorisation();
            autorisation.ShowDialog();
        }
    }
}