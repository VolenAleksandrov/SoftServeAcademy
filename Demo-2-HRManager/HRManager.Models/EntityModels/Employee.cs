using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRManager.Models.EntityModels.Enums;

namespace HRManager.Models.EntityModels
{
    public class Employee
    {
        private string name;
        private EmployeeRole role;
        private decimal salary;
        private string workplaceCity;
        private string email;
        private string phone;

        public Employee()
        {

        }

        public Employee(string name, EmployeeRole role, decimal salary, string workplace, string email, string phone)
        {
            this.Email = email;
            this.Name = name;
            this.Phone = phone;
            this.Salary = salary;
            this.Role = role;
            this.WorkplaceCity = workplace;
        }
        public TeamLead TeamLead { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public EmployeeRole Role { get; set; }
        public decimal Salary { get; set; }
        public string WorkplaceCity { get; set; }
        public bool HasProject { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
