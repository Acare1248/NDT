using System.Threading.Tasks;
using WebNDTIT01.Interfaces;
using WebNDTIT01.Models;
using WebNDTIT01.Services;

namespace WebNDTIT01.Workflows.ProcessITRequest.Steps;

public class RejectedStep :StepBodyAsync
{
    //private readonly IMailService _mailService;
    private readonly IEmailService _emailService;
    public string WorkId { get; set; }
    public string DocumentName { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public string To { get; set; }
    public string From { get; set; }
    public string Approver { get; set; }
    public string Outcome { get; set; }
    public string Comments { get; set; }
    public RejectedStep(
        //IMailService mailService, 
        IEmailService emailService)
    {
        //_mailService = mailService;
        _emailService = emailService;
    }

    public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
    {
        WorkId = context.Workflow.Id;
        Body = $"Your request document has been rejected! DocumentName:{DocumentName}";
        Subject = $"Your request has been rejected.";
        var request = new MailRequest();
        request.To = To;
        request.Subject = Subject;
        request.Body = Body;
        //await _mailService.SendAsync(request);
        //await _emailService.SendAsync(request);

        return ExecutionResult.Next();
    }
}
