
using System.Collections.Generic;
using System.Linq;
using JCityTechTest.Core;
using JCityTechTest.Enum;
using JCityTechTest.Interface;
using JCityTechTest.Logic;
using NUnit.Framework;

[TestFixture]
public class EmployeeTest
{
    public IEmployeeLogic employeeLogic;
    public List<Employee> employers = new();

    [SetUp]
    public void SetUp()
    {
        employeeLogic = new EmployeeLogic();
        employers = new() { new Employee(Sector.CEO) };

        for (int i = 0; i < 13; i++)
            employers.Add(new Employee(Sector.HR, Seniority.Junior));
        for (int i = 0; i < 2; i++)
            employers.Add(new Employee(Sector.HR, Seniority.SemiSenior));
        for (int i = 0; i < 5; i++)
            employers.Add(new Employee(Sector.HR, Seniority.Senior));

        for (int i = 0; i < 50; i++)
            employers.Add(new Employee(Sector.Engineering, Seniority.Senior));
        for (int i = 0; i < 68; i++)
            employers.Add(new Employee(Sector.Engineering, Seniority.SemiSenior));
        for (int i = 0; i < 32; i++)
            employers.Add(new Employee(Sector.Engineering, Seniority.Junior));

        for (int i = 0; i < 20; i++)
            employers.Add(new Employee(Sector.Artist, Seniority.SemiSenior));
        for (int i = 0; i < 5; i++)
            employers.Add(new Employee(Sector.Artist, Seniority.Senior));

        for (int i = 0; i < 15; i++)
            employers.Add(new Employee(Sector.Design, Seniority.Junior));
        for (int i = 0; i < 10; i++)
            employers.Add(new Employee(Sector.Design, Seniority.Senior));

        for (int i = 0; i < 20; i++)
            employers.Add(new Employee(Sector.PMs, Seniority.SemiSenior));
        for (int i = 0; i < 10; i++)
            employers.Add(new Employee(Sector.PMs, Seniority.Senior));
    }

    // A Test behaves as an ordinary method
    [TestCase(Sector.CEO, ExpectedResult = 1)]
    [TestCase(Sector.HR, ExpectedResult = 20)]
    [TestCase(Sector.Artist, ExpectedResult = 25)]
    [TestCase(Sector.Engineering, ExpectedResult = 150)]
    [TestCase(Sector.Design, ExpectedResult = 25)]
    [TestCase(Sector.PMs, ExpectedResult = 30)]
    public int FilterBySector(Sector sector)
    {
        return employeeLogic.FilterBySector(employers, sector).ToList().Count;
    }

    [TestCase(null, ExpectedResult = 1)]
    [TestCase(Seniority.Junior, ExpectedResult = 60)]
    [TestCase(Seniority.SemiSenior, ExpectedResult = 110)]
    [TestCase(Seniority.Senior, ExpectedResult = 80)]
    public int FilterBySeniority(Seniority? seniority)
    {
        return employeeLogic.FilterBySeniority(employers, seniority).ToList().Count;
    }

    [TestCase(Sector.CEO, null, ExpectedResult = 1)]
    [TestCase(Sector.HR, Seniority.Junior, ExpectedResult = 13)]
    [TestCase(Sector.HR, Seniority.SemiSenior, ExpectedResult = 2)]
    [TestCase(Sector.HR, Seniority.Senior, ExpectedResult = 5)]
    [TestCase(Sector.Engineering, Seniority.Junior, ExpectedResult = 32)]
    [TestCase(Sector.Engineering, Seniority.SemiSenior, ExpectedResult = 68)]
    [TestCase(Sector.Engineering, Seniority.Senior, ExpectedResult = 50)]
    [TestCase(Sector.Artist, Seniority.SemiSenior, ExpectedResult = 20)]
    [TestCase(Sector.Artist, Seniority.Senior, ExpectedResult = 5)]
    [TestCase(Sector.Design, Seniority.Junior, ExpectedResult = 15)]
    [TestCase(Sector.Design, Seniority.Senior, ExpectedResult = 10)]
    [TestCase(Sector.PMs, Seniority.SemiSenior, ExpectedResult = 20)]
    [TestCase(Sector.PMs, Seniority.Senior, ExpectedResult = 10)]
    public int Filter(Sector sector, Seniority? seniority)
    {
        return employeeLogic.Filter(employers, sector, seniority).ToList().Count;
    }

    [TestCase(Sector.CEO, null, ExpectedResult = 1)]
    [TestCase(Sector.HR, Seniority.Junior, ExpectedResult = 13)]
    [TestCase(Sector.HR, Seniority.SemiSenior, ExpectedResult = 2)]
    [TestCase(Sector.HR, Seniority.Senior, ExpectedResult = 5)]
    [TestCase(Sector.Engineering, Seniority.Junior, ExpectedResult = 32)]
    [TestCase(Sector.Engineering, Seniority.SemiSenior, ExpectedResult = 68)]
    [TestCase(Sector.Engineering, Seniority.Senior, ExpectedResult = 50)]
    [TestCase(Sector.Artist, Seniority.SemiSenior, ExpectedResult = 20)]
    [TestCase(Sector.Artist, Seniority.Senior, ExpectedResult = 5)]
    [TestCase(Sector.Design, Seniority.Junior, ExpectedResult = 15)]
    [TestCase(Sector.Design, Seniority.Senior, ExpectedResult = 10)]
    [TestCase(Sector.PMs, Seniority.SemiSenior, ExpectedResult = 20)]
    [TestCase(Sector.PMs, Seniority.Senior, ExpectedResult = 10)]
    public int Grouping(Sector sector, Seniority? seniority)
    {
        int amount = 0;
        foreach(var record in employeeLogic.Grouping(employers).Where(x => x.Key.Item1 == sector && x.Key.Item2 == seniority))
        {
            amount = record.Value.Count;
        }
        return amount;
    }
}