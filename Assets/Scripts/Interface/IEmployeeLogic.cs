using System;
using System.Collections.Generic;
using Core;
using Enum;

namespace Interface
{
    public interface IEmployeeLogic
    {
        IEnumerable<Employee> Filter(IEnumerable<Employee> source, Sector key, Seniority? secondKey);
        IEnumerable<Employee> FilterBySector(IEnumerable<Employee> source, Sector key);
        IEnumerable<Employee> FilterBySeniority(IEnumerable<Employee> source, Seniority? key);

        Dictionary<Tuple<Sector, Seniority?>, List<Employee>> Grouping(IEnumerable<Employee> source);
    }
}
