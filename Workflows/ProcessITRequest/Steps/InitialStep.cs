using WebNDTIT01.Interfaces;
using WebNDTIT01.Models;
using WebNDTIT01.Models.Workflows.ITRequestModels;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace WebNDTIT01.Workflows.ProcessITRequest.Steps;

public class InitialStep : StepBody
//public class InitialStep : StepBodyAsync
{
    private readonly IEmailService _emailService;
    public string WorkId { get; set; }
    public string To { get; set; }
    public string From { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public string DocumentName { get; set; }
    public InitialStep(IEmailService emailService)
    {
        _emailService = emailService;
     
    }
    public override ExecutionResult Run(IStepExecutionContext context)
    //public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
    {
               
        WorkId = context.Workflow.Id;
        Body = $"Please,Approval this document:{DocumentName},workflowid:{WorkId},URL:http://....";
        Subject = $"a new document approval request";

        var request = new MailRequest();
        request.To = To;
        //Static "From"  from system email
        //request.From = From;
        request.Subject = Subject;
        request.Body = Body;

        _emailService.Send(request);

        var approval = new ApprovalData();

        if (approval != null)
        {
            approval.Status = "Pendingxx";
            approval.RequestDateTime = DateTime.Now;  
        }

        return ExecutionResult.Next();
    }
}

/*public class InitialStep : StepBodyAsync
{
    //private readonly IWorkflowDbContext _workflowDbContext;
    private readonly IEmailService _emailService;

    public string WorkId { get; set; }
    public string To { get; set; }
    public string From { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public string DocumentName { get; set; }
    public InitialStep(IEmailService emailService)
       // ,IWorkflowDbContext workflowDbContext)        
    {
        _emailService = emailService;
       // _workflowDbContext = workflowDbContext;
    }

    public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
    {
        //Console.WriteLine("strat flow");
        //var approval = _workflowDbContext.ApprovalDatas.FirstOrDefault(x => x.WorkflowId == WorkId);
        WorkId = context.Workflow.Id;
        //Body = $"Please,Approval this document:{DocumentName},workflowid:{WorkId},URL:http://....";
        Body = $"Please,Approval this document:{DocumentName},workflowid:{WorkId},URL:http://....";
        //Body = $"Please,Approval this document:{approval.Approver},workflowid:{WorkId},URL:http://....";
        Subject = $"a new document approval request";

        var request = new MailRequest();
        request.To = To;
        request.Subject = Subject;
        request.Body = Body;

        //await _emailService.SendAsync("sompol_n@nichidai.co.th", "A", "b", "sompol_n@nichidai.co.th");
        //await _emailService.Send("sompol_n@nichidai.co.th", "A", "b", "sompol_n@nichidai.co.th");
        //await _emailService.Send(request);
       // await _emailService.SendAsync(request);

        /*if (approval != null)
        {
            approval.Status = "Pending";
            approval.RequestDateTime = DateTime.Now;
        }
        return ExecutionResult.Next();
    }
}*/