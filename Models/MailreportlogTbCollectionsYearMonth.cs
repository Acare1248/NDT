using System;
using System.Collections.Generic;

namespace WebNDTIT01.Models
{
    public partial class MailreportlogTbCollectionsYearMonth
    {
        public int MailLogId { get; set; }
        public string Mailid { get; set; }
        public DateTime Datetimest { get; set; }
        public DateTime Monthly { get; set; }
        public DateTime Yearly { get; set; }
        public int ReportId { get; set; }
        public int DeviceId { get; set; }
        public int? TypesofJobId { get; set; }
        public string MailBody { get; set; }
        public string KeySuccess { get; set; }
        public string KeyFailed { get; set; }
        public string KeyWarning { get; set; }
        public string LogStatus { get; set; }
    }
}
