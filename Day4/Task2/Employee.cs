using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Employee
    {
        public string EmpName { get; set; }
        public double EmpSalary { get; set; }
        public Employee(string name,double salary)
        {
            EmpName = name; 
            EmpSalary = salary;
        }
       
        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Empname:{EmpName}");
            Console.WriteLine($"EmpSalary:{EmpSalary}");
        }
    }
}
