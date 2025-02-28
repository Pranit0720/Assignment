using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Exception
{
    internal class AccountAlreadyExistsException : ApplicationException
    {
        public AccountAlreadyExistsException() 
        {

        }
        public AccountAlreadyExistsException(string message):base(message) 
        {
        
            
        }

    }
}
