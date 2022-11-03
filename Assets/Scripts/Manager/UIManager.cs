using System;
using System.Collections.Generic;
using System.Globalization;
using Core;
using Extension;
using Logic;
using UnityEngine.UIElements;

namespace Manager
{
    public static class UiManager
    {
        public static void Update<T>(this List<T> values, VisualElement rootVisualElement, string uiReference, VisualTreeAsset uiObject, SalaryCalculator calculator = null) where T : class
        {
            if (rootVisualElement == null) throw new Exception("VisualElement Required");
            RemoveActiveStatus(rootVisualElement, uiReference);
            InternalUpdateUi(values, rootVisualElement, uiReference, uiObject, calculator);
        }

        private static void RemoveActiveStatus(VisualElement rootVisualElement, string uiReference)
        {
            if (rootVisualElement.GetReference<GroupBox>(uiReference).childCount > 0)
                rootVisualElement.RemoveAllChildren<GroupBox>(uiReference);
        }

        private static void InternalUpdateUi<T>(List<T> values, VisualElement rootVisualElement, string uiReference, VisualTreeAsset uiObject, SalaryCalculator calculator = null) where T : class
        {
            values.ForEach(x =>
            {
                var sprite = uiObject.CloneTree();
                if (x.GetType() == typeof(Salary))
                {
                    if (x is Salary salary)
                    {
                        InsertLabelRecord(sprite, salary.sector.ToString(), (100 / 5f));
                        InsertLabelRecord(sprite, salary.seniority.ToString(), 100 / 5f);
                        InsertLabelRecord(sprite, salary.BaseSalary.ToString(CultureInfo.InvariantCulture), 100 / 5f);
                        InsertLabelRecord(sprite, salary.IncrementPercentage.ToString(CultureInfo.InvariantCulture), 100 / 5f);
                        InsertLabelRecord(sprite, calculator.Calculate(salary).ToString(CultureInfo.InvariantCulture), 100 / 5f);
                    }
                }
                else if (x.GetType() == typeof(Employee))
                {
                    if (x is Employee employee)
                    {
                        InsertLabelRecord(sprite, employee.id.ToString(), (100 / 1.8f));
                        InsertLabelRecord(sprite, employee.sector.ToString(), (100 / 3.5f));
                        InsertLabelRecord(sprite, employee.seniority.ToString(), (100 / 3.5f));
                    }
                }
                rootVisualElement.AddChildren<GroupBox, VisualElement>(uiReference, sprite);
            });
        }

        private static void InsertLabelRecord(VisualElement sprite, string value, float width)
        {
            var record = new Label(value);
            record.style.width = Length.Percent(width);
            sprite.AddChildren<VisualElement, Label>("Record", record);
        }
    }
}
