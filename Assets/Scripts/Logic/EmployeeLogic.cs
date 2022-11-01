using System;
using System.Collections.Generic;
using System.Linq;
using JCityTechTest.Core;
using JCityTechTest.Enum;
using JCityTechTest.Interface;

namespace JCityTechTest.Logic
{
    public class EmployeeLogic: IEmployeeLogic
    {
        public Dictionary<Tuple<Sector, Seniority?>, List<Employee>> Grouping(IEnumerable<Employee> source)
        {
            return source
                .GroupBy(bolt => new { bolt.Sector, bolt.Seniority })
                .ToDictionary(bolt => new Tuple<Sector, Seniority?>(bolt.Key.Sector, bolt.Key.Seniority), bolt => bolt.OrderBy(x => x.Seniority).ToList());
        }

        public IEnumerable<Employee> Filter(IEnumerable<Employee> source, Sector key, Seniority? secondKey)
        {
            return FilterBySeniority(FilterBySector(source, key), secondKey);
        }

        public IEnumerable<Employee> FilterBySector(IEnumerable<Employee> source, Sector key)
        {
            return source.Where(x => x.Sector == key);
        }

        public IEnumerable<Employee> FilterBySeniority(IEnumerable<Employee> source, Seniority? key)
        {
            if (key.HasValue)
                return source.Where(x => x.Seniority == key);
            else
                return source.Where(x => x.Seniority.HasValue == false);
        }
    }
}