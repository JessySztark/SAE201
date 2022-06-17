using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Medicament {
    public class ApplicationData {
        public static List<Maladie> listeMaladies {
            get;
            set;
        }
        public static List<Medicament> listeMedicaments {
            get;
            set;
        }
        public static List<CategorieMedicament> listeCategories {
            get;
            set;
        }
        public static List<Date_autorisation> listeDates {
            get;
            set;
        }
        public static List<Est_autorisé> listeAutorisations {
            get;
            set;
        }
        /// <summary>
        /// Méthode permettant d'initialiser un objet de chaque classes et une liste de chaque classes
        /// </summary>
        public static void loadApplicationData() {
            //chargement des tables
            CategorieMedicament uneCategorie = new CategorieMedicament();
            Maladie uneMaladie = new Maladie();
            Medicament unMedicament = new Medicament();
            Date_autorisation uneDate = new Date_autorisation();
            Est_autorisé uneAutorisation = new Est_autorisé();
            listeCategories = uneCategorie.FindAll();
            listeMaladies = uneMaladie.FindAll();
            listeDates = uneDate.FindAll();
            listeMedicaments = unMedicament.FindAll();
            listeAutorisations = uneAutorisation.FindAll();
        }
    }
}
