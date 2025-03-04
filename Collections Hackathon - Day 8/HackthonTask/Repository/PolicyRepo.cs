using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackthonTask.Exceptions;
using HackthonTask.Model;
using static HackthonTask.Model.Policy;

namespace HackthonTask.Repository
{
    internal class PolicyRepo:IPolicy
    {
        Policy p1;
        List<Policy> ListOfPolices=new List<Policy>()
        {
            new Policy(13554,"Pranit",PolicyTypes.Life,new DateTime(2002-04-07),new DateTime(2030-04-07)),
            new Policy(13555,"Atharva",PolicyTypes.Health,new DateTime(2001-01-01),new DateTime(2020-01-01)),
            new Policy(13556,"Govind",PolicyTypes.Property,new DateTime(2002-02-27),new DateTime(2030-04-07)),
            new Policy(13554,"kapil",PolicyTypes.Life,new DateTime(2005-12-31),new DateTime(2010-04-07))
        };

        


        //-----------------Add New Policy--------------
        public void AddPolicy()
        {
            try
            {

            Console.WriteLine("Enter Policy Id:");
            int pId = Convert.ToInt32(Console.ReadLine());
            if (FindById(pId) == null)
            {
                Name:
                Console.Write("Enter Policy Holder Name: ");
                string policyHolderName = Console.ReadLine();
                while (string.IsNullOrWhiteSpace(policyHolderName))
                {
                    Console.Write("Policy Holder Name cannot be empty. Enter again: ");
                    goto Name;
                }

                PolicyTypes:
                Console.WriteLine("Select Policy Type: 0-Life, 1-Health, 2-Vehicle, 3-Property");
                PolicyTypes type;
                while (!Enum.TryParse(Console.ReadLine(),out type) || !Enum.IsDefined(typeof(PolicyTypes),type))
                {
                    Console.Write("Invalid Policy Type. Enter again: ");
                    goto PolicyTypes;
                }
                
                StartDate:
                Console.WriteLine("Enter Start date in yyyy-mm-dd");
                DateTime sDate;
                while (!DateTime.TryParse(Console.ReadLine(), out sDate))
                {
                    Console.WriteLine("Invalid date format. Enter again:");
                    goto StartDate;
                }

                EndDate:
                Console.WriteLine("Enter End date in yyyy-mm-dd");
                DateTime eDate;
                while (!DateTime.TryParse(Console.ReadLine(), out eDate))
                {
                    Console.WriteLine("Invalid date format. Enter again:");
                    goto EndDate;
                }

                ListOfPolices.Add(new Policy(pId, policyHolderName,type, sDate,eDate));
                Console.WriteLine("Policy added successfully!");

            }
            else
            {
                throw new IdIsAlreadyPresentException($"Policy id::{pId} is already available!!");
            }
            }
            catch(IdIsAlreadyPresentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }


        public Policy FindById(int id)
        {
            return ListOfPolices.Find(p=>p.PolicyID==id);
        }

        //----------View All Policies---------
        public void DisplayAllPolicies()
        {
            Console.WriteLine("All Policies:");
            foreach (var policy in ListOfPolices)
            {
                Console.WriteLine($"Policy ID: {policy.PolicyID}\tPolicy Holder: {policy.PolicyHolderName}\tType: {policy.PolicyType}\tStart Date: {policy.StartDate:yyyy-MM-dd}\tEnd Date: {policy.EndDate:yyyy-MM-dd}");
            }
        }



        //--------------Search Policy By Id--------

        public void SearchById(int id)
        {
            try
            {
                if (FindById(id) != null)
                {
                    var search=ListOfPolices.Where(p=>p.PolicyID == id);
                    foreach(var sp in search)
                    {

                        Console.WriteLine($"Policy Id:{sp.PolicyID}\t Policy Holder Name:{sp.PolicyHolderName}\tPolicy Type:{sp.PolicyType}\t Start Date:{sp.StartDate:yyyy-MM-dd}\tEnd Date:{sp.EndDate:yyyy-MM-dd}");
                    }
                    
                }
                else
                {
                    throw new PolicyNotFoundException($"Policy Id:{id} is not Found!!");
                }
            }
            catch (PolicyNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            
        }


        //-------------Update By Id-----

        public void UpdateById(int id)
        {
            try
            {
                if (FindById(id) != null)
                {
                    var policy = ListOfPolices.FirstOrDefault(p => p.PolicyID == id);
                    
                        
                        Console.Write("Enter Policy Holder Name: ");
                        policy.PolicyHolderName = Console.ReadLine();
                        


                    Console.WriteLine("Select New Policy Type: 0-Life, 1-Health, 2-Vehicle, 3-Property");
                    PolicyTypes type;
                    
                    while (!Enum.TryParse(Console.ReadLine(), out type) || !Enum.IsDefined(typeof(PolicyTypes), type))
                    {
                        Console.Write("Invalid Policy Type. Enter again: ");
                    }
                    policy.PolicyType = type;


                    Console.Write("Enter New End Date (yyyy-MM-dd): ");
                    DateTime endDate;
                    while (!DateTime.TryParse(Console.ReadLine(), out endDate) || endDate <= policy.StartDate)
                    {
                        Console.Write("Invalid End Date. Must be after Start Date. Enter again: ");
                    }
                    policy.EndDate = endDate;

                    Console.WriteLine("Policy updated successfully!");



                }
                else
                {
                    throw new PolicyNotFoundException($"Policy Id:{id} is not Found!!");
                }
            }
            catch (PolicyNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        //------------------Delete Policy--------------

        public void DeleteById()
        {
            try
            {
                Console.Write("Enter Policy ID to delete: ");
                int policyID;
                while (!int.TryParse(Console.ReadLine(), out policyID))
                {
                    Console.Write("Invalid input. Enter Policy ID again: ");
                }

                var policy = ListOfPolices.FirstOrDefault(p => p.PolicyID == policyID);
                if (policy != null)
                {
                    Console.Write("Are you sure you want to delete this policy? (yes/no): ");
                    string confirmation = Console.ReadLine().ToLower();
                    if (confirmation == "yes")
                    {
                        ListOfPolices.Remove(policy);
                        Console.WriteLine("Policy deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Policy deletion canceled.");
                    }
                }
                else
                {
                    throw new PolicyNotFoundException($"Policy Id:{policyID} is not Found!!");
                }
            }
            catch (PolicyNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }


        //-------------------------is active---------

        public void ViewActivePolicies()
        {
            var activePolicie=ListOfPolices.Where(p=>p.IsActive()).ToList();
            if (activePolicie.Any())
            {
                Console.WriteLine("Active Policies");
                foreach (var sp in activePolicie)
                {
                    Console.WriteLine($"Policy Id:{sp.PolicyID}\t Policy Holder Name:{sp.PolicyHolderName}\tPolicy Type:{sp.PolicyType}\t Start Date:{sp.StartDate:yyyy-MM-dd}\tEnd Date:{sp.EndDate:yyyy-MM-dd}");
                }
            }
            else
            {
                Console.WriteLine("No Active Policy Found");
            }
        }


    }
}
