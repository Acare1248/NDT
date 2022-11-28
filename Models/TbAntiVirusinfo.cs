using System;
using System.Collections.Generic;

namespace WebNDTIT01.Models
{
    public partial class TbAntiVirusinfo
    {
        public int IdAntiVirusinfo { get; set; }
        public string ProductName { get; set; }
        public string ProductVersion { get; set; }
        public DateTime? LatestVirusDefsDate { get; set; }
        public DateTime? LastConnectedTime { get; set; }
        public string ComputerName { get; set; }
    }
}
