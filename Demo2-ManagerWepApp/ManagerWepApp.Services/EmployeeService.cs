using System.Linq;
using ManagerWepApp.Models.EntityModels;
using ManagerWepApp.Models.Enums;
using ManagerWepApp.Models.ViewModels.Employee;
using ManagerWepApp.Models.ViewModels.Employees;
using ManagerWepApp.Models.ViewModels.ProjectManager;
using ManagerWepApp.Models.ViewModels.TeamLead;

namespace ManagerWepApp.Services
{
    public class EmployeeService : Service
    {
        public void AddDeliveryDirector(CreateDeliveryDirectorVm vm)
        {
            Employee ceo = Context.Employees.FirstOrDefault(e => e.Role == EmployeeRole.CEO) as Employee;
            DeliveryDirector deliveryDirector = new DeliveryDirector(vm.Name, EmployeeRole.DeliveryDirector, vm.Salary, vm.Workplace, vm.Email, vm.Phone, ceo);
            this.Context.Employees.Add(deliveryDirector);
            this.Context.SaveChanges();
        }

        public void AddProjectManager(CreateProjectManagerVm vm)
        {
            ProjectManager pm = new ProjectManager(vm.Name, EmployeeRole.ProjectManager, vm.Salary, vm.Workplace, vm.Email, vm.Phone);
            this.Context.Employees.Add(pm);
            this.Context.SaveChanges();
        }

        public void AddTeamLead(CreateTeamLeadVm vm)
        {
            TeamLead tl = new TeamLead(vm.Name, EmployeeRole.TeamLeader, vm.Salary, vm.Workplace, vm.Email, vm.Phone);
            this.Context.Employees.Add(tl);
            this.Context.SaveChanges();
        }

        public void AddEmployee(CreateEmployeeVm vm)
        {
            
        }
    }
}
