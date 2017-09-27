using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRManager.Models.BindingModels.Project;
using HRManager.Models.EntityModels;
using HRManager.Models.EntityModels.Enums;
using HRManager.Models.ViewModels;
using HRManager.Models.ViewModels.Project;

namespace HRManager.Services
{
    public class ProjectService : Service
    {
        public void AddProject(CreateProjectBm bm)
        {
            if (bm.TeamLead != 0)
            {
                var teamLead =
                    this.Context.Employees.FirstOrDefault(
                        e => e.Id == bm.TeamLead) as TeamLead;
                if (teamLead != null)
                {
                    Project pj = new Project(bm.Name, teamLead);
                    teamLead.Project = pj;
                    teamLead.HasProject = true;
                    this.Context.Projects.Add(pj);
                }
            }
            else
            {
                Project pj = new Project(bm.Name);
                this.Context.Projects.Add(pj);
            }
            this.Context.SaveChanges();
        }

        public CreateProjectVm GetCreateProjectVm()
        {
            var vm = new CreateProjectVm();
            var freeTeamLeads = this.GetAllFreeTeamLeads();
            if (freeTeamLeads.Any())
            {
                vm.FreeTeamLeads = freeTeamLeads;
            }
            return vm;
        }

        private Dictionary<int, string> GetAllFreeTeamLeads()
        {
            var teamLeadsWithoutProject =
                this.Context.Employees.Where(e => e.Role == EmployeeRole.TeamLeader && e.HasProject == false);
            Dictionary<int,string> freeTeamLeads = new Dictionary<int, string>();
            if (teamLeadsWithoutProject.Count() > 0)
            {
                foreach (var employee in teamLeadsWithoutProject)
                {
                    freeTeamLeads.Add(employee.Id, employee.Name);
                }
            }
            return freeTeamLeads;
        }

        public List<ProjectVm> GetAllProjectVms()
        {
            var allProjects = this.Context.Projects;
            List<ProjectVm> vms = new List<ProjectVm>();
            foreach (var project in allProjects)
            {
                string teamLeadName;
                if (project.TeamLead != null)
                {
                    teamLeadName = project.TeamLead.Name;
                }
                else
                {
                    teamLeadName = "Do not have team leader.";
                }
                vms.Add(new ProjectVm()
                {
                    Id = project.Id,
                    Name = project.Name,
                    TeamLead = teamLeadName
                });
            }
            return vms;
        }

        public EditProjectVm GetEditProjectVm(int id)
        {
            Project pj = this.Context.Projects.FirstOrDefault(p => p.Id == id);
            string teamLeadName = "This project do not have team leader.";
            if (pj.TeamLead != null)
            {
                teamLeadName = pj.TeamLead.Name;
            }
            var freeTeamLeads = this.GetAllFreeTeamLeads();
            EditProjectVm vm = new EditProjectVm()
            {
                Id = pj.Id,
                Name = pj.Name,
                FreeTeamLeads = freeTeamLeads,
                TeamLeadName = teamLeadName
            };
            return vm;
        }

        public void EditProject(EditProjectBm bm)
        {
            Project pj = this.Context.Projects.FirstOrDefault(p => p.Id == bm.Id);
            if (bm.TeamLead != 0 && bm.TeamLead != 1)
            {
                TeamLead pickedTeamLead = this.Context.Employees.FirstOrDefault(e=>e.Id == bm.TeamLead) as TeamLead;
                var lastTeamLead = pj.TeamLead;
                if (lastTeamLead != null)
                {
                    lastTeamLead.Project = null;
                    lastTeamLead.HasProject = false;
                }
                if (pj != null) pj.TeamLead = pickedTeamLead;
                pickedTeamLead.Project = pj;
                pickedTeamLead.HasProject = true;
            }
            if (bm.TeamLead == 1)
            {
                if (pj.TeamLead != null)
                {
                    var lastTeamLead = pj.TeamLead;
                    lastTeamLead.Project = null;
                    lastTeamLead.HasProject = false;
                }
                pj.TeamLead = null;
            }
            pj.Name = bm.Name;
            this.Context.SaveChanges();
        }
    }
}
