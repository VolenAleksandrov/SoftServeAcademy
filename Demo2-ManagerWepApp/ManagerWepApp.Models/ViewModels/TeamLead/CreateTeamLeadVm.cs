using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerWepApp.Models.ViewModels.TeamLead
{
    public class CreateTeamLeadVm
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Workplace { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
