using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Repo
{
    internal class CommercialInsurance : VehicleInsurance
    {
        public CommercialInsurance(int pNumber, double insuredAmount) : base(pNumber, insuredAmount)
        {
        }

        public override double CalculatePremium()
        {
            return InsuredAmount * 0.07;
        }
    }
}
