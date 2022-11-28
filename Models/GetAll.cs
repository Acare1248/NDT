using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

#nullable disable

namespace WebNDTIT01.Models
{
    public partial class GetAll
    {
        [Key]
        public int IdcomputerList { get; set; }
        public string ComputerName { get; set; }
        public string AssetNo { get; set; }
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
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string UserLastname { get; set; }
        public string UserLogin { get; set; }
        public int IdMonitorList { get; set; }
        public string MonitorManufacturer { get; set; }
        public string MonitorModel { get; set; }
        public string MonitorSerialNo { get; set; }
        public int? MonitorAsset { get; set; }
        public sbyte? Status { get; set; }
    }
}
