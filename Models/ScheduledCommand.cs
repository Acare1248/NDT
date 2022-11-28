using System;
using System.Collections.Generic;

namespace WebNDTIT01.Models
{
    public partial class ScheduledCommand
    {
        public long PersistenceId { get; set; }
        public string CommandName { get; set; }
        public string Data { get; set; }
        public long ExecuteTime { get; set; }
    }
}
