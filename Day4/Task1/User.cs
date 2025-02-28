using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    
    internal class User
    {
        static int var = 0;
        public User()
        {
            var++;
            
        }
        public static void noOfUser()
        {
            Console.WriteLine($"UserCount = {var}");
        }

    }
}
