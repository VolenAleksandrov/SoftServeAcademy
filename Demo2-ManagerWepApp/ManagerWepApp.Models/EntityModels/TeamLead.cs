using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagerWepApp.Models.Enums;

namespace ManagerWepApp.Models.EntityModels
{
    public class TeamLead : EmployeeBase
    {
        public TeamLead()
        {
            this.ProjectColleagues = new List<Employee>();
        }
        public TeamLead(string name, EmployeeRole role, decimal salary, string workPlace, string email, string phone)
            :base(name, role, salary, workPlace, email, phone)
        {
            this.ProjectColleagues = new List<Employee>();
        }
        public virtual Project Project { get; set; }

        public List<Employee> ProjectColleagues { get; set; }

        public void ProjectColleague(Employee colleague)
        {
            this.ProjectColleagues.Add(colleague);
        }
    }
}
