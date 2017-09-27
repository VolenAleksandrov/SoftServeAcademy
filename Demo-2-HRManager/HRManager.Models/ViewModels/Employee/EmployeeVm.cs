using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using HRManager.Models.EntityModels.Enums;

namespace HRManager.Models.ViewModels.Employee
{
    public class EmployeeVm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public string Workplace { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string TeamLead { get; set; }
        public EmployeeRole Role { get; set; }
        public string ProjectName { get; set; }
    }
}
