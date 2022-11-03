using Interface;

namespace Logic
{
    public class SalaryCalculator
    {
        public decimal Calculate(ISalaryCalculator calculator) => calculator.CalculateTotalSalary();
    }
}
