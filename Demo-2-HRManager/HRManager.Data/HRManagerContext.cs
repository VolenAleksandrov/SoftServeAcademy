using HRManager.Models.EntityModels;

namespace HRManager.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class HRManagerContext : DbContext
    {
        public HRManagerContext()
            : base("data source=(LocalDb)\\MSSQLLocalDB;initial catalog=HRManagerContext;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectManager>().ToTable("ProjectManager");
            modelBuilder.Entity<TeamLead>().ToTable("TeamLead");
            modelBuilder.Entity<DeliveryDirector>().ToTable("DeliveryDirector");
            modelBuilder.Entity<Project>()
            .HasOptional(t => t.TeamLead).WithOptionalPrincipal(t => t.Project)
            .WillCascadeOnDelete(true);
        }
    }
}