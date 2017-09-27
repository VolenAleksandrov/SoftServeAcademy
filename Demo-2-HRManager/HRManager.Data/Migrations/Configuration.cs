using HRManager.Models.EntityModels;
using HRManager.Models.EntityModels.Enums;

namespace HRManager.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HRManagerContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(HRManagerContext context)
        {
            var ceo = new Employee()
            {
                Name = "Ivan",
                Email = "ivan@asd.asd",
                Salary = 12312m,
                WorkplaceCity = "Sofia",
                Role = EmployeeRole.Ceo,
                Phone = "1231231"
            };

            context.Employees.Add(ceo);
            context.SaveChanges();
            DeliveryDirector dd = new DeliveryDirector("Petkan", EmployeeRole.DeliveryDirector, 123, "Sofia", "petkan@asd.asd", "1231241241", ceo);
            context.Employees.Add(dd);
            ProjectManager pm = new ProjectManager("Dragan", EmployeeRole.ProjectManager, 123123, "Sofia", "dragan@asd.asd", "1231231")
            {
                DeliveryDirector = dd
            };
            context.Employees.Add(pm);
            TeamLead teamLead = new TeamLead("Marto", EmployeeRole.TeamLeader, 123m, "Sofia", "marto@asd.asd", "1231241212")
            {
                ProjectManager = pm
            };
            context.Employees.Add(teamLead);
            Project pj = new Project("Mnogo qk proekt")
            {
                TeamLead = teamLead
            };
            teamLead.HasProject = true;
            context.Projects.Add(pj);
            var sn = new Employee("Gosho", EmployeeRole.Senior, 123, "Sofia", "gosho@asd.asd", "1231241")
            {
                TeamLead = teamLead,
                HasProject = true
            };
            context.Employees.Add(sn);
            context.Employees.Add(new Employee("Kiro", EmployeeRole.Intermediate, 12313, "Sofia", "kiro@asd.asd",
                "123124")
            {
                TeamLead = teamLead,
                HasProject = true
            });
            context.Employees.Add(new Employee("Milen", EmployeeRole.Junior, 12314123, "Sofia", "milen@asd.asd",
                "12312431231312")
            {
                TeamLead = teamLead,
                HasProject = true
            });
            context.Employees.Add(new Employee("Asen", EmployeeRole.Trainee, 1231213, "Sofia", "asen@asd.asd",
                "123124")
            {
                TeamLead = teamLead,
                HasProject = true
            });
            context.SaveChanges();
        }
    }
}
