using System.Collections.Generic;
using ManagerWepApp.Models.Enums;

namespace ManagerWepApp.Models.EntityModels
{
    public class ProjectManager : EmployeeBase
    {
        public ProjectManager()
        {
            this.Projects = new List<Project>();
        }
        public ProjectManager(string name, EmployeeRole role, decimal salary, string workplace, string email, string phone)
            :base(name, role, salary, workplace, email, phone)
        {
            this.Projects = new List<Project>();
        }

        public List<Project> Projects { get; set; }
        public DeliveryDirector DeliveryDirector { get; set; }
    }
}
