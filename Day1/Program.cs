namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Task 1
            string studentName;
            int studentAge;
            double studentPercentage;
            string studentEmail;

            Console.WriteLine("Enter your name::");
            studentName = Console.ReadLine();

            Console.WriteLine("Enter your Age::");



            #region task2
            if (!int.TryParse(Console.ReadLine(), out studentAge))
            {
                Console.WriteLine("Invalid Age!!!");
                Console.WriteLine("Enter your Age in numberic:");
                studentAge = int.Parse(Console.ReadLine());
            }

            #endregion


            Console.WriteLine("Enter your Percentage::");
            studentPercentage = double.Parse(Console.ReadLine());

            #region task 3
            Console.WriteLine("Enter Email Id::");
            studentEmail = Console.ReadLine();

            if (string.IsNullOrEmpty(studentEmail))
            {
                Console.WriteLine("Email cannot be empty. Please restart the program and enter a valid email Id");
                return;
            }
            #endregion


            Console.WriteLine("\nStudent Data");
            Console.WriteLine($"name:{studentName}\nAge:{studentAge}\nPercentage:{studentPercentage}%");
            #endregion

            #region Task 4
            string date;
            Console.WriteLine("Discharge Date : ");
            date = Console.ReadLine();
            Console.WriteLine(date.Length > 0 ? date : "Not Discharged");
            #endregion
        }
    }
}
