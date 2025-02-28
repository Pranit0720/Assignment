using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Exception;
using Task1.Model;

namespace Task1.Repo
{
    internal class BankRepo : IBankRepo
    {
        List<Bank> accounts;
        public BankRepo()
        {
            accounts = new List<Bank>
            {
                new Bank
                {
                    AccountNumber=1234567890,AccountHolderName="Pranit Patil"
                },
                new Bank
                {
                    AccountNumber=9876543201,AccountHolderName="Krishna Patil"
                }
            };

        }

        public bool AddAccount(Bank account)
        {
            try
            {

                if (account.AccountNumber > 999999999)
                {

                    Bank searchResult = SearchAccountNumber(account.AccountNumber);
                    if (searchResult == null)
                    {
                        accounts.Add(account);
                        return true;
                    }
                    else
                    {
                        throw new AccountAlreadyExistsException("This Account Number AlReady Existed!!!");
                    }
                }
                else
                {
                    throw new InvalidAccountNumberException("Invalid Account Number!!!");
                }
            }
            catch (AccountAlreadyExistsException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (InvalidAccountNumberException e)
            {
                Console.WriteLine(e.Message);
            }
            return false;
            
        }

        List<Bank> IBankRepo.GetAllAccountNumber()
        {
            return accounts;
        }

         public Bank SearchAccountNumber(long number)
        {

            return accounts.Find(num => num.AccountNumber == number);
        }
    }
}
