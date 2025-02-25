namespace Day_2_Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[,] userData =
            {
                { 101, 500.75 },
                { 102, 1200.50 },
                { 103, 300.00 },
                { 104, 750.25 },
                { 105, 950.00 }
            };

            bool validUser = true;
            int userId;

            Console.WriteLine("Welcome to the Online Shopping Wallet System!");
            
                Console.WriteLine("Enter User Id::");
                userId = Convert.ToInt32(Console.ReadLine());
            while (validUser)
            {

                for (int i = 0;i< userData.GetLength(0); i++)
                {
                    if(userData[i,0] == userId)
                    {
                        validUser = false;
                        Console.WriteLine($"Wallet Balance:{userData[i, 1]}");
                        break;
                    }
                }
                if (validUser)
                {
                    Console.WriteLine("Invalid User ID");
                    
                }
             
            }


        }
    }
}
