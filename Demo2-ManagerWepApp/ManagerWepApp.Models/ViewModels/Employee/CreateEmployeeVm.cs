using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManagerWepApp.Models.Enums;

namespace ManagerWepApp.Models.ViewModels.Employee
{
    public class CreateEmployeeVm
    {
        public string Name { get; set; }
        public EmployeeRole Role { get; set; }
        public decimal Salary { get; set; }
        public string Workplace { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
