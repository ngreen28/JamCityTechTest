using System;
using System.Collections;
using System.Collections.Generic;
using Enum;
using UnityEngine;

namespace Core
{
    public class Employee
    {
        public Guid id { get; set; }
        public Sector sector { get; set; }
        public Seniority? seniority { get; set; }

        public Employee(Sector sector)
        {
            id = Guid.NewGuid();
            this.sector = sector;
        }

        public Employee(Sector sector, Seniority? seniority)
        {
            id = Guid.NewGuid();
            this.sector = sector;
            this.seniority = seniority;
        }
    }
}