using HackthonTask.Model;
using HackthonTask.Repository;

namespace HackthonTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IPolicy policy = new PolicyRepo();
            Console.WriteLine("Welcome to  menu-driven console application");
            Console.WriteLine("Press 1 for Add Policy\nPress 2 for View All Policies\nPress 3 for Search Policy by ID\nPress 4 for Update Policy Details\nPress 5 for Delete a Policy\nPress 6 for View Active Policies\n Press 7 For Exit!");
            Console.WriteLine("Enter Your Choice");
            int choice = Convert.ToInt32(Console.ReadLine());

            while (choice < 7)
            {
                switch(choice){
                    case 1:
                        policy.AddPolicy();
                        break;
                    case 2:
                        policy.DisplayAllPolicies();
                        break;
                    case 3:
                        Console.WriteLine("Enter Policy Id For Search:");
                        int id = Convert.ToInt32(Console.ReadLine());
                        policy.SearchById(id);
                        break;
                    case 4:
                        Console.WriteLine("Enter Policy Id:");
                        int uId = Convert.ToInt32(Console.ReadLine());
                        policy.UpdateById(uId);
                        break;
                    case 5:
                        policy.DeleteById();
                        break;
                    case 6:
                        policy.ViewActivePolicies();
                        break;
                    default:
                        Console.WriteLine("Invalid Choice!!!");
                        break;
                        



                }
                Console.WriteLine("Welcome to  menu-driven console application");
                Console.WriteLine("Press 1 for Add Policy\nPress 2 for View All Policies\nPress 3 for Search Policy by ID\nPress 4 for Update Policy Details\nPress 5 for Delete a Policy\nPress 6 for View Active Policies\n Press 7 For Exit!");
                Console.WriteLine("Enter Your Choice");
                choice = Convert.ToInt32(Console.ReadLine());
            }
        }
    }
}
