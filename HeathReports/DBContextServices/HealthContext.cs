using HeathReports.Models.HealthModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;
using HeathReports.Models.ViewModels;

namespace HeathReports.DBContextServices
{
    public class HealthContext : DbContext
    {

        public HealthContext(DbContextOptions<HealthContext> options) : base(options)
        {
        }
        public DbSet<Patients> Patients { get; set; }

        public DbSet<TreatementRecords> TreatementRecords { get; set; }
        public DbSet<MedicalHistory> MedicalHistory { get; set; }
        public DbSet<HeathReports.Models.ViewModels.PatientMedicalHistoryViewModel> PatientMedicalHistoryViewModel { get; set; } = default!;




    }
}
