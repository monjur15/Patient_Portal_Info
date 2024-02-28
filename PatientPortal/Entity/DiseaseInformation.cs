using System.ComponentModel.DataAnnotations;

namespace PatientPortal.Entity
{
    public class DiseaseInformation
    {
        [Key] public int DiseaseID { get; set; }

        public string DiseaseName { get; set; }

        // Foreign Key
        public int PatientId {  get; set; } 

        // Navigation property
        public PatientsInformation PatientsInformation { get; set; }
    }
}
