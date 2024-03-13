using HeathReports.Models.HealthModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeathReports.Models.HealthModel
{
    public class TreatementRecords
    {
        [ForeignKey ("Patient")]
        public int PatientId { get; set; }

        public string TreatmentType { get; set; }

        public DateOnly TreatementDate {  get; set; }

        public string OutCome { get; set; }

    }
}

