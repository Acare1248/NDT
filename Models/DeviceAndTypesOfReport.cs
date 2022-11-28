using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebNDTIT01.Models
{
    [Keyless]
    public partial class DeviceAndTypesOfReport
    {
        public string ReportName { get; set; }
        public string DeviceName { get; set; }
        public sbyte DeviceKeyFrom { get; set; }
        public string KeyDevice { get; set; }
        public int ReportIdOfDevices { get; set; }
        public string TypesofJobName { get; set; }
        public sbyte TypesofJobKeyForm { get; set; }
        public string KeyTypes { get; set; }
        public int ReportIdOfTypesJob { get; set; }
    }
}