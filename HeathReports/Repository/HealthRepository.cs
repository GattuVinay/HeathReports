using HeathReports.DBContextServices;
using HeathReports.Interface;
using HeathReports.Models.HealthModel;

namespace HeathReports.Repository
{
    public class HealthRepository : IHealth
    {
        private readonly HealthContextService _healthContextService;
        public HealthRepository(HealthContextService healthContextService)
        {
            _healthContextService = healthContextService;
        }

        public List<Patient> PatientDetails()
        {
            return _healthContextService.Patients.ToList();

        }

        public List<TreatementRecords> TreatementRecords()
        {
            return _healthContextService.TreatementRecords.ToList();

        }

        public List<MedicalHistory> MedicalHistoryDetails()
        {
           
            return _healthContextService.MedicalHistory.ToList();

        }

    }

}
