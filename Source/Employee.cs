using System;
using System.Collections.Generic;
using System.Text;

namespace Source
{
    public struct Employee
    {
        
            private string _name;
            private Vacancies _vacancy;
            private int _salary;
            private DateTime _dataEnter;

            public Employee(string name, Vacancies vacancy, int salary, DateTime dataEnter)
            {
                _name = name;
                _vacancy = vacancy;
                _salary = salary;
                _dataEnter = dataEnter;
            }

            public string Show()
            {

                string show = String.Format("Name - {0}\n Salary -{1}\n Vacancies - {2}\n receipt date - {3}", _name, _salary, _vacancy, _dataEnter);
                return show;
            }

            public Vacancies GetVacancy()
            {
                return _vacancy;
            }

            public DateTime GetDate()
            {
                return _dataEnter;
            }

            public int GetSalary()
            {
                return _salary;
            }
    }
}
