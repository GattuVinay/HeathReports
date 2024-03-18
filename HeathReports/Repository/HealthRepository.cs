using HeathReports.DBContextServices;
using HeathReports.Interface;
using HeathReports.Models.HealthModel;
using HeathReports.Models.ViewModels;

namespace HeathReports.Repository
{
    public class HealthRepository : IHealth
    {
        private readonly ILogger logger;
        private readonly HealthContext _healthContextService;
        public HealthRepository(HealthContext healthContextService)
        {
            _healthContextService = healthContextService;

        }

        public List<PatientMedicalHistoryViewModel> PatientDetails()
        {
            try
            {
                ////var data = _healthContextService.Patients.ToList();
                //return (from p in _healthContextService.Patients
                //        join mh in _healthContextService.MedicalHistory on p.PatientId equals mh.PatientID
                //        select new PatientMedicalHistoryViewModel
                //        {
                //            ID = p.PatientId,
                //            Gender = p.Gender,
                //            MedicalCondition = mh.MedicalCondition,
                //        }).ToList();


                return (List<PatientMedicalHistoryViewModel>)(from p in _healthContextService.Patients
                                                              join mh in _healthContextService.MedicalHistory on p.PatientId equals mh.PatientID
                                                              where mh.MedicalCondition != null // Optional condition to filter out null medical conditions
                                                              select new PatientMedicalHistoryViewModel
                                                              {
                                                                  Gender = p.Gender,
                                                                  MedicalCondition = mh.MedicalCondition,
                                                              })
              .GroupBy(vm => vm.Gender) // Group by gender
              .Select(group => new
              {
                  Gender = group.Key,
                  Patients = group.ToList() // List of patients in each group
              });
                // return _healthContextService.Patients.ToList();
            }
            catch (Exception ex) { Console.WriteLine(ex); }
            return new List<PatientMedicalHistoryViewModel>();
        }

        public List<PatientMedicalHistoryViewModel> TreatementRecords()
        {
            try
            {
                //var data = _healthContextService.TreatementRecords.ToList();
                //var value = (from t in _healthContextService.TreatementRecords
                //             join m in _healthContextService.MedicalHistory on t.PatientId equals m.PatientID
                //             join p in _healthContextService.Patients on t.PatientId equals p.PatientId
                //             where m.MedicalCondition == "Cancer"
                //             select new
                //             {
                //                 TreatmentType = t.TreatmentType,
                //                 FirstName = p.FirstName,
                //                 Age = p.Age,
                //             }).ToList();

                return (List<PatientMedicalHistoryViewModel>)(from t in _healthContextService.TreatementRecords
                                                              join m in _healthContextService.MedicalHistory on t.PatientId equals m.PatientID
                                                              join p in _healthContextService.Patients on t.PatientId equals p.PatientId
                                                              where m.MedicalCondition == "Cancer"
                                                              select new
                                                              {
                                                                  TreatmentType = t.TreatmentType,
                                                                  FirstName = p.FirstName,
                                                                  Age = p.Age,
                                                              });

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new List<PatientMedicalHistoryViewModel>();
            }

        }

        public List<PatientMedicalHistoryViewModel> MedicalHistoryDetails()
        {
            TreatmentOutcomeByMedicalCondition();
            try
            {
                var result = _healthContextService.Patients
        .Where(p => _healthContextService.TreatementRecords
            .Where(t => t.PatientId == p.PatientId)
            .GroupBy(t => t.PatientId)
            .Any(group => group.Count() > 1))
        .ToList();
                return new List<PatientMedicalHistoryViewModel>();

                //return (List<PatientMedicalHistoryViewModel>)(from t in _healthContextService.TreatementRecords
                //                                              join m in _healthContextService.MedicalHistory on t.PatientId equals m.PatientID
                //                                              join p in _healthContextService.Patients on t.PatientId equals p.PatientId
                //                                              where m.MedicalCondition == "Cancer"
                //                                              select new
                //                                              {
                //                                                  TreatmentType = t.TreatmentType,
                //                                                  FirstName = p.FirstName,
                //                                                  Age = p.Age,
                //                                              });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return new List<PatientMedicalHistoryViewModel>();

            }
        }

        public List<PatientMedicalHistoryViewModel> CountOfPatientsWithMultipleMedicalConditions()
        {
            try
            {
                return (List<PatientMedicalHistoryViewModel>)_healthContextService.Patients
                  .Where(p => p.FirstName.Count() > 1) // Filter patients with multiple conditions
                  .Select(p => new
                  {
                      PatientId = p.PatientId,
                      FirstName = p.FirstName,
                      LastName = p.LastName,
                      ConditionCount = p.FirstName.Count()
                  });
            }
            catch (Exception ex)
            {
                return new List<PatientMedicalHistoryViewModel>();
            }
        }

        public List<PatientMedicalHistoryViewModel> TreatmentOutcomeByMedicalCondition()
        {
            try
            {
                var successfulTreatments = (from record in _healthContextService.TreatementRecords
                                           where record.OutCome == "Successful"
                                           group record by record.TreatmentType into groupedRecords
                                           where groupedRecords.Count() > 1
                                           select new
                                           {
                                               TreatmentType = groupedRecords.Key,
                                               SuccessfulCount = groupedRecords.Count()
                                           }).ToList();
                return (List<PatientMedicalHistoryViewModel>) (from record in _healthContextService.TreatementRecords
                                                             where record.OutCome == "Successful"
                                                             group record by record.TreatmentType into groupedRecords
                                                             where groupedRecords.Count() > 1
                                                             select new
                                                             {
                                                                 TreatmentType = groupedRecords.Key,
                                                                 SuccessfulCount = groupedRecords.Count()
                                                             });
                
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
                return new List<PatientMedicalHistoryViewModel>();
            }
        }

    }

}
