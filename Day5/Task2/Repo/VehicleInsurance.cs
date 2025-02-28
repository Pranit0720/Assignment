using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Repo
{
    abstract class VehicleInsurance
    {
        public int PolicyNumber { get; set; }
        public double InsuredAmount { get; set; }
        protected VehicleInsurance( int pNumber,double insuredAmount)
        {
            PolicyNumber = pNumber;
            InsuredAmount = insuredAmount;
            
        }
        

        public abstract double CalculatePremium();
    }
}
