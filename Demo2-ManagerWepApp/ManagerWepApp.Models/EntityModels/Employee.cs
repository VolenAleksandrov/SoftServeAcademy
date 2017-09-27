using ManagerWepApp.Models.Enums;

namespace ManagerWepApp.Models.EntityModels
{
    public class Employee : EmployeeBase
    {
        private TeamLead manager;

        public Employee()
        {
            
        }
        public Employee(string name, EmployeeRole role, decimal salary, string workplace, string email, string phone, TeamLead manager)
            :base(name, role, salary, workplace, email, phone)
        {
            this.Manager = manager;
        }
        public TeamLead Manager { get; set; }
        
    }
}
