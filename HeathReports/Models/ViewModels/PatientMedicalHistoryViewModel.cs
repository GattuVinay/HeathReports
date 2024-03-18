using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HeathReports.Models.ViewModels
{
    [Keyless]
    public class PatientMedicalHistoryViewModel
    {
        
        public int HistoryId { get; set; }
        public string Gender { get; set; }
        public string MedicalCondition { get; set; }

        public string PatientID { get;}
        public string Age { get;}
        public string FirstName { get;}
        public string TreatmentType { get;}



    }
}
