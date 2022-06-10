using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class Medicament : CRUD<Medicament>{
    private int idmedicament;
    private CategorieMedicament uneCategorie;
    private String nomMedicament;
    private int idCategorie;

    public Medicament()
    {

    }

    public Medicament(int idcategorie, String nommedicament)
    {
        this.IdCategorie = idcategorie;
        this.NomMedicament = nommedicament;
    }

    private CategorieMedicament[] categorieMedicaments;
	private Est_autorisé[] est_autorisés;

    public int Idmedicament
    {
        get
        {
            return this.idmedicament;
        }

        set
        {
            this.idmedicament = value;
        }
    }

    public CategorieMedicament UneCategorie
    {
        get
        {
            return this.uneCategorie;
        }

        set
        {
            this.uneCategorie = value;
        }
    }

    public string NomMedicament
    {
        get
        {
            return this.nomMedicament;
        }

        set
        {
            this.nomMedicament = value;
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

    public List<Medicament> FindAll()
    {
        List<Medicament> listeMedicaments = new List<Medicament>();
        DataAccess access = new DataAccess();
        SqlDataReader reader;
        try
        {
            if (access.openConnection())
            {
                reader = access.getData("select * from [MEDICAMENT]");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Medicament unMedicament = new Medicament();
                        unMedicament.Idmedicament = (int)reader.GetDecimal(0);
                        unMedicament.IdCategorie = (int)reader.GetDecimal(1);
                        unMedicament.NomMedicament = reader.GetString(2);
                        listeMedicaments.Add(unMedicament);
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
        return listeMedicaments;
    }

    public List<Medicament> FindBySelection(ref string criteres)
    {
        throw new NotImplementedException();
    }

    public void AddMedicament()
    {
        SqlDataAdapter adapter;
        DataAccess access = new DataAccess();
        if (access.openConnection())
        {
            if (access.setData($"INSERT INTO MEDICAMENT VALUES({this.IdCategorie},'{this.NomMedicament}');"))
            {
                
            }
        }
    }
    public void DelMedicament(int idmed) {
        SqlDataAdapter adapter;
        DataAccess access = new DataAccess();
        if (access.openConnection()) {
            if (access.setData($"DELETE FROM MEDICAMENT WHERE idmedicament = {idmed}")) {

            }
        }
    }

    public void Trunc() {
        SqlDataAdapter adapter;
        DataAccess access = new DataAccess();
        if (access.openConnection()) {
            if (access.setData($"TRUNCATE TABLE MEDICAMENT")) {

            }
        }
    }
}
