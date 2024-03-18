using HeathReports.Models.HealthModel;
using HeathReports.Models.ViewModels;

namespace HeathReports.Interface
{
    public interface IHealth
    {
        List<PatientMedicalHistoryViewModel> PatientDetails();

        List<PatientMedicalHistoryViewModel>TreatementRecords();

        List<PatientMedicalHistoryViewModel> MedicalHistoryDetails();
        List<PatientMedicalHistoryViewModel> CountOfPatientsWithMultipleMedicalConditions();
        List<PatientMedicalHistoryViewModel> TreatmentOutcomeByMedicalCondition();
    }
}
