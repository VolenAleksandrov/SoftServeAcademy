using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerWepApp.Models.EntityModels
{
    public class Project
    {
        private string name;
        private TeamLead teamLead;

        public Project()
        {
            
        }
        public Project(string name)
        {
            this.Name = name;
        }
        public Project(string name, TeamLead teamLead, ProjectManager manager)
        {
            this.Name = name;
            this.TeamLead = teamLead;
            this.ProjectManager = manager;
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
       
        public virtual TeamLead TeamLead { get; set; }
        public ProjectManager ProjectManager { get; set; }
    }
}
