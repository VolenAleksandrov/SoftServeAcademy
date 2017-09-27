using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRManager.Models.EntityModels.Enums;

namespace HRManager.Models.EntityModels
{
    public class ProjectManager : Employee
    {
        public ProjectManager()
        {
            this.TeamLeads = new List<TeamLead>();
        }
        public ProjectManager(string name, EmployeeRole role, decimal salary, string workplace, string email, string phone)
            : base(name, role, salary, workplace, email, phone)
        {
            this.TeamLeads = new List<TeamLead>();
        }

        public List<TeamLead> TeamLeads { get; set; }
        public DeliveryDirector DeliveryDirector { get; set; }
    }
}
