using Microsoft.EntityFrameworkCore;
using mnt_weApi_LaptopManagement_Code_First.Model;

public class mntContext : DbContext
{
    public mntContext(DbContextOptions<mntContext> options) : base(options)
    {
    }

    public virtual DbSet<Employee> employees { get; set; }
    public virtual DbSet<Laptop> laptops { get; set; }
    public virtual DbSet<EmployeeLaptopMapping> EmployeeLaptopMappings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmployeeLaptopMapping>()
            .HasKey(el => el.mappingId);

        modelBuilder.Entity<EmployeeLaptopMapping>()
            .HasOne(el => el.employee)
            .WithMany(e => e.employeeLaptopMappings)
            .HasForeignKey(el => el.empId)
            .OnDelete(DeleteBehavior.Restrict); 
        modelBuilder.Entity<EmployeeLaptopMapping>()
            .HasOne(el => el.laptop)
            .WithMany() 
            .HasForeignKey(el => el.laptopId)
            .OnDelete(DeleteBehavior.Restrict); 

    }
}
