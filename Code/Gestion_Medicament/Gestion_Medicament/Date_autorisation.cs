using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class Date_autorisation : CRUD<Date_autorisation>{
    private DateTime date;

	public Date_autorisation() {
	
	}

	private Est_autorisÚ[] est_autorisÚs;

    public DateTime Date
    {
        get
        {
            return this.date;
        }

        set
        {
            this.date = value;
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

    public List<Date_autorisation> FindAll()
    {
        List<Date_autorisation> listeDates = new List<Date_autorisation>();
        DataAccess access = new DataAccess();
        SqlDataReader reader;
        try
        {
            if (access.openConnection())
            {
                reader = access.getData("select * from [BT3].[IUT-ACY\\sztarkj].[DATE_AUTORISATION]");
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Date_autorisation uneDate = new Date_autorisation();
                        uneDate.Date = reader.GetDateTime(0);
                        listeDates.Add(uneDate);
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
        return listeDates;
    }

    public List<Date_autorisation> FindBySelection(ref string criteres)
    {
        throw new NotImplementedException();
    }

}
