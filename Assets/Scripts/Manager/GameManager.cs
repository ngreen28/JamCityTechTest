using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Core;
using Enum;
using Extension;
using Interface;
using Logic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Manager
{
    public class GameManager : Singleton<GameManager>
    {
        [Header("Configuration")]
        public UIDocument uIDocument;
        public VisualTreeAsset uIItemObject;
    
        [Header("Runtime")]
        public VisualElement rootVisualElement;
        public List<Salary> salaries;
        public List<Employee> employers = new List<Employee>();

        private readonly SalaryCalculator _calculatorContext;
        private readonly IEmployeeLogic _employeeLogic;

        public GameManager()
        {
            _calculatorContext = new SalaryCalculator();
            _employeeLogic = new EmployeeLogic();
            InitializeSalaries();
            InitializeEmployers();
        }

        private void Awake()
        {
            if (uIDocument == null) throw new Exception("UIDocument Required");
            if (uIItemObject == null) throw new Exception("VisualTreeAsset Required");
            rootVisualElement = uIDocument.rootVisualElement;
        }


        private void Update()
        {
            if (rootVisualElement == null) throw new Exception("rootVisualElement Required");
            salaries.Update(rootVisualElement, "SalaryList", uIItemObject, _calculatorContext);
            employers.Update(rootVisualElement, "EmployerList", uIItemObject);
            TotalCalculator();
        }

        private void InitializeSalaries()
        {
            #region Populating

            salaries = new List<Salary>
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

            #endregion
        }

        private void InitializeEmployers()
        {
            #region Populating
            
            employers = new List<Employee>() { new Employee(Sector.CEO) };

            for (var i = 0; i < 13; i++)
                employers.Add(new Employee(Sector.HR, Seniority.Junior));
            for (var i = 0; i < 2; i++)
                employers.Add(new Employee(Sector.HR, Seniority.SemiSenior));
            for (var i = 0; i < 5; i++)
                employers.Add(new Employee(Sector.HR, Seniority.Senior));

            for (var i = 0; i < 50; i++)
                employers.Add(new Employee(Sector.Engineering, Seniority.Senior));
            for (var i = 0; i < 68; i++)
                employers.Add(new Employee(Sector.Engineering, Seniority.SemiSenior));
            for (var i = 0; i < 32; i++)
                employers.Add(new Employee(Sector.Engineering, Seniority.Junior));

            for (var i = 0; i < 20; i++)
                employers.Add(new Employee(Sector.Artist, Seniority.SemiSenior));
            for (var i = 0; i < 5; i++)
                employers.Add(new Employee(Sector.Artist, Seniority.Senior));

            for (var i = 0; i < 15; i++)
                employers.Add(new Employee(Sector.Design, Seniority.Junior));
            for (var i = 0; i < 10; i++)
                employers.Add(new Employee(Sector.Design, Seniority.Senior));

            for (var i = 0; i < 20; i++)
                employers.Add(new Employee(Sector.PMs, Seniority.SemiSenior));
            for (var i = 0; i < 10; i++)
                employers.Add(new Employee(Sector.PMs, Seniority.Senior));
            #endregion
        }
        
        private void TotalCalculator()
        {
            decimal totalSalary = (from salary in salaries let employersList = _employeeLogic.Filter(employers, salary.sector, salary.seniority) select (_calculatorContext.Calculate(salary) * employersList.Count())).Sum();
            if (rootVisualElement.GetReference<Label>("TotalSalary") != null)
            {
                rootVisualElement.GetReference<Label>("TotalSalary").text = totalSalary.ToString(CultureInfo.InvariantCulture);
            }
        }

    
    }
}
