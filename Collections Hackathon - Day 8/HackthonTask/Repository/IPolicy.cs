using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackthonTask.Model;

namespace HackthonTask.Repository
{
    internal interface IPolicy
    {
        void AddPolicy();
        Policy FindById(int id);
        void DisplayAllPolicies();
        void SearchById(int id);

        void UpdateById(int id);
        void DeleteById();
        void ViewActivePolicies();
    }
}
