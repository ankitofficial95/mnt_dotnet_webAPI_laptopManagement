namespace mnt_weApi_LaptopManagement_Code_First.DTO
{
    public class LaptopDTO
    {
        public string? serialNum { get; set; }
        public string? modelNum { get; set; }
        public string? brand { get; set; }
        public string? operatingSystem { get; set; }
        public int ram { get; set; }
        public bool battery { get; set; }
        public bool mic { get; set; }
        public bool keyBoard { get; set; }
        public bool mouse { get; set; }
        public bool speaker { get; set; }
        public bool charger { get; set; }
        public bool isAssigned { get; set; }
        public int storage { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        //public DateTime ModifiedDate { get; set; }
        //public string? ModifiedBy { get; set; }
    }
}

