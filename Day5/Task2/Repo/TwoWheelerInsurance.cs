namespace Task2.Repo
{
    internal class TwoWheelerInsurance : VehicleInsurance
    {
        public TwoWheelerInsurance(int pNumber, double insuredAmount) : base(pNumber, insuredAmount)
        {
        }

        public override double CalculatePremium()
        {

            return InsuredAmount * 0.02;
        }
    }
}
