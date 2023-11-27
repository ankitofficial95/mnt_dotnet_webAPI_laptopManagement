using Microsoft.EntityFrameworkCore;
using mnt_weApi_LaptopManagement_Code_First.Model;
using System.Reflection.Metadata;

public class mntContext : DbContext
{

    public mntContext(DbContextOptions<mntContext> options) : base(options)
    {
    }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Laptop> Laptops { get; set; }
        public virtual DbSet<EmployeeLaptopMapping> EmployeeLaptopMappings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
            .HasKey(e => e.empId);

        modelBuilder.Entity<Laptop>()
            .HasKey(l => l.laptopId);

        modelBuilder.Entity<EmployeeLaptopMapping>()
            .HasKey(el => new { el.empId, el.laptopId });

        modelBuilder.Entity<EmployeeLaptopMapping>()
            .HasOne(el => el.Employee)
            .WithOne(e => e.EmployeeLaptopMapping)
            .HasForeignKey<EmployeeLaptopMapping>(el => el.empId);

        modelBuilder.Entity<EmployeeLaptopMapping>()
            .HasOne(el => el.Laptop)
            .WithOne(l => l.EmployeeLaptopMapping)
            .HasForeignKey<EmployeeLaptopMapping>(el => el.laptopId);
    }

}