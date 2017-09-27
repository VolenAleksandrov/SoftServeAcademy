using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRManager.Models.EntityModels;

namespace HRManager.Models.ViewModels
{
    public class CreateProjectVm
    {
        public CreateProjectVm()
        {
            this.FreeTeamLeads = new Dictionary<int, string>();
        }
        public string Name { get; set; }
        public Dictionary<int, string> FreeTeamLeads { get; set; }
    }
}
