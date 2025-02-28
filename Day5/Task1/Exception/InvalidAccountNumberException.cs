using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Exception
{
    internal class InvalidAccountNumberException : ApplicationException
    {
        public InvalidAccountNumberException()
        {

        }
        public InvalidAccountNumberException(string mess) : base(mess)
        {
            
        }
    }
}
