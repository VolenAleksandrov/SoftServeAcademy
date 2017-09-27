using System.Collections.Generic;
using ManagerWepApp.Models.Enums;

namespace ManagerWepApp.Models.EntityModels
{
    public class DeliveryDirector : EmployeeBase
    {
        private Employee ceo;

        public DeliveryDirector()
        {
            this.PojeManagers = new List<ProjectManager>();
        }
        public DeliveryDirector(string name, EmployeeRole role, decimal salary, string workplace, string email, string phone, Employee ceo)
            :base(name, role, salary, workplace, email, phone)
        {
            this.Ceo = ceo;
            this.PojeManagers = new List<ProjectManager>();
        }

        public Employee Ceo { get; set; }
        public List<ProjectManager>PojeManagers { get; set; }
    }
}
