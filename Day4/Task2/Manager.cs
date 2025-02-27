﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    internal class Manager:Employee
    {
        public Double Bonus { get; set; }
        public Manager(string name, double salary,double bonus) : base(name, salary)
        {
            Bonus = bonus;
        }
        public override void DisplayDetails()
        {
            //Console.WriteLine($"Empname:{EmpName}");
            //Console.WriteLine($"EmpSalary:{EmpSalary}");
            Console.WriteLine($"Bonus:{Bonus}");
        }

    }
}
