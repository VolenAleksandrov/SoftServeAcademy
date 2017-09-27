using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRManager.Models.EntityModels.Enums;

namespace HRManager.Models.ViewModels.Employee
{
    public class CreateEmployeeVm
    {
        public CreateEmployeeVm()
        {
            this.Roles = new Dictionary<int, string>();
        }
        public string Name { get; set; }
        public Dictionary<int, string> Roles { get; set; }
        public decimal Salary { get; set; }
        public string Workplace { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
