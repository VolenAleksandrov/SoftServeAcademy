using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManager.Models.ViewModels.Employee
{
    public class CreateEmployeeTeamLeadPartial
    {
        public CreateEmployeeTeamLeadPartial()
        {
            this.ProjectManagers = new Dictionary<int, string>();
            this.ProjectsWithoutTeamLead = new Dictionary<int, string>();
        }
        public Dictionary<int, string> ProjectsWithoutTeamLead { get; set; }
        public Dictionary<int, string> ProjectManagers { get; set; }
    }
}
