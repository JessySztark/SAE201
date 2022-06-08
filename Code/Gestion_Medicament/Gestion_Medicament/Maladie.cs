using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class Maladie : CRUD<Maladie>{
    private String nomMaladie;
    private int idMaladie;
    List<Maladie> listeMaladies;

    public Maladie()
    {
        
    }

    private Est_autorisé[] est_autorisés;

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

    public List<Maladie> FindAll()
    {
         ListeMaladies= new List<Maladie>();
        DataAccess access = new DataAccess();
        SqlDataReader reader;
        try
        {
            if (access.openConnection())
            {
                reader = access.getData("select * from [MALADIE]"); //[BT3].[IUT-ACY\\sztarkj].
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
