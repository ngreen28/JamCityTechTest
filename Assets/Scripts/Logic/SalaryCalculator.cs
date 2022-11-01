using System.Collections.Generic;
using JCityTechTest.Core;
using JCityTechTest.Interface;

namespace JCityTechTest.Logic
{
    public class SalaryCalculator
    {
        public decimal Calculate(ISalaryCalculator calculator) => calculator.CalculateTotalSalary();
    }
}
