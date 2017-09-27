using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRManager.Models.BindingModels.Project
{
    public class EditProjectBm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeamLead { get; set; }
    }
}
