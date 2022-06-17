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
    /// Logique d'interaction pour Autorisation.xaml
    /// </summary>
    public partial class Autorisation : Window {
        public Autorisation() {
            InitializeComponent();
            cbMedicament.ItemsSource = ApplicationData.listeMedicaments;
            cbMaladie.ItemsSource = ApplicationData.listeMaladies;
        }

        private void AjouterAutorisation(object sender, RoutedEventArgs e) {
            try {
                if (cbMaladie.SelectedItem is null)
                    MessageBox.Show("La maladie n'est pas renseignée.", "Erreur !");
                if (cbMedicament.SelectedItem is null)
                    MessageBox.Show("Le médicament n'est pas renseignée.", "Erreur !");
                if (AddDateText.SelectedDate is null)
                    MessageBox.Show("La date n'est pas renseignée.", "Erreur !");
                else {
                    String dayCompose = AddDateText.SelectedDate.ToString().Substring(0, 2);
                    String monthCompose = AddDateText.SelectedDate.ToString().Substring(3, 2);
                    String yearCompose = AddDateText.SelectedDate.ToString().Substring(6, 4);
                    DateTime dt = new DateTime(Int32.Parse(yearCompose), Int32.Parse(monthCompose), Int32.Parse(dayCompose));
                    Date_autorisation d = new Date_autorisation((DateTime)AddDateText.SelectedDate);
                    d.Create();
                    ApplicationData.listeDates.Add(d);
                    Medicament m = new Medicament();
                    Est_autorisé autoris = new Est_autorisé((Medicament)cbMedicament.SelectedItem,(Maladie)cbMaladie.SelectedItem, d);
                    autoris.IdMedicament = autoris.UnMedicament.Idmedicament;
                    autoris.IdMaladie = autoris.UneMaladie.IdMaladie;
                    autoris.DateAuto = autoris.UneDate.Date;
                    if (!(AddCommentaireText.Text.Length == 0))
                        autoris.Commentaire = AddCommentaireText.Text;
                    autoris.Create();
                    ApplicationData.listeAutorisations.Add(autoris);
                }
            }
            catch (Exception) {
                MessageBox.Show("Le champs n'est pas renseigné, ou mal renseigné.", "Erreur !");
            }
        }

        /*
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
                            ApplicationData.listeMaladies.Remove(mal);
                            m.Delete(Int32.Parse(DelMaladieText.Text));
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
        
         
                 /// <summary>
        /// Permet d'ajouter une autorisation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        // private void AjouterAutorisation(){}

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
         */
    }
}
