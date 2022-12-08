using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    public class Employees
    {
        public int Salary;
        public int Level;
        public int Wallet;

        public Employees(int salar, int level, int wallet)
        {
            Salary = salar;
            Level = level;
            Wallet = wallet;
        }
        public Employees()
        {
            Salary = 0;
            Level = 0;
            Wallet = 0;
        }

        public void Work(int wall)
        {
            Console.WriteLine("Работаю!");
            Wallet += 10_000;
            wall = Wallet;
        }
        public void OnDownSalary()
        {
            Console.WriteLine("Зарплата работника понижена");
            if (Salary >= 100) Salary -= 100;
            else Salary = 0;
        }
        public void OnUpLevel()
        {
            Console.WriteLine("Нас повысили!!!Ураааааа");
            Level++;
        }
        public override string ToString()
        {
            return $"Работник: Зарплата = {Salary}, Кошелёк = {Wallet}, Зарплата = {Salary}, Уровень = {Level}";
        }
        public void PrintEmployees(List<string> parm)
        {
            foreach (var product in parm)
            {
                Console.WriteLine(product);
            }

        }
    }
}
