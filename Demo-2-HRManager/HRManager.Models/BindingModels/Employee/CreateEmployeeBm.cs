using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManager.Models.BindingModels.Employee
{
    public class CreateEmployeeBm
    {
        public string Name { get; set; }
        public int Role { get; set; }
        public decimal Salary { get; set; }
        public string Workplace { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int TeamLead { get; set; }
        public int Project { get; set; }
        public int ProjectManager { get; set; }
        public int DeliveryDirector { get; set; }
    }
}
