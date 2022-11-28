using System;
using System.Collections.Generic;

namespace WebNDTIT01.Models
{
    public partial class TbMsSoftwareList
    {
        public int IdMsSoftwareList { get; set; }
        public string ProductName { get; set; }
        public string ProductKey { get; set; }
        public string ProductId { get; set; }
        public string ComputerName { get; set; }
        public DateTime? MsSoftwareDateCreate { get; set; }
        public DateTime LastInsertData { get; set; }
    }
}
