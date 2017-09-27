using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManager.Models.ViewModels.Project
{
    public class EditProjectVm
    {
        public EditProjectVm()
        {
            this.FreeTeamLeads = new Dictionary<int, string>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string TeamLeadName { get; set; }
        public Dictionary<int, string> FreeTeamLeads { get; set; }
    }
}
