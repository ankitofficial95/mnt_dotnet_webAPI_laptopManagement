namespace mnt_weApi_LaptopManagement_Code_First.DTO
{
    public class EmployeeLaptopPutDTO
    {
        public int laptopId { get; set; }
        public int empId { get; set; }
        public DateTime createdDate { get; set; }
        public string createdBy { get; set; }
        public DateTime modifiedDate { get; set; }
        public string modifiedBy { get; set; }
    }
}
