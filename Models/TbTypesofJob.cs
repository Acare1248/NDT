using System;
using System.Collections.Generic;

namespace WebNDTIT01.Models
{
    public partial class TbTypesofJob
    {
        public int TypesofJobId { get; set; }
        public string TypesofJobName { get; set; }
        public sbyte KeyForm { get; set; }
        public string KeyTypes { get; set; }
        public int ReportId { get; set; }
        public int DeviceId { get; set; }
    }
}
