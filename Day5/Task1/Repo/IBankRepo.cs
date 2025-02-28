using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Model;

namespace Task1.Repo
{
    internal interface IBankRepo
    {
        bool AddAccount(Bank accounts);
        List<Bank> GetAllAccountNumber();
        Bank SearchAccountNumber(long number);
    }
}
