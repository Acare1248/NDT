using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebNDTIT01.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace WebNDTIT01.Controllers
{
    public class ConfigController : Controller
    {
        private readonly ndt_dbContext db;
        //private readonly ILogger<HomeController> _logger;
        //public ConfigController(ILogger<HomeController> logger,ndt_dbContext context)
        public ConfigController(ndt_dbContext context)
        {
            //_logger = logger;
             db = context;
        }
       
        public IActionResult MailReport() //When open Email.cshtml on web 
        {
            return View();
        }
        /*public List<WebNDTIT01.Models.EmailModel> Emailtest(int maxCount = 1)
                { //using (var emailClient = new Pop3Client())
                    using (var emailClient = new ImapClient ())
                    {
                        emailClient.Connect("imap.gmail.com", 993, true);
                        emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
                        emailClient.Authenticate("nichidai.it@gmail.com","gjbaxdunokcjoair");
                        List<WebNDTIT01.Models.EmailModel> emails = new List<WebNDTIT01.Models.EmailModel>();
                        var inbox = emailClient.Inbox;
                        inbox.Open (FolderAccess.ReadOnly);
                        var query = SearchQuery.DeliveredOn (DateTime.Parse("2022-01-20"));
                        foreach (var uid in inbox.Search (query)) 
                            {
                                var message = inbox.GetMessage (uid);
                                string a = string.IsNullOrEmpty(message.HtmlBody) ? null : Regex.Replace(message.HtmlBody,"(?i)<td[^>]*>", string.Empty);
                                string MsgBody = string.IsNullOrEmpty(message.HtmlBody) ? null : Regex.Match(message.HtmlBody,@"\bnotification feature provided by Backup Exec\w*\b",RegexOptions.IgnoreCase).ToString();
                                string FromEmail = "";
                                foreach (var mailbox in message.From.Mailboxes){
                                  FromEmail = mailbox.Address.ToString();
                                }
                                
                                var emailMessage = new WebNDTIT01.Models.EmailModel
                                    {
                                        From = FromEmail,
                                        Body = MsgBody,
                                        Subject = message.Subject,
                                        DateSent = message.Date
                                    };
                                emails.Add(emailMessage);
                            }
                        return emails;
                    }
                }*/
//************Configurate Mail tracking report**********///
        public IActionResult MailReportConfig()
        {
            return View();
        }
//***********Insert of Mail tracking report configure *******************************///
        [HttpPost]
        public async Task<IActionResult> InsertMailTrackingReport(TbConfigMailReport InsertMailTR)
        {
            
            int MailReportId = InsertMailTR.MailReportId;
            string ReportName = InsertMailTR.ReportName;
            string MailSubject = InsertMailTR.MailSubject;
           // string MailBody = InsertMailTR.MailBody;
            string MailAccount = InsertMailTR.MailAccount;
            sbyte KeyWordFrom = InsertMailTR.KeyWordFrom;
            string KeySuccess = InsertMailTR.KeySuccess;
            string KeyFailed =InsertMailTR.KeyFailed;
            string KeyWarning =InsertMailTR.KeyWarning;
            sbyte deviceKeywordFrom= InsertMailTR.DeviceKeyFrom;

            var spInsertConfigMailTrackingReport =  await db.TbConfigMailReports
                                                    .FromSqlInterpolated($"CALL InsertConfigMailTrackingReport ({MailReportId},{ReportName},{MailSubject},{MailAccount},{KeyWordFrom},{KeySuccess},{KeyFailed},{KeyWarning},{deviceKeywordFrom})")
                                                    .ToListAsync();

            return Json(spInsertConfigMailTrackingReport);
        }

        [HttpPost]
        public IActionResult DeleteMailTrackingReport(int reportid)
        {
            int reportID = reportid;
            //var spDeleteConfigMailTrackingReport =  
                                                    db.TbConfigMailReports
                                                    .FromSqlInterpolated($"CALL DeleteConfigMailTrackingReport ({reportID})")
                                                    .ToListAsync();

            return Json("Deleted");
        }
//***********Insert Device of Mail tracking report configure ************************///
       /*[HttpPost]
        public async Task<IActionResult> InsertDeviceOfTrackingMailReport(TbConfigDeviceOfReport InsertDeviceMailTR)
        {
            string DeviceName = InsertDeviceMailTR.DeviceName;
            int ReportId = InsertDeviceMailTR.ReportId;
            sbyte KeyWordFrom = InsertDeviceMailTR.KeyFrom;
            string DeviceKeyw = InsertDeviceMailTR.KeyDevice;

            var db = new ndt_dbContext();
            var spInsertConfigDeviceMailTrackingReport = (await db.TbConfigDeviceOfReport
                                                          .FromSqlInterpolated($"CALL InsertConfigDeviceOfReport({DeviceName},{KeyWordFrom},{DeviceKeyw},{ReportId})").ToListAsync()).FirstOrDefault();
            return View();
        }*/
//***********Insert Types Job on Mail tracking to configure *************************///
       [HttpPost]
        public async Task<IActionResult> InsertTypesJobsOfTrackingMailReport(DeviceAndTypesOfReport InsertTypesOfJobMailTR)
        {
            string DeviceName = InsertTypesOfJobMailTR.DeviceName;
            sbyte DeviceKeyFrom = InsertTypesOfJobMailTR.DeviceKeyFrom;
            string KeyDevice = InsertTypesOfJobMailTR.KeyDevice;
            string TypesofJobName = InsertTypesOfJobMailTR.TypesofJobName;
            int ReportId = InsertTypesOfJobMailTR.ReportIdOfDevices;
            sbyte TypesofJobKeyForm = InsertTypesOfJobMailTR.TypesofJobKeyForm;
            string KeyTypes = InsertTypesOfJobMailTR.KeyTypes;

            //var spInsertConfigDeviceMailTrackingReport = (
                                                            await db.DeviceAndTypesOfReports
                                                          .FromSqlInterpolated($"CALL InsertConfigTypesOfJobReport({DeviceName},{DeviceKeyFrom},{KeyDevice},{TypesofJobName},{TypesofJobKeyForm},{KeyTypes},{ReportId})").ToListAsync();//).FirstOrDefault();
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> CheckReportDuplicate(DuplicateCheck ChkReportDup)
        {
      
            string ReportName = ChkReportDup.ReportName;
            string KeyDevice = ChkReportDup.KeyDevice;
            int ReportId = ChkReportDup.ReportIdOfDevices;
            string KeyTypes = ChkReportDup.KeyTypes;
            string DeviceName = ChkReportDup.DeviceName;

            var CheckReportNameDup = (await db.DuplicateChecks
                                        .FromSqlInterpolated($"CALL CheckDuplicateData ({ReportName},{KeyDevice},{ReportId},{KeyTypes},{DeviceName})").ToListAsync()).FirstOrDefault();
            return Json(CheckReportNameDup);
        }
        /***************Reload Select Menu*******************/
        //[HttpGet]
        [HttpPost]
        public async Task<JsonResult> RetrieveReportList()
        {
            var ReportList = (await db.TbConfigMailReports
                             .FromSqlInterpolated($"CALL SelectmailTrackingReportlist('')").ToListAsync());
            return Json(ReportList);
        }
        [HttpGet]
        public JsonResult GetAllReportList() {

            var ReportList = (db.TbConfigMailReports
                            .FromSqlInterpolated($"CALL SelectmailTrackingReportlist('')").ToList());
            return Json(ReportList);
        }
//***********Error Event*******************************///
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}