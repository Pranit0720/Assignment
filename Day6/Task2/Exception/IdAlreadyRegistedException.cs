using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.Exception
{
    internal class IdAlreadyRegistedException:ApplicationException
    {
        public IdAlreadyRegistedException()
        {
            
        }
        public IdAlreadyRegistedException(string message):base(message)
        {
        }
    }
}
