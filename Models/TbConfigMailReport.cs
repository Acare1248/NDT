using System;
using System.Collections.Generic;

namespace WebNDTIT01.Models
{
    public partial class TbConfigMailReport
    {
        public int MailReportId { get; set; }
        public string ReportName { get; set; }
        public string MailSubject { get; set; }
        public string MailBody { get; set; }
        public string MailAccount { get; set; }
        public sbyte KeyWordFrom { get; set; }
        public string KeySuccess { get; set; }
        public string KeyFailed { get; set; }
        public string KeyWarning { get; set; }
        public sbyte DeviceKeyFrom { get; set; }
    }
}
