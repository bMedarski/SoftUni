namespace P01_HospitalDatabase.Data.Models
{
    public class PatientMedicament
    {
		public int PatiantId { get; set; }
		public Patient Patient { get; set; }

		public int MedicamentId { get; set; }
		public Medicament Medicament { get; set; } 
    }
}
