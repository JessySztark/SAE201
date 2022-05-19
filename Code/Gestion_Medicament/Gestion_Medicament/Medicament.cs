using System;

public class Medicament {
	public int Idmedicament { get; set; }
	public CategorieMedicament UneCategorie { get; set; }
	public Medicament NomMedicament { get; set; }

	public Medicament(object idmedicament, object uneCategorie, object nomMedicament) {
		throw new System.NotImplementedException("Not implemented");
	}
	public Medicament(object uneCategorie, object nomMedicament) {
		throw new System.NotImplementedException("Not implemented");
	}

	private CategorieMedicament[] categorieMedicaments;
	private Est_autorisé[] est_autorisés;

}
