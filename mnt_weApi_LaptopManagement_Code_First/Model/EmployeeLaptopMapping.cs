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
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }

        [ForeignKey("empId")]
        public Employee? Employee { get; set; }

        [ForeignKey("laptopId")]
        public Laptop? Laptop { get; set; }  
    }
}
