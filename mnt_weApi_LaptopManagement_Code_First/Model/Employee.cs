using System.ComponentModel.DataAnnotations;
namespace mnt_weApi_LaptopManagement_Code_First.Model
{
    public class Employee
    {
        [Key]
        public int empId { get; set; }
        public string? empname { get; set; }
        public bool isLaptopAssigned { get; set; }

        public ICollection<EmployeeLaptopMapping> employeeLaptopMappings { get; set; }
    }
}
