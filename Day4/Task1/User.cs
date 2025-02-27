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
            Console.WriteLine($"User {var} is login.");
        }
        public static void noOfUser()
        {
            Console.WriteLine($"UserCount = {var}");
        }

    }
}
