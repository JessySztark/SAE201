using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Medicament {
        public class ApplicationData{
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
        public static void loadApplicationData() {
                //chargement des tables
                Maladie uneMaladie = new Maladie();
                Medicament unMedicament = new Medicament();
                CategorieMedicament uneCategorie = new CategorieMedicament();
                Date_autorisation uneDate = new Date_autorisation();
                Est_autorisé uneAutorisation = new Est_autorisé();
                listeMaladies = uneMaladie.FindAll();
                listeMedicaments = unMedicament.FindAll();
                listeCategories = uneCategorie.FindAll();
                listeDates = uneDate.FindAll();
                listeAutorisations = uneAutorisation.FindAll();
            }
        }
}
