using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace mnt_weApi_LaptopManagement_Code_First.Model
{
    public class EmployeeLaptopMapping
    {
        [Key]
        public int mappingId { get; set; }

        public int laptopId { get; set; }


        [ForeignKey("laptopId")]
        public Laptop laptop { get; set; }

        public int empId { get; set; }
        [ForeignKey("empId")]


        public Employee? employee { get; set; }
        public DateTime? createdDate { get; set; }
        public string? createdBy { get; set; }
        public DateTime modifiedDate { get; set; }
        public string? modifiedBy { get; set; }
    }
}
