using System.Threading.Tasks;
using WebNDTIT01.Interfaces;
using WebNDTIT01.Models;
using WebNDTIT01.Services;

namespace WebNDTIT01.Workflows.ProcessITRequest.Steps;

public class ApprovedStep : StepBodyAsync
{
    private readonly IEmailService _emailService;
    //private readonly IMailService _mailService;
    public string WorkId { get; set; }
    public string To { get; set; }
    public string From { get; set; }
    public string Subject { get; set; }
    public string Body { get; set; }
    public string DocumentName { get; set; }
    public int DocumentId { get; set; }

    public ApprovedStep(
        IEmailService emailService
        //IMailService mailService
        )
    {
        _emailService = emailService;
        //_mailService = mailService;
    }
    public override async Task<ExecutionResult> RunAsync(IStepExecutionContext context)
    {
        WorkId = context.Workflow.Id;
        Body = $"Your request document has been approved! DocumentName:{DocumentName}";
        Subject = $"Your request has been approved.";

        var request = new MailRequest();
        request.To = To;
        request.Subject = Subject;
        request.Body = Body;
        //await _emailService.SendAsync(request);
        //await _mailService.SendAsync(request);

        return ExecutionResult.Next();

    }


}
