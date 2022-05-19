using System;

public class Est_autorisé : CRUD  {
	public string Commentaire { get; set; }
	public Date UneDate { get; set; }
	public Maladie UneMaladie { get; set; }
	public Medicament UnMedicament { get; set; }

	public Est_autorisé(object unMedicament, object uneMaladie, object uneDate, object commentaire) {
		throw new System.NotImplementedException("Not implemented");
	}
	public Est_autorisé(object unMedicament, object uneMaladie, object uneDate) {
		throw new System.NotImplementedException("Not implemented");
	}

	private Medicament medicament;

	private Maladie maladie;
	private Date_autorisation date_autorisation;

}
