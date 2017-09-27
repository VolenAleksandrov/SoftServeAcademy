using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManager.Models.EntityModels
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
        public Project(string name, TeamLead teamLead)
        {
            this.Name = name;
            this.TeamLead = teamLead;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public virtual TeamLead TeamLead { get; set; }
    }
}
