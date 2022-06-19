using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Gestion_Medicament {
    public class Medicament : CRUD<Medicament> {
        private int idmedicament;
        private CategorieMedicament uneCategorie;
        private String nomMedicament;
        private int idCategorie;
        /// <summary>
        /// Constructeur venant du squelette cr�er automatiquement
        /// </summary>
        public Medicament() {

        }
        /// <summary>
        /// Constructeur cr�ant le m�dicament avec deux attributs
        /// </summary>
        /// <param name="idcategorie"></param>
        /// <param name="nommedicament"></param>
        public Medicament(int idcategorie, String nommedicament) {
            this.IdCategorie = idcategorie;
            this.NomMedicament = nommedicament;
        }

        public Medicament(int idmedicament, int idcategorie, String nommedicament) {
            this.Idmedicament = idmedicament;
            this.IdCategorie = idcategorie;
            this.NomMedicament = nommedicament;
        }

        public int Idmedicament {
            get {
                return this.idmedicament;
            }

            set {
                this.idmedicament = value;
            }
        }

        public CategorieMedicament UneCategorie {
            get {
                return this.uneCategorie;
            }

            set {
                this.uneCategorie = value;
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

        public int IdCategorie {
            get {
                return this.idCategorie;
            }

            set {
                this.idCategorie = value;
            }
        }
        /// <summary>
        /// M�thode permettant d'ajouter un m�dicament � la base de donn�es
        /// </summary>
        public void Create() {
            DataAccess access = new DataAccess();
            if (access.openConnection()) {
                if (access.setData($"INSERT INTO MEDICAMENT VALUES({this.IdCategorie},'{this.NomMedicament}');")) {

                }
            }
            access.closeConnection();
        }

        public void Read() {
            throw new NotImplementedException();
        }
        /// <summary>
        /// M�thode permettant de mettre a jour un des m�dicaments d�j� entr� � l'aide de l'id du medicament et du nom
        /// </summary>
        /// <param name="idmed"></param>
        /// <param name="nom"></param>
        public void Update(int idmed, String nom) {
            DataAccess access = new DataAccess();
            if (access.openConnection()) {
                if (access.setData($"UPDATE MEDICAMENT SET NOMMEDICAMENT = '{nom}' WHERE IDMEDICAMENT = {idmed}")) {

                }
            }
            access.closeConnection();
        }

        /// <summary>
        /// M�thode permettant de supprimer le m�dicament s�l�ctionn� � l'aide de l'id du m�dicament
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id) {
            DataAccess access = new DataAccess();
            if (access.openConnection()) {
                if (access.setData($"DELETE FROM MEDICAMENT WHERE idmedicament = {id}")) {

                }

            }
            access.closeConnection();
        }

        /// <summary>
        /// M�thode permettant de r�initialiser les m�dicaments de la table
        /// </summary>
        public void Truncate() {
            DataAccess access = new DataAccess();
            if (access.openConnection()) {
                if (access.setData($"TRUNCATE TABLE MEDICAMENT")) {

                }
            }
            access.closeConnection();
        }

        /// <summary>
        /// M�thode cr�ant la liste de m�dicaments directement depuis la base de donn�es
        /// </summary>
        /// <returns></returns>
        public List<Medicament> FindAll() {
            List<Medicament> listeMedicaments = new List<Medicament>();
            DataAccess access = new DataAccess();
            SqlDataReader reader;
            try {
                if (access.openConnection()) {
                    reader = access.getData("select * from [MEDICAMENT]");
                    if (reader.HasRows) {
                        while (reader.Read()) {
                            Medicament unMedicament = new Medicament();
                            unMedicament.Idmedicament = (int)reader.GetDecimal(0);
                            unMedicament.IdCategorie = (int)reader.GetDecimal(1);
                            unMedicament.NomMedicament = reader.GetString(2);
                            listeMedicaments.Add(unMedicament);
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
            return listeMedicaments;
        }

        public List<Medicament> FindBySelection(ref string criteres) {
            throw new NotImplementedException();
        }
    }
}