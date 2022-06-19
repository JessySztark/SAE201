using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Gestion_Medicament
{
    public class Maladie : CRUD<Maladie>
    {
        private String nomMaladie;
        private int idMaladie;
        List<Maladie> listeMaladies;

        public Maladie()
        {

        }

        public Maladie(String nomMaladie)
        {
            this.NomMaladie = nomMaladie;
        }

        public Maladie(int idmaladie, String nomMaladie) {
            this.IdMaladie = idmaladie;
            this.NomMaladie = nomMaladie;
        }

        public string NomMaladie
        {
            get
            {
                return this.nomMaladie;
            }

            set
            {
                this.nomMaladie = value;
            }
        }

        public int IdMaladie
        {
            get
            {
                return this.idMaladie;
            }

            set
            {
                this.idMaladie = value;
            }
        }

        public List<Maladie> ListeMaladies
        {
            get
            {
                return this.listeMaladies;
            }

            set
            {
                this.listeMaladies = value;
            }
        }

        public void Create()
        {
            DataAccess access = new DataAccess();
            if (access.openConnection())
            {
                if (access.setData($"INSERT INTO MALADIE VALUES('{this.NomMaladie}');"))
                {

                }
            }
            access.closeConnection();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, String nom)
        {
            DataAccess access = new DataAccess();
            if (access.openConnection()) {
                if (access.setData($"UPDATE MALADIE SET NOMMALADIE = '{nom}' WHERE IDMALADIE = {id}")) {

                }
            }
            access.closeConnection();
        }

        public void Delete(int id)
        {
            DataAccess access = new DataAccess();
            if (access.openConnection())
            {
                if (access.setData($"DELETE FROM MALADIE WHERE IDMALADIE = {id}"))
                {

                }
            }
            access.closeConnection();
        }

        public void Truncate() {
            DataAccess access = new DataAccess();
            if (access.openConnection()) {
                if (access.setData($"TRUNCATE TABLE MALADIE")) {

                }
            }
            access.closeConnection();
        }

        public List<Maladie> FindAll()
        {
            ListeMaladies = new List<Maladie>();
            DataAccess access = new DataAccess();
            SqlDataReader reader;
            try
            {
                if (access.openConnection())
                {
                    reader = access.getData("select * from [MALADIE]");
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Maladie uneMaladie = new Maladie();
                            uneMaladie.IdMaladie = (int)reader.GetDecimal(0);
                            uneMaladie.NomMaladie = reader.GetString(1);
                            ListeMaladies.Add(uneMaladie);
                        }
                    }
                    else
                    {
                        System.Windows.MessageBox.Show("No rows found.", "Important Message");
                    }
                    reader.Close();
                    access.closeConnection();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Important Message");
            }
            return ListeMaladies;
        }

        public List<Maladie> FindBySelection(ref string criteres)
        {
            throw new NotImplementedException();
        }
    }
}