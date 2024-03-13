using HeathReports.DBContextServices;
using HeathReports.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HeathReports.Controllers.HealthController
{
    public class HealthController : Controller
    {
        private readonly HealthRepository _healthRepository;
        private readonly HealthContextService _healthContextService;
        public HealthController(HealthRepository healthRepository,HealthContextService healthContextService)
        {
            _healthContextService = healthContextService;
            _healthRepository = healthRepository;
        }
        public IActionResult PatientsDetails()
        {
            return View(_healthRepository.PatientDetails());
        }

        public IActionResult TreatmentRecords() 
        {
            return View(_healthRepository.TreatementRecords());
        }

        public IActionResult MedicalHistoryDetails()
        {
            return View(_healthRepository.MedicalHistoryDetails());
        }
    }
}
