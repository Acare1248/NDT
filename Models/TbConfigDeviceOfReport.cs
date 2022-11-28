using System;
using System.Collections.Generic;

namespace WebNDTIT01.Models
{
    public partial class TbConfigDeviceOfReport
    {
        public int DeviceId { get; set; }
        public string DeviceName { get; set; }
        public sbyte KeyFrom { get; set; }
        public string KeyDevice { get; set; }
        public int ReportId { get; set; }
        public sbyte? TypeKeyForm { get; set; }
    }
}
