using System;


namespace WebNDTIT01.Models
{
    public class EmailModel
    {
        public string MailID {get; set;}
        public int MessageNumber { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTimeOffset DateSent { get; set; }
    }
}