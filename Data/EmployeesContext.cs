using EmployeeRestAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace EmployeeRestAPI.Data
{
    public class EmployeesContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public DbSet<Company> Companies { get; set; }


        public EmployeesContext(DbContextOptions<EmployeesContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
            .HasMany(p => p.Employees)
            .WithOne()
            .HasForeignKey(c => c.CompanyId)
            .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
