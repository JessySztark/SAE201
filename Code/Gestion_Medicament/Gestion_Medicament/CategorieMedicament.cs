using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Gestion_Medicament {
    public class CategorieMedicament : CRUD<CategorieMedicament> {
        private String nomCategorie;
        private int idCategorie;
        /// <summary>
        /// Constructeur créer dans le squelette du code de base
        /// </summary>
        public CategorieMedicament() {

        }
        public CategorieMedicament(String nomcategorie) {
            this.NomCategorie = nomcategorie;
        }

        public CategorieMedicament(int idcategorie, String nomcategorie) {
            this.IdCategorie = idcategorie;
            this.NomCategorie = nomcategorie;
        }

        public string NomCategorie {
            get {
                return this.nomCategorie;
            }

            set {
                this.nomCategorie = value;
            }
        }

        public int IdCategorie {
            get {
                return this.idCategorie;
            }

            set {
                this.idCategorie = value;
            }
        }
        /// <summary>
        /// Méthode ajoutant une catégorie à la base de données 
        /// </summary>

        public void Create() {
            DataAccess access = new DataAccess();
            if (access.openConnection()) {
                if (access.setData($"INSERT INTO CATEGORIEMEDICAMENT VALUES('{this.NomCategorie}');")) {

                }
            }
            access.closeConnection();
        }
        /// <summary>
        /// Méthode obligée par héritage du CRUD
        /// </summary>
        public void Read() {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Méthode obligée par héritage du CRUD
        /// </summary>
        /// <param name="id"></param>
        /// <param name="nom"></param>
        public void Update(int id, String nom) {
            DataAccess access = new DataAccess();
            if (access.openConnection()) {
                if (access.setData($"UPDATE CATEGORIEMEDICAMENT SET NOMCATEGORIE = '{nom}' WHERE IDCATEGORIE = {id}")) {

                }
            }
            access.closeConnection();
        }
        /// <summary>
        /// Méthode supprimant la catégorie séléctionnée
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id) {
            DataAccess access = new DataAccess();
            if (access.openConnection()) {
                if (access.setData($"DELETE FROM CATEGORIEMEDICAMENT WHERE idcategorie = {id}")) {

                }
            }
            access.closeConnection();
        }

        public void Truncate() {
            DataAccess access = new DataAccess();
            if (access.openConnection()) {
                if (access.setData($"TRUNCATE TABLE CATEGORIEMEDICAMENT")) {

                }
            }
            access.closeConnection();
        }

        /// <summary>
        /// Méthode créant une liste de catégorie de médicament pour les afficher par la suite 
        /// </summary>
        /// <returns></returns>
        public List<CategorieMedicament> FindAll() {
            List<CategorieMedicament> listeCategories = new List<CategorieMedicament>();
            DataAccess access = new DataAccess();
            SqlDataReader reader;
            try {
                if (access.openConnection()) {
                    reader = access.getData("select * from [CATEGORIEMEDICAMENT]");
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            CategorieMedicament uneCategorie = new CategorieMedicament();
                            uneCategorie.IdCategorie = (int)reader.GetDecimal(0);
                            uneCategorie.NomCategorie = reader.GetString(1);
                            listeCategories.Add(uneCategorie);
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
            return listeCategories;
        }
        /// <summary>
        /// Méthode obligée par héritage du CRUD
        /// </summary>
        /// <param name="criteres"></param>
        /// <returns></returns>
        public List<CategorieMedicament> FindBySelection(ref string criteres) {
            throw new NotImplementedException();
        }
    }
}
