using System.ComponentModel.DataAnnotations;

namespace PatientPortal.Entity
{
    public class PatientsInformation
    {
        [Key] public int PatientId { get; set; }  
        public string PatientName { get; set;}
        public int age { get; set;}
       

        // Navigation property

        public List<DiseaseInformation> Diseases { get; set; }
    }
}
