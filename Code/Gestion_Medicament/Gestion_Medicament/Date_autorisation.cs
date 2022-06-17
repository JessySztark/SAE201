using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Gestion_Medicament {
    public class Date_autorisation : CRUD<Date_autorisation> {
        private DateTime date;
        /// <summary>
        /// Constructeur cr�er par le squelette de base du code
        /// </summary>
        public Date_autorisation() {

        }

        private Est_autoris�[] est_autoris�s;
        /// <summary>
        /// Propri�t� de type DateTime et de nom Date 
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
        /// M�thode permettant d'inserer une autorisation � la base de donn�es
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
        /// M�thode non d�finie dans cette classe
        /// </summary>
        public void Read() {
            throw new NotImplementedException();
        }
        /// <summary>
        /// M�thode non d�finie dans cette classe
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nom"></param>
        public void Update(int id, String nom) {
            throw new NotImplementedException();
        }
        /// <summary>
        /// M�thode supprimant une autorisation
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
        /// M�thode cr�ant une liste pour l'affichage des autorisations 
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
        /// M�thode permettant de rechercher dans une liste a l'aide d'un crit�re pr�cis 
        /// </summary>
        /// <param name="criteres"></param>
        /// <returns></returns>
        public List<Date_autorisation> FindBySelection(ref string criteres) {
            throw new NotImplementedException();
        }

    }
}
