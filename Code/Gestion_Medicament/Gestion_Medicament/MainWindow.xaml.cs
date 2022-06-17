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
        /// <summary>
        /// Initialisation des composant de la page xaml
        /// </summary>
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

        /// <summary>
        /// Méthode permettant d'ajouter un médicament
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void AjouterMedicament(object sender, RoutedEventArgs e)
        {
            try {
                if(AddCatMedText.Text.Length == 0)
                    MessageBox.Show("La catégorie de médicament n'est pas renseignée.", "Erreur !");
                else if (!Saisie.SaisieInt(AddCatMedText.Text))
                    MessageBox.Show("La catégorie doit être un nombre entier.", "Erreur !");
                if(AddNomMedText.Text.Length == 0)
                    MessageBox.Show("Le nom du médicament n'est pas renseigné.", "Erreur !");

                Medicament m = new Medicament(Int32.Parse(AddCatMedText.Text), AddNomMedText.Text);
                m.Create();
                ApplicationData.listeMedicaments.Add(m);
                lvMedicament.Items.Refresh();
            }
            catch (Exception) {
                MessageBox.Show("Un ou plusieurs champs ne sont pas renseignés, ou mal renseignés.", "Erreur !");
            }
        }
        /// <summary>
        /// Méthode permettant de rafraichir l'affichage des données de médicament lorsque l'on clique sur autre chose 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void lvMedicament_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lvMedicament.Items.Refresh();
        }
        /// <summary>
        /// Méthode permettant de supprimer un médicament de la base de données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

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

        /// <summary>
        /// Méthode permettant de modifier un médicament
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void UpdateMedicament(object sender, RoutedEventArgs e)
        {
            try {
                if (UpdateIDMedText.Text.Length == 0)
                    MessageBox.Show("L'ID du médicament doit être renseigné.", "Erreur !");
                else if (!Saisie.SaisieInt(UpdateIDMedText.Text))
                    MessageBox.Show("L'ID du médicament doit être un nombre entier.", "Erreur !");
                if (UpdateNameMedText.Text.Length == 0)
                    MessageBox.Show("Le nom du médicament doit être renseigné.", "Erreur !");
                Medicament m = new Medicament(Int32.Parse(UpdateIDMedText.Text), UpdateNameMedText.Text);
                foreach (Medicament med in ApplicationData.listeMedicaments) {
                    if (m.Idmedicament == med.Idmedicament) {
                        m.Update(Int32.Parse(UpdateIDMedText.Text), UpdateNameMedText.Text);
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

        /// <summary>
        /// Méthode permettant de remettre les Médicaments a vide
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void ViderMedicament(object sender, RoutedEventArgs e) {
            Medicament m = new Medicament();
            m.Trunc();
            lvMedicament.Items.Refresh();
        }

        /// <summary>
        /// Méthode permettant d'ajouter une maladie à la base de données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

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

        /// <summary>
        /// Méthode permettant de supprimer une maladie de la base de données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

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

        /// <summary>
        /// Méthode permettant d'afficher la page pour gerer les autorisations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void Gerer(object sender, RoutedEventArgs e) {
            Autorisation autorisation = new Autorisation();
            autorisation.ShowDialog();
        }

        /// <summary>
        /// Méthode permettant de supprimer une catégorie de médicament
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SupprimerCatMedicament(object sender, RoutedEventArgs e) {
            CategorieMedicament m = new CategorieMedicament();
            m.IdCategorie = Int32.Parse(DelMedText.Text);

            foreach (CategorieMedicament med in ApplicationData.listeCategories) {
                if (m.IdCategorie == med.IdCategorie) {
                    ApplicationData.listeCategories.Remove(med);
                    m.Delete(med.IdCategorie);
                    break;
                }
            }

            //ApplicationData.listeMedicaments.Remove(m);
            lvCategorie.Items.Refresh();
        }
        /// <summary>
        /// Permet de supprimer une autorisation 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SupprimerAutorisation(object sender, RoutedEventArgs e) {
            Est_autorisé m = new Est_autorisé();
            //m.IdMedicament = idmed.Text;
            foreach (Est_autorisé med in ApplicationData.listeAutorisations) {
                if (m.IdMedicament == med.IdMedicament) ;
                {
                    ApplicationData.listeAutorisations.Remove(med);
                    m.Delete(med.IdMedicament);
                    break;
                }
            }
            lvAutorisation.Items.Refresh();
        }
        /// <summary>
        /// Permet d'ajouter une autorisation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AjouterAutorisation(object sender, RoutedEventArgs e) {
            /*Est_autorisé m = new Est_autorisé(idmed.Text, idmal.Text, date.Text, com.Text);
            m.Create();
            ApplicationData.listeAutorisations.Add(m);
            lvMaladie.Items.Refresh();*/
        }
    }
}