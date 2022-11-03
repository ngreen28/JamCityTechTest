using Interface;
using Enum;

namespace Core
{
    public class Salary : ISalaryCalculator
    {
        public Sector sector { get; set; }
        public Seniority? seniority { get; set; }
        public double BaseSalary;
        public float IncrementPercentage;

        public Salary(Sector sector, double baseSalary, float incrementPercentage)
        {
            this.sector = sector;
            BaseSalary = baseSalary;
            IncrementPercentage = incrementPercentage;
        }

        public Salary(Sector sector, Seniority? seniority, double baseSalary, float incrementPercentage)
        {
            this.sector = sector;
            this.seniority = seniority;
            BaseSalary = baseSalary;
            IncrementPercentage = incrementPercentage;
        }

        public decimal CalculateTotalSalary()
        {
            return (decimal)(BaseSalary * (1 + (IncrementPercentage / 100)));
        }
    }
}
