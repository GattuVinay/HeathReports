using HeathReports.Models.HealthModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace HeathReports.DBContextServices
{
    public class HealthContextService : IdentityDbContext
    {

        public HealthContextService(DbContextOptions<HealthContextService> options) : base(options)
        {
            
        }

        public Microsoft.EntityFrameworkCore.DbSet<Patient> Patients { get; set; }

        public Microsoft.EntityFrameworkCore.DbSet<TreatementRecords> TreatementRecords { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<MedicalHistory> MedicalHistory { get; set; }

        


    }
}
