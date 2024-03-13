using HeathReports.Models.HealthModel;

namespace HeathReports.Interface
{
    public interface IHealth
    {
        List<Patient> PatientDetails();

        List<TreatementRecords> TreatementRecords();

        List<MedicalHistory> MedicalHistoryDetails();
    }
}
