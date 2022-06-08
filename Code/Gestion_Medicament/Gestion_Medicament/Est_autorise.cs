using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class Est_autoris� : CRUD<Est_autoris�>
{
    private String commentaire;
    private DateTime uneDate;
    private Maladie uneMaladie;
    private Medicament unMedicament;

    public Est_autoris�()
    {

    }
    public string Commentaire
    {
        get
        {
            return this.commentaire;
        }

        set
        {
            this.commentaire = value;
        }
    }

    public DateTime UneDate
    {
        get
        {
            return this.uneDate;
        }

        set
        {
            this.uneDate = value;
        }
    }

    public Maladie UneMaladie
    {
        get
        {
            return this.uneMaladie;
        }

        set
        {
            this.uneMaladie = value;
        }
    }

    public Medicament UnMedicament
    {
        get
        {
            return this.unMedicament;
        }

        set
        {
            this.unMedicament = value;
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

    public List<Est_autoris�> FindAll()
    {
        List<Est_autoris�> listeAutorisations = new List<Est_autoris�>();
        DataAccess access = new DataAccess();
        SqlDataReader reader;
        try
        {
            if (access.openConnection())
            {
                reader = access.getData("select * from [EST_AUTORISE]");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Est_autoris� uneAutorisation = new Est_autoris�();
                        uneAutorisation.UnMedicament.Idmedicament = (int)reader.GetInt64(0);
                        uneAutorisation.UneMaladie.IdMaladie = (int)reader.GetInt64(1);
                        uneAutorisation.UneDate = reader.GetDateTime(2);
                        listeAutorisations.Add(uneAutorisation);
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
        return listeAutorisations;
    }

    public List<Est_autoris�> FindBySelection(ref string criteres)
    {
        throw new NotImplementedException();
    }
}