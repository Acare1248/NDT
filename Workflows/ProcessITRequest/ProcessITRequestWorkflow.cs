using WebNDTIT01.Workflows.ProcessITRequest.Steps;
using WebNDTIT01.Models.Workflows.ITRequestModels;
using System;

namespace WebNDTIT01.Workflows.ProcessITRequest
{
    public class ProcessITRequestWorkflow : IWorkflow<ApprovalData>
    {
    public string Id => nameof(ProcessITRequestWorkflow);
    public int Version => 1;

        public void Build(IWorkflowBuilder<ApprovalData> builder)
        {
            builder
                .StartWith<InitialStep>()
                     //Input(zz.za = receive data, xx.xa= Source data)
                    .Input(step => step.To, data => data.UserEmail)
                    .Input(step => step.From, data => data.Username)
                    .Output(data => data.WorkflowId, step => step.WorkId)
                 
                .UserTask("Do you approve", data => data.Approver)
                    .WithOption("Approve", "I approve").Do(then => then
                    .StartWith<ApprovedStep>()
                    .Input(step => step.To, data => data.Applicant)
                    )
                    .WithOption("Rejected", "I do not approve").Do(then => then
                    .StartWith<RejectedStep>()
                    .Input(step => step.To, data => data.Applicant)
                    )
                .Then(context => Console.WriteLine("end"));
        }
    }
}
