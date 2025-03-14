﻿using System.Text.RegularExpressions;

namespace Task3
{
    internal class Program
    {
        public static Boolean validatePassword(String password)
        {

            if (password.Length < 6)
            {
                Console.WriteLine("Password must be at least 6 characters long.");
                return false;
            }
            if (!Regex.IsMatch(password, "[A-Z]"))
            {
                Console.WriteLine("Password must contain at least one uppercase letter.");
                return false;
            }
            if (!Regex.IsMatch(password, "\\d"))
            {
                Console.WriteLine("Password must contain at least one digit.");
                return false;
                
            }
            Console.WriteLine("Password is valid.");
            return true;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Password::");
            string pass=Console.ReadLine();
            validatePassword(pass);
            
        }
    }
}
