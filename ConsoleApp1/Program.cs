using Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Please, enter ammout of employees: ");
            int countWorker;
            int.TryParse(ReadLine(), out countWorker);

            Employee[] employee = new Employee[countWorker];
            int salary;
            string name;
            int choose;
            int day, month, year;
            Vacancies vacancy;

            for (int i = 1; i <= countWorker; i++)
            {
                WriteLine("Enter a name {0} employes", i);
                name = ReadLine();

                WriteLine("Choose a vacantion: 1: Boss, 2: Manager, 3: Clark, 4: Seller");
                int.TryParse(ReadLine(), out choose);
                if (choose == 1)
                {
                    vacancy = Vacancies.Manager;
                }

                else if (choose == 2)
                {
                    vacancy = Vacancies.Boss;
                }

                else if (choose == 3)
                {
                    vacancy = Vacancies.Clerk;
                }

                else
                {
                    vacancy = Vacancies.Salesman;
                }

                WriteLine("Enter of sallary {0} employees", i);
                int.TryParse(ReadLine(), out salary);

                WriteLine("Enter a day, when eployees was start a work:");
                int.TryParse(ReadLine(), out day);
                WriteLine("Enter a month, when eployees was start a work:");
                int.TryParse(ReadLine(), out month);
                WriteLine("Enter a year, when eployees was start a work:");
                int.TryParse(ReadLine(), out year);

                DateTime enterDate = new DateTime(year, month, day);
                employee[i - 1] = new Employee(name, vacancy, salary, enterDate);
            }

            FullInfo(employee);
            ManagerInfo(employee);
            LaterBoss(employee);

            ReadLine();
        }

        private static void LaterBoss(Employee[] employee)
        {
            int compare;
            Employee boss = employee[0];
            string show;

            for (int i = 0; i < employee.Length; i++)
            {
                if (employee[i].GetVacancy() == Vacancies.Boss)
                {
                    boss = employee[i];
                }
            }

            WriteLine("Eployees, who acsseable after a boss :");
            for (int i = 0; i < employee.Length; i++)
            {
                compare = boss.GetDate().CompareTo(employee[i].GetDate());
                if (compare == -1)
                {
                    show = employee[i].Show();
                    WriteLine(show);
                }
            }
        }

        private static void ManagerInfo(Employee[] employee)
        {

            int salaryClerk = 0;
            int countClerk = 0;
            string show;

            for (int i = 0; i < employee.Length; i++)
            {
                if (employee[i].GetVacancy() == Vacancies.Clerk)
                {
                    salaryClerk += employee[i].GetSalary();
                    countClerk++;
                }
            }

            salaryClerk = salaryClerk / countClerk;

            WriteLine("Managers :");
            for (int i = 0; i < employee.Length; i++)
            {
                if (employee[i].GetVacancy() == Vacancies.Manager)
                {
                    if (employee[i].GetSalary() > salaryClerk)
                    {
                        show = employee[i].Show();
                        WriteLine(show);
                        
                    }
                }
            }
        }

        private static void FullInfo(Employee[] employee)
        {
            string show;
            WriteLine("All of employees :");

            for (int i = 0; i < employee.Length; i++)
            {
                show = employee[i].Show();
                WriteLine(show);
                
            }
        }
    }
}
