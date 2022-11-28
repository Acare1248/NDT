using Microsoft.EntityFrameworkCore;

namespace WebNDTIT01.Models
{
    [Keyless]
    public partial class DuplicateCheck
    {
        public string ReportName { get; set; }
        public string KeyDevice { get; set; }
        public int ReportIdOfDevices { get; set; }
        public string KeyTypes { get; set; }
        public string DeviceName { get; set; }
    }
}