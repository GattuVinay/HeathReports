using HeathReports.Models.HealthModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace HeathReports.Models.HealthModel
{
    [Table("Patients")]
    public class Patients
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("PatientId")]
        public int PatientId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        //public List<MedicalHistory> History { get; set; }

    }
}
