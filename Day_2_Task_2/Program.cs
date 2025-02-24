namespace Day_2_Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1.General-200rs\n2.Ac-1000rs\n3.Sleeper-500rs\n4.Exit");
            Console.WriteLine("Enter your Choice");
            int choice = Convert.ToInt32(Console.ReadLine());
            int numberOfGeneralTickets = 0;
            int numberOfAcTickets = 0;
            int numberOfSleeperTickets = 0;

            while (choice != 4)
            {
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter number of tickets::");
                        numberOfGeneralTickets += Convert.ToInt32(Console.ReadLine());
                        break;
                    case 2:
                        Console.WriteLine("Enter number oF tickets::");
                        numberOfAcTickets += Convert.ToInt32(Console.ReadLine());
                        break;
                    case 3:
                        Console.WriteLine("Enter number of tickets::");
                        numberOfSleeperTickets += Convert.ToInt32(Console.ReadLine());
                        break;
                    default:
                        Console.WriteLine("Invalid Choice");
                        break;


                }
                Console.WriteLine("Enter your Choice");
                choice = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Tickets Details:");
            Console.WriteLine($"Number of General Tickets:{numberOfGeneralTickets}");
            Console.WriteLine($"Number of Ac Tickets:{numberOfAcTickets}");
            Console.WriteLine($"Number of Sleeper Tickets:{numberOfSleeperTickets}");

        }
    }
}
