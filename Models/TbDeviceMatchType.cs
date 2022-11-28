using System;
using System.Collections.Generic;

namespace WebNDTIT01.Models
{
    public partial class TbDeviceMatchType
    {
        public int DeviceMatchTypeId { get; set; }
        public int DeviceId { get; set; }
        public int TypesofJobId { get; set; }
        public sbyte TypekeyForm { get; set; }
    }
}
