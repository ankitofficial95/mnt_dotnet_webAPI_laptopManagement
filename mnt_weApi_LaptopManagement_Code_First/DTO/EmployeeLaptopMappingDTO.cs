namespace YourNamespace.DTOs
{
    public class EmployeeLaptopMappingDTO
    {
        //public int MappingId { get; set; } 
        public int EmployeeId { get; set; }
        public int LaptopId { get; set; }
        public bool IsReturned { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }

    }
}
