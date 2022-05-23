using System;
using System.Collections.Generic;
using System.Data.SqlClient;

    class DataAccess:CRUD<DataAccess>
    {
        private SqlConnection connection;

        /// <summary>
        /// Connecte la base de données
        /// </summary>
        public Boolean openConnection()
        {
            Boolean ret = false;
            try
            {
                this.connection = new SqlConnection();
                
                this.connection.ConnectionString =
                "Data Source=srv-jupiter.iut-acy.local;" +
                "Initial Catalog=BT3;" +
                "Integrated Security=SSPI;";
                
                this.connection.Open();
                if (this.connection.State.Equals(System.Data.ConnectionState.Open))
                {
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Impossible d'établir une connexion à la DB !");
            }

            return ret;
        }

        /// <summary>
        /// Déconnecte la base de données
        /// </summary>
        public void closeConnection()
        {
            try
            {
                if (this.connection.State.Equals(System.Data.ConnectionState.Open))
                {
                    this.connection.Close();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Impossible d'interrompre une connexion à la DB !");
            }
        }

        /// <summary>
        /// Donne accès à des données en lecture
        /// </summary>
        public SqlDataReader getData(String getQuery)
        {
            SqlDataReader reader = null;
            
            try
            {
                    SqlCommand command = new SqlCommand(getQuery, this.connection);
                    reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "Impossible de lire la DB !");
            }

            return reader;
        }

        /// <summary>
        /// Permet d'insérer, supprimer ou modifier des données
        /// </summary>
        /// <param name="setQuery">Requête SQL permettant d'insérer, supprimer ou modifier des données.</param>
        /// <exception cref="System.Exception">Déclenchée si la connexion, l'écriture/modification/suppression en base ou la déconnexion échouent.</exception> 
        /// <returns>Un booléen indiquant si des lignes ont été ajoutées/supprimées/modifiées.</returns>
        public Boolean setData(String setQuery)
        {
            Boolean ret = false;

            try
            {
                if (this.openConnection())
                {
                    int modifiedLines;
                    SqlCommand command = new SqlCommand(setQuery, this.connection);

                    modifiedLines = command.ExecuteNonQuery();

                    if (modifiedLines > 0)
                    {
                        ret = true;
                    }

                    this.closeConnection();
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message, "SQL Commande invalide !");
            }

            return ret;
        }

    public void Create() {
        throw new NotImplementedException();
    }

    public void Read() {
        throw new NotImplementedException();
    }

    public void Update() {
        throw new NotImplementedException();
    }

    public void Delete() {
        throw new NotImplementedException();
    }

    public List<DataAccess> FindAll() {
        throw new NotImplementedException();
    }

    public List<DataAccess> FindBySelection(ref string criteres) {
        throw new NotImplementedException();
    }
}
