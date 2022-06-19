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

        /// <summary>
        /// Constructeur permettant d'initialiser une autorisation grâce à une maladie, un médicament, une date et un commentaire
        /// </summary>
        /// <param name="unMedicament">Variable de type Médicament</param>
        /// <param name="uneMaladie">Variable de type Maladie</param>
        /// <param name="uneDate">Variable de type Date_autorisation </param>
        /// <param name="commentaire">Variable de type String</param>

        public Est_autorisé( Medicament unMedicament, Maladie uneMaladie, Date_autorisation uneDate, String commentaire) {
            this.UneMaladie = uneMaladie;
            this.UnMedicament = unMedicament;
            this.UneDate = uneDate;
            this.Commentaire = commentaire;
        }

        /// <summary>
        /// Constructeur permettant d'initialiser une autorisation grâce à une maladie, un médicament et une date sans commentaire
        /// </summary>
        /// <param name="unMedicament">Variable de type Médicament</param>
        /// <param name="uneMaladie">Variable de type Maladie </param>
        /// <param name="uneDate">Variable de type String</param>

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
                if (access.setData($"INSERT INTO EST_AUTORISE VALUES({this.IdMedicament},{this.IdMaladie},'{this.DateAuto}','{this.Commentaire}');")) {

                }
            }
            access.closeConnection();
        }

        /// <summary>
        /// Méthode non définie dans cette classe
        /// </summary>

        public void Read() {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode non définie dans cette classe pour le moment
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nom"></param>

        public void Update(int id, String nom) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode permettant de supprimer une autorisation de la base de données
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

        public void Truncate() {
            DataAccess access = new DataAccess();
            if (access.openConnection()) {
                if (access.setData($"TRUNCATE TABLE EST_AUTORISE")) {

                }
            }
            access.closeConnection();
        }

        /// <summary>
        /// Méthode permettant de créer une liste d'autorisation qui sera affichée dans 
        /// </summary>
        /// <returns>Retourne une liste d'autorisation</returns>

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

        /// <summary>
        /// Méthode permettant de retrouver une autorisation dans la liste grâce à un critère
        /// </summary>
        /// <param name="criteres">Variable de type String</param>
        /// <returns></returns>

        public List<Est_autorisé> FindBySelection(ref string criteres) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Méthode permettant de montrer ce que retourne la classe quand on l'affiche 
        /// </summary>
        /// <returns></returns>

        public override string ToString() {
            String txt = $"Autorisation pour {this.NomMedicament} agissant contre {this.NomMaladie}.\n Date d'autorisation : {this.DateAuto} \nCommentaire : {this.Commentaire}";
            return txt;
        }
    }
}