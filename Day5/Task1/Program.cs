using Task1.Model;
using Task1.Repo;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IBankRepo userRepo = new BankRepo();

            List<Bank> allAccountNumber = userRepo.GetAllAccountNumber();
            foreach (Bank bank in allAccountNumber)
            {
                Console.WriteLine(bank);
            }

            Bank account3 = new Bank()
            {
                AccountNumber = 1276541287,
                AccountHolderName = "Sakthish Nadar"
            };
            bool result = userRepo.AddAccount(account3);
            if (result)
            {
                Console.WriteLine("Account Details Added Succesfully!!");
            }

            Bank account4 = new Bank()
            {
                AccountHolderName = "Om Auti",
                AccountNumber = 123456789
            };
          

                userRepo.AddAccount(account4);


                foreach (Bank bank in allAccountNumber)
                {
                    Console.WriteLine(bank);
                }

            
        }
    }
}
