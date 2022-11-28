using System;

namespace WebNDTIT01.Models.Workflows.ITRequestModels
{
    public class ApprovalData
    {
        public string WorkflowId { get; set; }
        public string Status { get; set; }
        public string UserEmail { get; set; }
        public string Applicant { get; set; }
        public string Approver { get; set; }
        public string Username { get; set; }
        public DateTime RequestDateTime { get; set; }
    }

}