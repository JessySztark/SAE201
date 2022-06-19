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

namespace Gestion_Medicament {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private int lastIndexMedicament;
        private int lastIndexMaladie;
        private int lastIndexCategorie;

        /// <summary>
        /// Initialisation des composant de la page xaml
        /// </summary>
        public MainWindow() {
            InitializeComponent();
            ApplicationData.loadApplicationData();
            lvMaladie.ItemsSource = ApplicationData.listeMaladies;
            lvCategorie.ItemsSource = ApplicationData.listeCategories;
            lvMedicament.ItemsSource = ApplicationData.listeMedicaments;
            cbCategorie.ItemsSource = ApplicationData.listeCategories;
            //lvDate.ItemsSource = ApplicationData.listeDates;
            lvAutorisation.ItemsSource = ApplicationData.listeAutorisations;
            lastIndexMedicament = FindLastMedInList(ApplicationData.listeMedicaments);
            lastIndexCategorie = FindLastCatInList(ApplicationData.listeCategories);
            lastIndexMaladie = FindLastMalInList(ApplicationData.listeMaladies);
            this.DataContext = this;
        }

        /// <summary>
        /// Méthode permettant d'ajouter un médicament
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void AjouterMedicament(object sender, RoutedEventArgs e) {
            try {
                if (cbCategorie.SelectedItem is null)
                    MessageBox.Show("La catégorie de médicament n'est pas renseignée.", "Erreur !");
                if (AddNomMedText.Text.Length == 0)
                    MessageBox.Show("Le nom du médicament n'est pas renseigné.", "Erreur !");
                lastIndexMedicament++;
                Medicament m = new Medicament(lastIndexMedicament, ((CategorieMedicament)cbCategorie.SelectedItem).IdCategorie, AddNomMedText.Text);
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

        private void lvMedicament_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            lvMedicament.Items.Refresh();
        }

        /// <summary>
        /// Méthode permettant de modifier un médicament
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void UpdateMedicament(object sender, RoutedEventArgs e) {
            try {
                if (UpdateIDMedText.Text.Length == 0)
                    MessageBox.Show("L'ID du médicament doit être renseigné.", "Erreur !");
                else if (!Saisie.SaisieInt(UpdateIDMedText.Text))
                    MessageBox.Show("L'ID du médicament doit être un nombre entier.", "Erreur !");
                if (UpdateNameMedText.Text.Length == 0)
                    MessageBox.Show("Le nom du médicament doit être renseigné.", "Erreur !");
                Medicament m = new Medicament();
                m.Idmedicament = Int32.Parse(UpdateIDMedText.Text);
                m.NomMedicament = UpdateNameMedText.Text;
                foreach (Medicament med in ApplicationData.listeMedicaments) {
                    if (m.Idmedicament == med.Idmedicament) {
                        med.Update(Int32.Parse(UpdateIDMedText.Text), UpdateNameMedText.Text);
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
        /// Méthode permettant de supprimer un médicament de la base de données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void SupprimerMedicament(object sender, RoutedEventArgs e) {
            try {
                if (DelMedText.Text.Length == 0)
                    MessageBox.Show("L'ID du médicament n'est pas renseigné.", "Erreur !");
                else if (!Saisie.SaisieInt(DelMedText.Text))
                    MessageBox.Show("L'ID du médicament doit être un nombre entier.", "Erreur !");
                else {
                    Medicament m = new Medicament();
                    m.Idmedicament = Int32.Parse(DelMedText.Text);
                    foreach (Medicament med in ApplicationData.listeMedicaments) {
                        if (m.Idmedicament == med.Idmedicament) {
                            MessageBoxResult result = MessageBox.Show($"{med.NomMedicament}", "Confirmation", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                            if (result == MessageBoxResult.OK) {
                                ApplicationData.listeMedicaments.Remove(med);
                                m.Delete(med.Idmedicament);
                            }
                            lvMedicament.Items.Refresh();
                            break;
                        }
                    }
                }
            }
            catch (Exception) {
                MessageBox.Show("Le champs n'est pas renseigné, ou mal renseigné.", "Erreur !");
            }
        }

        /// <summary>
        /// Méthode permettant de remettre les Médicaments a vide
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        /*private void ViderMedicament(object sender, RoutedEventArgs e) {
            Medicament m = new Medicament();
            m.Truncate();
            lvMedicament.Items.Refresh();
        }*/

        /// <summary>
        /// Méthode permettant d'ajouter une maladie à la base de données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void AjouterMaladie(object sender, RoutedEventArgs e) {
            try {
                if (AddNomMaladie.Text.Length == 0)
                    MessageBox.Show("Le nom de la maladie n'est pas renseigné.", "Erreur !");
                else {
                    lastIndexMaladie++;
                    Maladie m = new Maladie(lastIndexMaladie,AddNomMaladie.Text);
                    m.Create();
                    ApplicationData.listeMaladies.Add(m);
                    lvMaladie.Items.Refresh();
                }
            }
            catch (Exception) {
                MessageBox.Show("Le champs n'est pas renseigné, ou mal renseigné.", "Erreur !");
            }
        }


        private void UpdateMaladie(object sender, RoutedEventArgs e) {
            try {
                if (UpdateIDMaladieText.Text.Length == 0)
                    MessageBox.Show("L'ID de la maladie doit être renseigné.", "Erreur !");
                else if (!Saisie.SaisieInt(UpdateIDMaladieText.Text))
                    MessageBox.Show("L'ID de la maladie doit être un nombre entier.", "Erreur !");
                if (UpdateNomMaladieText.Text.Length == 0)
                    MessageBox.Show("Le nom de la maladie doit être renseigné.", "Erreur !");
                Maladie m = new Maladie();
                m.IdMaladie = Int32.Parse(UpdateIDMaladieText.Text);
                m.NomMaladie = UpdateNomMaladieText.Text;
                foreach (Maladie mal in ApplicationData.listeMaladies) {
                    if (m.IdMaladie == mal.IdMaladie) {
                        mal.Update(Int32.Parse(UpdateIDMaladieText.Text), UpdateNomMaladieText.Text);
                        break;
                    }
                }
                lvMaladie.Items.Refresh();
            }
            catch (Exception) {
                MessageBox.Show("Un ou plusieurs champs ne sont pas renseignés, ou mal renseignés.", "Erreur !");
            }

            lvMedicament.Items.Refresh();
        }

        /// <summary>
        /// Méthode permettant de supprimer une maladie de la base de données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void SupprimerMaladie(object sender, RoutedEventArgs e) {
            try {
                if (DelMaladieText.Text.Length == 0)
                    MessageBox.Show("L'ID de la maladie n'est pas renseigné.", "Erreur !");
                else if (!Saisie.SaisieInt(DelMaladieText.Text))
                    MessageBox.Show("L'ID de la maladie doit être un nombre entier.", "Erreur !");
                else {
                    Maladie m = new Maladie();
                    m.IdMaladie = Int32.Parse(DelMaladieText.Text);
                    foreach (Maladie mal in ApplicationData.listeMaladies) {
                        if (m.IdMaladie == mal.IdMaladie) {
                            MessageBoxResult result = MessageBox.Show($"{mal.NomMaladie}", "Confirmation", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                            if (result == MessageBoxResult.OK) {
                                ApplicationData.listeMaladies.Remove(mal);
                                m.Delete(Int32.Parse(DelMaladieText.Text));
                            }
                            lvMaladie.Items.Refresh();
                            break;
                        }
                    }
                }
            }
            catch (Exception) {
                MessageBox.Show("Le champs n'est pas renseigné, ou mal renseigné.", "Erreur !");
            }
        }

        private void AjouterCategorie(object sender, RoutedEventArgs e) {
            try {
                if (AddCatText.Text.Length == 0)
                    MessageBox.Show("Le nom de la catégorie n'est pas renseigné.", "Erreur !");
                else {
                    lastIndexCategorie++;
                    CategorieMedicament c = new CategorieMedicament(lastIndexCategorie,AddCatText.Text);
                    c.Create();
                    ApplicationData.listeCategories.Add(c);
                    lvCategorie.Items.Refresh();
                }
            }
            catch (Exception) {
                MessageBox.Show("Le champs n'est pas renseigné, ou mal renseigné.", "Erreur !");
            }
        }

        private void UpdateCategorie(object sender, RoutedEventArgs e) {
            try {
                if (UpdateIDCatText.Text.Length == 0)
                    MessageBox.Show("L'ID de la catégorie doit être renseigné.", "Erreur !");
                else if (!Saisie.SaisieInt(UpdateIDCatText.Text))
                    MessageBox.Show("L'ID de la catégorie doit être un nombre entier.", "Erreur !");
                if (UpdateNameCatText.Text.Length == 0)
                    MessageBox.Show("Le nom de la catégorie doit être renseigné.", "Erreur !");
                CategorieMedicament c = new CategorieMedicament();
                c.IdCategorie = Int32.Parse(UpdateIDCatText.Text);
                c.NomCategorie = UpdateNameCatText.Text;
                foreach (CategorieMedicament cm in ApplicationData.listeCategories) {
                    if (c.IdCategorie == cm.IdCategorie) {
                        cm.Update(Int32.Parse(UpdateIDCatText.Text), UpdateNameCatText.Text);
                        break;
                    }
                }
                lvMaladie.Items.Refresh();
            }
            catch (Exception) {
                MessageBox.Show("Un ou plusieurs champs ne sont pas renseignés, ou mal renseignés.", "Erreur !");
            }

            lvMedicament.Items.Refresh();
        }

        /// <summary>
        /// Méthode permettant de supprimer une catégorie de médicament
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SupprimerCategorie(object sender, RoutedEventArgs e) {


            try {
                if (DelCatText.Text.Length == 0)
                    MessageBox.Show("L'ID de la catégorie n'est pas renseigné.", "Erreur !");
                else if (!Saisie.SaisieInt(DelCatText.Text))
                    MessageBox.Show("L'ID de la catégorie doit être un nombre entier.", "Erreur !");
                else {
                    CategorieMedicament c = new CategorieMedicament();
                    c.IdCategorie = Int32.Parse(DelCatText.Text);
                    foreach (CategorieMedicament cm in ApplicationData.listeCategories) {
                        if (c.IdCategorie == cm.IdCategorie) {
                            MessageBoxResult result = MessageBox.Show($"{cm}", "Confirmation", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                            if (result == MessageBoxResult.OK) {
                                ApplicationData.listeCategories.Remove(cm);
                                c.Delete(cm.IdCategorie);
                            }
                            break;
                        }
                    }
                }
            }
            catch (Exception) {
                MessageBox.Show("Le champs n'est pas renseigné, ou mal renseigné.", "Erreur !");
            }

            //ApplicationData.listeMedicaments.Remove(m);
            lvCategorie.Items.Refresh();
        }

        private void lvAutorisation_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            lvAutorisation.Items.Refresh();
        }

        /// <summary>
        /// Méthode permettant d'afficher la page pour gerer les autorisations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void AjouterAutorisation(object sender, RoutedEventArgs e) {
            AutorisationAjouter autorisation = new AutorisationAjouter();
            autorisation.ShowDialog();
        }

        private void ModifierAutorisation(object sender, RoutedEventArgs e) {
            AutorisationModifier autorisationModifier = new AutorisationModifier();
            autorisationModifier.Show();
        }

        private void SupprimerAutorisation(object sender, RoutedEventArgs e) {
            try {
                if (lvAutorisation.SelectedItem is null)
                    MessageBox.Show("La suppression est impossible ! Vérifiez de bien selectionner un champs avant de supprimer", "Erreur !");
                else {
                    MessageBoxResult result = MessageBox.Show($"{lvAutorisation.SelectedItem.ToString()}\n Étes-vous sûr de vouloir supprimer ?", "Confirmation", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
                    if (result == MessageBoxResult.OK) {
                        Est_autorisé est_Autorise = new Est_autorisé();
                        est_Autorise.IdMedicament = ((Est_autorisé)lvAutorisation.SelectedItem).IdMedicament;
                        est_Autorise.IdMaladie = ((Est_autorisé)lvAutorisation.SelectedItem).IdMaladie;
                        est_Autorise.UneDate = ((Est_autorisé)lvAutorisation.SelectedItem).UneDate;
                        foreach (Est_autorisé ea in ApplicationData.listeAutorisations) {
                            if (est_Autorise.IdMaladie == ea.IdMaladie && est_Autorise.IdMedicament == ea.IdMedicament && est_Autorise.UneDate == ea.UneDate) {
                                ApplicationData.listeAutorisations.Remove(ea);
                                est_Autorise.Delete(ea.IdMedicament);
                                break;
                            }
                        }
                    }
                }
            }
            catch (Exception) {

                MessageBox.Show("Le champs n'est pas renseigné, ou mal renseigné.", "Erreur !");
            }
            lvAutorisation.Items.Refresh();
        }

        private int FindLastMedInList(List<Medicament> list) {
            int Upper = 0;
            foreach(Medicament m in list) {
                if (m.Idmedicament >= Upper)
                    Upper = m.Idmedicament;
            }
            return Upper;
        }
        private int FindLastCatInList(List<CategorieMedicament> list) {
            int Upper = 0;
            foreach (CategorieMedicament c in list) {
                if (c.IdCategorie >= Upper)
                    Upper = c.IdCategorie;
            }
            return Upper;
        }
        private int FindLastMalInList(List<Maladie> list) {
            int Upper = 0;
            foreach (Maladie m in list) {
                if (m.IdMaladie >= Upper)
                    Upper = m.IdMaladie;
            }
            return Upper;
        }
    }
}
