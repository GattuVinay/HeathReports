using HeathReports.Models.HealthModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace HeathReports.Models.HealthModel
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

    }
}
