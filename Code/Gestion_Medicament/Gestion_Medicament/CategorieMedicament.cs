using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class CategorieMedicament : CRUD<CategorieMedicament>{
    private String nomCategorie;
    private int idCategorie;
    public CategorieMedicament()
    {

    }
    public string NomCategorie
    {
        get
        {
            return this.nomCategorie;
        }

        set
        {
            this.nomCategorie = value;
        }
    }

    public int IdCategorie
    {
        get
        {
            return this.idCategorie;
        }

        set
        {
            this.idCategorie = value;
        }
    }

    public void Create()
    {
        throw new NotImplementedException();
    }

    public void Read()
    {
        throw new NotImplementedException();
    }

    public void Update()
    {
        throw new NotImplementedException();
    }

    public void Delete()
    {
        throw new NotImplementedException();
    }

    public List<CategorieMedicament> FindAll()
    {
        List<CategorieMedicament> listeCategories = new List<CategorieMedicament>();
        DataAccess access = new DataAccess();
        SqlDataReader reader;
        try
        {
            if (access.openConnection())
            {
                reader = access.getData("select * from [CATEGORIEMEDICAMENT]");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        CategorieMedicament uneCategorie = new CategorieMedicament();
                        uneCategorie.IdCategorie = (int)reader.GetInt64(0);
                        uneCategorie.NomCategorie = reader.GetString(1);
                        listeCategories.Add(uneCategorie);
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
        return listeCategories;
    }

    public List<CategorieMedicament> FindBySelection(ref string criteres)
    {
        throw new NotImplementedException();
    }
}
