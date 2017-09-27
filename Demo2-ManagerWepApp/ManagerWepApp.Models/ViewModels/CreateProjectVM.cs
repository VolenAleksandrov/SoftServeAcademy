using System.Collections.Generic;
using System.Web.Mvc;
using ManagerWepApp.Models.EntityModels;

namespace ManagerWepApp.Models.ViewModels
{
    public class CreateProjectVm
    {
        public string Name { get; set; }
        public IEnumerable<TeamLead> TeamLeads { get; set; }
        public IEnumerable<ProjectManager> ProjectManagers { get; set; }
    }
}
