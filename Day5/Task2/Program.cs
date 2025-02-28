using Task2.Repo;

namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VehicleInsurance bike1=new TwoWheelerInsurance(1234,200000.80);
            Console.WriteLine($"Policy Number:{bike1.PolicyNumber}\tInsured Amount:{bike1.InsuredAmount}\nTwo Wheeler primum:{bike1.CalculatePremium()}");
            VehicleInsurance car1 = new FourWheeler(4321, 200000.80);
            Console.WriteLine($"Policy Number:{car1.PolicyNumber}\tInsured Amount:{car1.InsuredAmount}\nFour Wheeler primum:{car1.CalculatePremium()}");
            VehicleInsurance bussiness1 = new CommercialInsurance(6589,70000000.65);
            Console.WriteLine($"Policy Number:{bussiness1.PolicyNumber}\tInsured Amount:{bussiness1.InsuredAmount}\nCommercial Insurance premium:{bussiness1.CalculatePremium()}");


        }
    }
}
