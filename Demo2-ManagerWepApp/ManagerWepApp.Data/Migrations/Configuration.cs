using ManagerWepApp.Models.EntityModels;
using ManagerWepApp.Models.Enums;

namespace ManagerWepApp.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<ManagerAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(ManagerAppContext context)
        {
            var ceo = new Employee()
            {
                Name = "Ivan",
                Email = "ivan@asd.asd",
                Phone = "0898123123",
                Salary = 12412512m,
                WorkplaceCity = "Sofia",
                Role = EmployeeRole.CEO
            };
            
            context.Employees.Add(ceo);
            DeliveryDirector dd1 = new DeliveryDirector("Petkan", EmployeeRole.DeliveryDirector, 24124m, "Sofia", "petkan@asd.asd", "021412512", ceo);
            context.Employees.Add(dd1);
            DeliveryDirector dd2 = new DeliveryDirector("Gosho", EmployeeRole.DeliveryDirector, 24124m, "Sofia", "gosho@asd.asd", "021412512", ceo);
            context.Employees.Add(dd2);
            ProjectManager pm = new ProjectManager("Dragan", EmployeeRole.ProjectManager, 12312m, "Sofia", "dragan@asd.asd", "12412412412")
            {
                DeliveryDirector = dd1
            };
            context.Employees.Add(pm);
            Project pj = new Project("Mnogo int proekt");
            context.Projects.Add(pj);
            TeamLead tl1 = new TeamLead("Goeorgi", EmployeeRole.TeamLeader, 12312m, "Sofia", "goeorgi@asd.asd", "124122421");
            TeamLead tl = new TeamLead("Pesho", EmployeeRole.TeamLeader, 1212412m, "Sofia", "pesho@asd.asd", "1231231")
            {
                Project = pj,
                HasProject = true,
            };
            pj.ProjectManager = pm;
            pj.TeamLead = tl;
            pm.HasProject = true;
            context.Employees.Add(tl);
            Employee sn = new Employee("Marto", EmployeeRole.Senior, 123m, "Sofia", "marto@asd.asd", "3124124124", tl);
            context.Employees.Add(sn);
            Employee im = new Employee("Toni", EmployeeRole.Intermediate, 123m, "Sofia", "toni@asd.asd", "5125123123", tl);
            context.Employees.Add(im);
            Employee j = new Employee("Miro", EmployeeRole.Junior, 12m, "Sofia", "miro@asd.asd", "5125123123", tl);
            context.Employees.Add(j);
            Employee t = new Employee("Kiro", EmployeeRole.Trainee, 11m, "Sofia", "kiro@asd.asd", "5125123123", tl);
            context.Employees.Add(t);

            context.SaveChanges();
        }
    }
}
