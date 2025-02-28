using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Model
{
    internal class Bank
    {
        public long AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public override string ToString()
        {
            return $"Name:{AccountHolderName}\tAccount Number:{AccountNumber}";
        }
    }
}
