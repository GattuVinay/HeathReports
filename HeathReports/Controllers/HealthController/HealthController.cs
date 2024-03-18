using HeathReports.DBContextServices;
using HeathReports.Models.HealthModel;
using HeathReports.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HeathReports.Controllers.HealthController
{
    public class HealthController : Controller
    {
        private readonly HealthRepository _healthRepository;
        private readonly HealthContext _healthContextService;
        private readonly IConfiguration _configuration;
        public HealthController(HealthRepository healthRepository,HealthContext healthContextService,IConfiguration configuration)
        {
            _healthContextService = healthContextService;
            _healthRepository = healthRepository;
            _configuration = configuration;
        }
        public ActionResult PatientDetails()
        {
            try
            {
                //var connectionString = _configuration.GetConnectionString("DefaultConnection");
                return View(_healthRepository.PatientDetails());
            }
            catch (Exception ex) { Console.WriteLine(ex); }
            return View();
        }

        public ActionResult TreatmentRecords() 
        {
            return View(_healthRepository.TreatementRecords());
        }

        public ActionResult MedicalHistoryDetails()
        {
            return View(_healthRepository.MedicalHistoryDetails());
        }
    }
}
