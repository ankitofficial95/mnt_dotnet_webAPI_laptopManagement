using Microsoft.EntityFrameworkCore;
using mnt_weApi_LaptopManagement_Code_First.Model;

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
            .HasKey(el => el.mappingId);

        modelBuilder.Entity<EmployeeLaptopMapping>()
            .HasOne(el => el.Employee)
            .WithMany(e => e.EmployeeLaptopMappings)
            .HasForeignKey(el => el.empId);

        modelBuilder.Entity<EmployeeLaptopMapping>()
            .HasOne(el => el.Laptop)
            .WithMany()
            .HasForeignKey(el => el.laptopId);
    }
}
