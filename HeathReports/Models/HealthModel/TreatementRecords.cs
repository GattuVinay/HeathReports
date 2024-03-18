using HeathReports.Models.HealthModel;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeathReports.Models.HealthModel
{
    [Keyless]
    public class TreatementRecords
    {
        //[Key]
        //public PrimaryKeyAttribute ?RecordId { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        public string TreatmentType { get; set; }

        public DateOnly TreatementDate { get; set; }

        public string OutCome { get; set; }

    }
}

