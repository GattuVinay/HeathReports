using HeathReports.Models.HealthModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace HeathReports.Models.HealthModel
{
    public class MedicalHistory
    {
        [Key]
        public Guid HistoryId { get; set; }

        [ForeignKey ("Patient")]
        public int PatientID { get; set; }

        public string MedicalCondition { get; set; }

        public DateOnly DiagnosisDate { get; set; }

        public string Treatement {  get; set; }
    }
}
