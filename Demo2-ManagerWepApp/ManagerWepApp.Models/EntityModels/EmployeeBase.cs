using System.ComponentModel.DataAnnotations;
using ManagerWepApp.Models.Enums;

namespace ManagerWepApp.Models.EntityModels
{
    public abstract class EmployeeBase
    {
        private string name;
        private EmployeeRole role;
        private decimal salary;
        private string workplaceCity;
        private string email;
        private string phone;

        public EmployeeBase()
        {

        }

        protected EmployeeBase(string name, EmployeeRole role, decimal salary, string workplace, string email, string phone)
        {
            this.Email = email;
            this.Name = name;
            this.Phone = phone;
            this.Salary = salary;
            this.Role = role;
            this.WorkplaceCity = workplace;
        }
        [Key]
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
