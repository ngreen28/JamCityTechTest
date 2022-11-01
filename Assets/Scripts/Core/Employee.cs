using System;
using System.Collections;
using System.Collections.Generic;
using JCityTechTest.Enum;
using UnityEngine;

namespace JCityTechTest.Core
{
    public class Employee
    {
        public Guid Id { get; set; }
        public Sector Sector { get; set; }
        public Seniority? Seniority { get; set; }

        public Employee(Sector sector)
        {
            Id = Guid.NewGuid();
            Sector = sector;
        }

        public Employee(Sector sector, Seniority? seniority)
        {
            Id = Guid.NewGuid();
            Sector = sector;
            Seniority = seniority;
        }
    }
}