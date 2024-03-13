using HeathReports.Models.HealthModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeathReports.Models.HealthModel
{
    public class MedicalHistory
    {
        [ForeignKey ("Patient")]
        public int PatientID { get; set; }

        public string MedicalCondition { get; set; }

        public DateOnly DiagnosisDate { get; set; }

        public string Treatement {  get; set; }
    }
}
