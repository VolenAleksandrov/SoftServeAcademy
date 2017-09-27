using ManagerWepApp.Models.EntityModels;

namespace ManagerWepApp.Data
{
    using System.Data.Entity;

    public class ManagerAppContext : DbContext
    {
        public ManagerAppContext()
            : base("data source=(LocalDb)\\MSSQLLocalDB;initial catalog=ManagerAppContext;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }

        public virtual DbSet<EmployeeBase> Employees { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectManager>().ToTable("ProjectManager");
            modelBuilder.Entity<Employee>().ToTable("Employee");
            modelBuilder.Entity<DeliveryDirector>().ToTable("DeliveryDirector");
            modelBuilder.Entity<TeamLead>().ToTable("TeamLead");
            modelBuilder.Entity<TeamLead>().HasOptional(s => s.Project)
                .WithRequired(ad => ad.TeamLead);
            base.OnModelCreating(modelBuilder);
        }
    }

    
}