using System;
using System.Collections.Generic;
using JCityTechTest.Core;
using JCityTechTest.Enum;

namespace JCityTechTest.Interface
{
    public interface IEmployeeLogic
    {
        IEnumerable<Employee> Filter(IEnumerable<Employee> source, Sector key, Seniority? secondKey);
        IEnumerable<Employee> FilterBySector(IEnumerable<Employee> source, Sector key);
        IEnumerable<Employee> FilterBySeniority(IEnumerable<Employee> source, Seniority? key);

        Dictionary<Tuple<Sector, Seniority?>, List<Employee>> Grouping(IEnumerable<Employee> source);
    }
}
