using System.Collections.Generic;
using JCityTechTest.Enum;
using JCityTechTest.Interface;

namespace JCityTechTest.Core
{
    public class Salary : ISalaryCalculator
    {
        public Sector Sector { get; set; }
        public Seniority? Seniority { get; set; }
        public double BaseSalary;
        public float IncrementPercentage;

        public Salary(Sector sector, double baseSalary, float incrementPercentage)
        {
            Sector = sector;
            BaseSalary = baseSalary;
            IncrementPercentage = incrementPercentage;
        }

        public Salary(Sector sector, Seniority? seniority, double baseSalary, float incrementPercentage)
        {
            Sector = sector;
            Seniority = seniority;
            BaseSalary = baseSalary;
            IncrementPercentage = incrementPercentage;
        }

        public decimal CalculateTotalSalary()
        {
            return (decimal)(BaseSalary * (1 + (IncrementPercentage / 100)));
        }
    }
}
