using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Repo
{
    internal class FourWheeler : VehicleInsurance
    {
        public FourWheeler(int pNumber, double insuredAmount) : base(pNumber, insuredAmount)
        {
        }

        public override double CalculatePremium()
        {
            return InsuredAmount*0.05;
        }
    }
}
