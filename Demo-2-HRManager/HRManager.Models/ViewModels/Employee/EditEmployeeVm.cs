using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManager.Models.ViewModels.Employee
{
    public class EditEmployeeVm
    {
        public EditEmployeeVm()
        {
            this.Projects = new Dictionary<int, string>();
            this.TeamLeads = new Dictionary<int, string>();
            this.DeliveryDirectors = new Dictionary<int, string>();
            this.ProjectManagers = new Dictionary<int, string>();
            this.Roles = new Dictionary<int, string>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Workplace { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string CurrentRole { get; set; }
        public Dictionary<int, string> Roles { get; set; }
        public Dictionary<int, string> TeamLeads { get; set; }
        public Dictionary<int, string> Projects { get; set; }
        public Dictionary<int, string> ProjectManagers { get; set; }
        public Dictionary<int, string> DeliveryDirectors { get; set; }
    }
}
