namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee emp1=new Employee("Pranit",10000.00);
            Manager man1 = new Manager("Atharva",200000.00,10000.00);
            emp1.DisplayDetails();
            man1.DisplayDetails();
            Employee newEmp = new Manager("Affan", 200000.00, 10000.00);
            newEmp.DisplayDetails();
            Manager newEmp1 = (Manager)new Employee("Pratik", 400000.00);
            newEmp.DisplayDetails();

        }
    }
}
