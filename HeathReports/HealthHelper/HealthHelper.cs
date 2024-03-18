namespace HeathReports.HealthHelper
{
    public class HealthHelper
    {
        // Helper method to calculate age based on birth date
        public int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-age))
                age--; // Adjust age if birth date hasn't occurred yet this year
            return age;
        }
    }
}
