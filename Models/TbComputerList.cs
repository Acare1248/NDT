using System;
using System.Collections.Generic;

namespace WebNDTIT01.Models
{
    public partial class TbComputerList
    {
        public int IdcomputerList { get; set; }
        public string ComputerName { get; set; }
        public int AssetNo { get; set; }
        public string Os { get; set; }
        public string Ostype { get; set; }
        public string ComManufacturer { get; set; }
        public string ComModel { get; set; }
        public string ComSerialNo { get; set; }
        public string CpuModel { get; set; }
        public int? Ramsize { get; set; }
        public string Nictype { get; set; }
        public string Ipadds { get; set; }
        public string MacAdds { get; set; }
        public string Domain { get; set; }
        public int? MonitorId { get; set; }
        public int? UserId { get; set; }
        public int? LocationId { get; set; }
        public DateTime DataUpdate { get; set; }
        public sbyte? Status { get; set; }
    }
}
