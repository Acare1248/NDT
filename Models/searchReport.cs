using System;
using Microsoft.EntityFrameworkCore;

namespace WebNDTIT01.Models
{
       [Keyless]
    public partial class searchReport
    {
        public string ReportID { get; set; }
        public string Monthly { get; set; }
    }
}


