using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Gestion_Medicament {
    public class Date_autorisation : CRUD<Date_autorisation> {
        private DateTime date;
        /// <summary>
        /// Constructeur créer par le squelette de base du code
        /// </summary>
        public Date_autorisation() {

        }

        private Est_autorisé[] est_autorisés;
        /// <summary>
        /// Propriété de type DateTime et de nom Date 
        /// </summary>
        public DateTime Date {
            get {
                return this.date;
            }

            set {
                this.date = value;
            }
        }
        /// <summary>
        /// Méthode permettant d'inserer une autorisation à la base de données
        /// </summary>
        public void Create() {
            DataAccess access = new DataAccess();
            if (access.openConnection()) {
                if (access.setData($"INSERT INTO DATE_AUTORISATION VALUES('{this.Date}');")) {

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
        /// Méthode non définie dans cette classe
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nom"></param>
        public void Update(int id, String nom) {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Méthode supprimant une autorisation
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id) {
            throw new NotImplementedException();
        }
        public void DeleteDate(DateTime date) {
            DataAccess access = new DataAccess();
            if (access.setData($"DELETE FROM DATE_AUTORISATION WHERE  DATES = {date}")) {

            }
        }
        /// <summary>
        /// Méthode créant une liste pour l'affichage des autorisations 
        /// </summary>
        /// <returns></returns>
        public List<Date_autorisation> FindAll() {
            List<Date_autorisation> listeDates = new List<Date_autorisation>();
            DataAccess access = new DataAccess();
            SqlDataReader reader;
            try {
                if (access.openConnection()) {
                    reader = access.getData("select * from [DATE_AUTORISATION]");
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            Date_autorisation uneDate = new Date_autorisation();
                            uneDate.Date = reader.GetDateTime(0);
                            listeDates.Add(uneDate);
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
            return listeDates;
        }
        /// <summary>
        /// Méthode permettant de rechercher dans une liste a l'aide d'un critère précis 
        /// </summary>
        /// <param name="criteres"></param>
        /// <returns></returns>
        public List<Date_autorisation> FindBySelection(ref string criteres) {
            throw new NotImplementedException();
        }

    }
}
