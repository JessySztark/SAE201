using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace Gestion_Medicament {
    public class Est_autorisé : CRUD<Est_autorisé> {
        private String commentaire;
        private Date_autorisation uneDate;
        private Maladie uneMaladie;
        private Medicament unMedicament;
        private int idMedicament;
        private int idMaladie;
        private String nomMaladie;
        private String nomMedicament;
        private DateTime dateAuto;

        public Est_autorisé() {

        }

        public Est_autorisé( Medicament unMedicament, Maladie uneMaladie, Date_autorisation uneDate, String commentaire) {
            this.UneMaladie = uneMaladie;
            this.UnMedicament = unMedicament;
            this.UneDate = uneDate;
            this.Commentaire = commentaire;
        }

        public Est_autorisé(Medicament unMedicament, Maladie uneMaladie, Date_autorisation uneDate) {
            this.UneMaladie = uneMaladie;
            this.UnMedicament = unMedicament;
            this.UneDate = uneDate;
        }

        public string Commentaire {
            get {
                return this.commentaire;
            }

            set {
                this.commentaire = value;
            }
        }

        public Date_autorisation UneDate {
            get {
                return this.uneDate;
            }

            set {
                this.uneDate = value;
            }
        }

        public Maladie UneMaladie {
            get {
                return this.uneMaladie;
            }

            set {
                this.uneMaladie = value;
            }
        }

        public Medicament UnMedicament {
            get {
                return this.unMedicament;
            }

            set {
                this.unMedicament = value;
            }
        }

        public int IdMedicament {
            get {
                return this.idMedicament;
            }

            set {
                this.idMedicament = value;
            }
        }

        public int IdMaladie {
            get {
                return this.idMaladie;
            }

            set {
                this.idMaladie = value;
            }
        }

        public string NomMaladie {
            get {
                return this.nomMaladie;
            }

            set {
                this.nomMaladie = value;
            }
        }

        public string NomMedicament {
            get {
                return this.nomMedicament;
            }

            set {
                this.nomMedicament = value;
            }
        }

        public DateTime DateAuto {
            get {
                return this.dateAuto;
            }

            set {
                this.dateAuto = value;
            }
        }

        /// <summary>
        /// Méthode permettant d'insérer une autorisation
        /// </summary>
        public void Create() {
            DataAccess access = new DataAccess();
            if (access.openConnection()) {
                if (access.setData($"INSERT INTO EST_AUTORISE VALUES({this.IdMedicament},{this.IdMaladie},'{this.UneDate.Date.Year}-{this.UneDate.Date.Month}-{this.UneDate.Date.Day}','{this.Commentaire}');")) {

                }
            }
            access.closeConnection();
        }

        public void Read() {
            throw new NotImplementedException();
        }

        public void Update(int id, String nom) {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Méthode permettant de supprimer une autorisation
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id) {
            DataAccess access = new DataAccess();
            if (access.openConnection()) {
                if (access.setData($"DELETE FROM EST_AUTORISE WHERE IDMEDICAMENT = {id}")) {

                }

            }
            access.closeConnection();
        }

        public List<Est_autorisé> FindAll() {
            List<Est_autorisé> listeAutorisations = new List<Est_autorisé>();
            DataAccess access = new DataAccess();
            SqlDataReader reader;
            try {
                if (access.openConnection()) {
                    reader = access.getData("select a.IDMEDICAMENT, a.IDMALADIE, a.DATES, m.NOMMALADIE, med.NOMMEDICAMENT, a.COMMENTAIRE from [EST_AUTORISE] a JOIN [Maladie] m ON m.IDMALADIE = a.IDMALADIE JOIN [MEDICAMENT] med ON med.IDMEDICAMENT = a.IDMEDICAMENT");
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            Est_autorisé uneAutorisation = new Est_autorisé();
                            uneAutorisation.IdMedicament = (int)reader.GetDecimal(0);
                            uneAutorisation.IdMaladie = (int)reader.GetDecimal(1);
                            uneAutorisation.DateAuto = reader.GetDateTime(2);
                            uneAutorisation.NomMaladie = reader.GetString(3);
                            uneAutorisation.NomMedicament = reader.GetString(4);
                            uneAutorisation.Commentaire = reader.GetString(5);
                            listeAutorisations.Add(uneAutorisation);
                        }
                    }
                    else {
                        System.Windows.MessageBox.Show("No rows found.", "Important Message");
                    }
                    reader.Close();
                    access.closeConnection();
                }
            }
            catch (Exception ex) {
                System.Windows.MessageBox.Show(ex.Message, "Important Message");
            }
            return listeAutorisations;
        }

        public List<Est_autorisé> FindBySelection(ref string criteres) {
            throw new NotImplementedException();
        }
    }
}