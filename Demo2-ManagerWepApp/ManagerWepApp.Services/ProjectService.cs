using System.Collections.Generic;
using System.Linq;
using ManagerWepApp.Models.EntityModels;
using ManagerWepApp.Models.Enums;
using ManagerWepApp.Models.ViewModels;

namespace ManagerWepApp.Services
{
    public class ProjectService : Service
    {
        public void AddProject(CreateProjectVm vm)
        {
            Project project = new Project(vm.Name);
        }

        public CreateProjectVm GetProjectVm()
        {
            IEnumerable<TeamLead> TeamLeadWithdoutProject = GetAllFreeTeamLeads();
            IEnumerable<ProjectManager> AllProjectManagers = GetAllProjectManagers();
            var projVm = new CreateProjectVm();
            projVm.ProjectManagers = AllProjectManagers;
            projVm.TeamLeads = TeamLeadWithdoutProject;
            return projVm;
        }

        private IEnumerable<ProjectManager> GetAllProjectManagers()
        {
            var allProjectManagers = Context.Employees.Where(e => e.Role == EmployeeRole.ProjectManager);
            return allProjectManagers as IEnumerable<ProjectManager>;
        }

        private IEnumerable<TeamLead> GetAllFreeTeamLeads()
        {
            var allTeamLeaders =
                this.Context.Employees.Where(e => e.Role == EmployeeRole.TeamLeader && e.HasProject == false);
            return allTeamLeaders as IEnumerable<TeamLead>;
        }
    }
}
