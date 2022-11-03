using System.Collections.Generic;
using Core;
using Enum;
using Logic;
using NUnit.Framework;

namespace Tests.EditModeTest
{
    [TestFixture]
    public class SalaryTest
    {
        public List<Salary> Salaries = new List<Salary>();
        public SalaryCalculator SalaryCalculator;

        [SetUp]
        public void SetUp()
        {
            SalaryCalculator = new SalaryCalculator();
            Salaries = new List<Salary>
            {
                new Salary(Sector.CEO, 20000, 100),
                new Salary(Sector.HR, Seniority.Junior, 500, 0.5f),
                new Salary(Sector.HR, Seniority.SemiSenior, 1000, 2),
                new Salary(Sector.HR, Seniority.Senior, 1500, 5),
                new Salary(Sector.Engineering, Seniority.Junior, 1500, 5),
                new Salary(Sector.Engineering, Seniority.SemiSenior, 3000, 7),
                new Salary(Sector.Engineering, Seniority.Senior, 5000, 10),
                new Salary(Sector.Artist, Seniority.SemiSenior, 1200, 2.5f),
                new Salary(Sector.Artist, Seniority.Senior, 2000, 5),
                new Salary(Sector.Design, Seniority.Junior, 800, 4),
                new Salary(Sector.Design, Seniority.Senior, 2000, 7),
                new Salary(Sector.PMs, Seniority.SemiSenior, 2400, 5),
                new Salary(Sector.PMs, Seniority.Senior, 4000, 10)
            };
        }

        [TestCase(Sector.CEO, null, 20000, 100, ExpectedResult = 40000)]
        [TestCase(Sector.HR, Seniority.Junior, 500, 0.5f, ExpectedResult = 502d)]
        [TestCase(Sector.HR, Seniority.SemiSenior, 1000, 2, ExpectedResult = 1020d)]
        [TestCase(Sector.HR, Seniority.Senior, 1500, 5, ExpectedResult = 1575d)]
        [TestCase(Sector.Engineering, Seniority.Junior, 1500, 5, ExpectedResult = 1575d)]
        [TestCase(Sector.Engineering, Seniority.SemiSenior, 3000, 7, ExpectedResult = 3210d)]
        [TestCase(Sector.Engineering, Seniority.Senior, 5000, 10, ExpectedResult = 5500d)]
        [TestCase(Sector.Artist, Seniority.SemiSenior, 1200, 2.5f, ExpectedResult = 1230d)]
        [TestCase(Sector.Artist, Seniority.Senior, 2000, 5, ExpectedResult = 2100d)]
        [TestCase(Sector.Design, Seniority.Junior, 800, 4, ExpectedResult = 832d)]
        [TestCase(Sector.Design, Seniority.Senior, 2000, 7, ExpectedResult = 2140d)]
        [TestCase(Sector.PMs, Seniority.SemiSenior, 2400, 5, ExpectedResult = 2520d)]
        [TestCase(Sector.PMs, Seniority.Senior, 4000, 10, ExpectedResult = 4400d)]
        public decimal CalculateSalary(Sector sector, Seniority? seniority, double baseSalary, float increment)
        {
            var salary = new Salary(sector, seniority, baseSalary, increment);
            return decimal.Round(SalaryCalculator.Calculate(salary));
        }
    }
}