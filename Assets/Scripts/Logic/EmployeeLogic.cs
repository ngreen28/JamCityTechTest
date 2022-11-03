using System;
using System.Collections.Generic;
using System.Linq;
using Interface;
using Core;
using Enum;

namespace Logic
{
    public class EmployeeLogic: IEmployeeLogic
    {
        public Dictionary<Tuple<Sector, Seniority?>, List<Employee>> Grouping(IEnumerable<Employee> source)
        {
            return source
                .GroupBy(bolt => new { Sector = bolt.sector, Seniority = bolt.seniority })
                .ToDictionary(bolt => new Tuple<Sector, Seniority?>(bolt.Key.Sector, bolt.Key.Seniority), bolt => bolt.OrderBy(x => x.seniority).ToList());
        }

        public IEnumerable<Employee> Filter(IEnumerable<Employee> source, Sector key, Seniority? secondKey)
        {
            return FilterBySeniority(FilterBySector(source, key), secondKey);
        }

        public IEnumerable<Employee> FilterBySector(IEnumerable<Employee> source, Sector key)
        {
            return source.Where(x => x.sector == key).OrderBy(x => x.seniority).ToList();
        }

        public IEnumerable<Employee> FilterBySeniority(IEnumerable<Employee> source, Seniority? key)
        {
            return key.HasValue
                ? source.Where(x => x.seniority == key)
                    .OrderBy(x => x.seniority)
                    .ToList()
                : source.Where(x => x.seniority.HasValue == false)
                    .OrderBy(x => x.seniority)
                    .ToList();
        }
    }
}