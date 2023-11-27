using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mnt_weApi_LaptopManagement_Code_First.Model
{
    public class EmployeeLaptopMapping
    {
        [Key]
        public int mappingId { get; set; }
        public int empId { get; set; }
        public int laptopId { get; set; }
        public bool isReturned { get; set; }

        [ForeignKey("empId")]
        public Employee? Employee { get; set; }

        [ForeignKey("laptopId")]
        public Laptop? Laptop { get; set; }  
    }
}
