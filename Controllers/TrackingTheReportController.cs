using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebNDTIT01.Models;
using MailKit.Net.Imap;
using MailKit.Search;
using MailKit;
using System.Text.RegularExpressions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;
using System.Data;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Dynamic;
using System;

namespace WebNDTIT01.Controllers
{
    //[Authorize]
    public class TrackingTheReportController : Controller
    {
        private readonly IConfiguration Configuration;
        private readonly ndt_dbContext db;
        //private readonly ILogger<HomeController> _logger;
        //public TrackingTheReportController(ILogger<HomeController> logger, IConfiguration _configuration,ndt_dbContext context)
        public TrackingTheReportController(IConfiguration _configuration, ndt_dbContext context)
        {
           // _logger = logger;
            Configuration = _configuration;
            db = context;
        }
        

        public IActionResult Email() //When open Email.cshtml on web 
            {
                return View(Emailtest());   //Call Function EmailTest and returmn result to View ( View of Email.cshtml)
            }
        public List<WebNDTIT01.Models.EmailModel> Emailtest(int maxCount = 1)
        {
            using var emailClient = new ImapClient();
             //using (var emailClient = new ImapClient ()) 
                    //{
                        emailClient.Connect("imap.gmail.com", 993, true);
                        emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
                        emailClient.Authenticate("nichidai.it@gmail.com", "gqfsvvwxaangxwsu");
                       // List<WebNDTIT01.Models.EmailModel> emails = new List<WebNDTIT01.Models.EmailModel>();
                        List<WebNDTIT01.Models.EmailModel> emails = new ();

            var inbox = emailClient.Inbox;
                        inbox.Open (FolderAccess.ReadOnly);
                        var query = SearchQuery.DeliveredAfter (DateTime.Now.AddDays(-7));

                        foreach (var uid in inbox.Search (query)) 
                            {
                                var message = inbox.GetMessage (uid);

                                //string sss = Regex.Replace(message.HtmlBody,@"\s+",string.Empty);
                                string subjectClean = string.IsNullOrEmpty(message.Subject) ? "" : Regex.Replace(message.Subject,@"(\u00a9|\u00ae|[\u2000-\u3300]|\ud83c[\ud000-\udfff]|\ud83d[\ud000-\udfff]|\ud83e[\ud000-\udfff])",string.Empty);
                                string RemoveSpaceOnBody = string.IsNullOrEmpty(message.HtmlBody) ? "" : Regex.Replace(message.HtmlBody,@"(<style[\w\W]+style>)|<[^>]*",string.Empty);
                                string mailBodyClean = string.IsNullOrEmpty(RemoveSpaceOnBody) ? "" : Regex.Replace(RemoveSpaceOnBody,@">96|>|&nbsp;",string.Empty);
                                Task <(int,int,string,string,string,int,int)> resultCheck =  checkReportmatch(subjectClean,mailBodyClean); //Send mailSubject and blank to check KeyWordFrom and DeviceKeyFrom #1

                                int rpID = resultCheck.Result.Item1;
                                string ks = resultCheck.Result.Item3;
                                string kf = resultCheck.Result.Item4;
                                string kw = resultCheck.Result.Item5;
                                int dvID = resultCheck.Result.Item6;
                                int tjID = resultCheck.Result.Item7;
                            
                                if(rpID != 0)
                                { 
                                    foreach (var mailbox in message.From.Mailboxes)
                                    {
                                        string FromEmail = mailbox.Address.ToString();

                                        string pmailID = string.IsNullOrEmpty(message.Date.ToString()) ? "" : Regex.Replace(message.Date.ToString(),@"\D",string.Empty);
                                        string xxx = message.Date.ToString("yyyy-MM-dd hh:mm:ss");
                                        string dateWithoutTime = message.Date.ToString("yyyy-MM-dd");
                                        var emailMessage = new WebNDTIT01.Models.EmailModel
                                                        {
                                                        From = pmailID+"/ "+xxx+"/ "+xxx+"/ "+xxx+"/ "+rpID + "/ "+rpID+"/ "+dvID+"/ "+tjID+"/ "+ks+kf+kw,
                                                        };
                                        emails.Add(emailMessage);
                                       Task updateEmailLogs = updateEmailLog(pmailID,xxx,dateWithoutTime,rpID,dvID,tjID,mailBodyClean,ks,kf,kw);
                                    }
                                }
                            }
                        return emails;
                    //}
        }
        /*{var db = new ndt_dbContext();
                    //using (var emailClient = new Pop3Client())
                    using (var emailClient = new ImapClient ()) 
                    {
                        emailClient.Connect("imap.gmail.com", 993, true);
                        emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
                        emailClient.Authenticate("nichidaithailand@gmail.com","Ndt*038185245");
                        List<WebNDTIT01.Models.EmailModel> emails = new List<WebNDTIT01.Models.EmailModel>();
                        var inbox = emailClient.Inbox;
                        inbox.Open (FolderAccess.ReadOnly);
                        //var query = SearchQuery.DeliveredOn (DateTime.Parse("2022-01-21"));
                        //var datetest = DateTime.Now.AddDays(7);
                        var query = SearchQuery.DeliveredAfter (DateTime.Now.AddDays(-7));
                        foreach (var uid in inbox.Search (query)) 
                            {
                                //Test Value compare with dataBase
                                string dbEmailAcc = "veritas.report@ndt.local";
                                string dbsubject = "Backup Exec Alert:";
                                
                                string testStr = "The job completed successfully. However";
                                string sss = Regex.Replace(testStr,@"\s+",string.Empty);

                                var message = inbox.GetMessage (uid);

                                string FromEmail = "";
                                foreach (var mailbox in message.From.Mailboxes){
                                  FromEmail = mailbox.Address.ToString();
                                }

                                if(FromEmail == dbEmailAcc){
                                    if(Regex.Match(message.Subject,dbsubject,RegexOptions.IgnoreCase).Success)
                                    {
                                        // string a = string.IsNullOrEmpty(message.HtmlBody) ? "" : Regex.Replace(message.HtmlBody,"(?i)<td[^>]*>", string.Empty);
                                        string RemoveSpaceOnBody = string.IsNullOrEmpty(message.HtmlBody) ? "" : Regex.Replace(message.HtmlBody,@"\s+",string.Empty);
                                        string DateID = string.IsNullOrEmpty(message.Date.ToString()) ? "" : Regex.Replace(message.Date.ToString(),@"\D",string.Empty);
                                        //string daa = message.Date.ToString();
                                        // string MsgBody = string.IsNullOrEmpty(message.HtmlBody) ? "" : Regex.Match(message.HtmlBody,@"\bThe job completed successfully.  However\w*\b",RegexOptions.IgnoreCase).ToString();
                                        //*Check keyword and body macth or not.
                                        string MsgBody = string.IsNullOrEmpty(message.HtmlBody) ? "" : Regex.Match(RemoveSpaceOnBody,sss,RegexOptions.IgnoreCase).ToString();
                                            var emailMessage = new WebNDTIT01.Models.EmailModel
                                                {
                                                    MailID = DateID,
                                                    From = FromEmail,
                                                   // Body = MsgBody,
                                                   Body = message.HtmlBody,
                                                    Subject = message.Subject,
                                                    DateSent = message.Date
                                                };
                                    emails.Add(emailMessage);
                                }
                            }
                            }
                        return emails;
                    }
                }*/
        //OpenPOP receive email
        /*private List<WebNDTIT01.Models.EmailModel> Emailtest()
        {
            Pop3Client pop3Client = new Pop3Client();
            pop3Client.Connect("pop.gmail.com", 995, true);
            pop3Client.Authenticate("nichidaithailand@gmail.com","Ndt*038185245",AuthenticationMethod.Auto);

            int count = pop3Client.GetMessageCount();
            List<EmailModel> emails = new List<EmailModel>();
            int counter = 0;
            for(int i = count; i>=1; i--)
            {
                Message message = pop3Client.GetMessage(i);
                EmailModel email = new EmailModel()
                    {
                        MessageNumber= i,
                        From = string.Format("<a href = 'mailto:{1}'>{0}</a>", message.Headers.From.DisplayName, message.Headers.From.Address),
                        Subject = message.Headers.Subject,
                        DateSent = message.Headers.DateSent
                    };
                    MessagePart body =message.FindFirstHtmlVersion();
                    if(body != null)
                    {
                        email.Body = body.GetBodyAsText();
                    }
                    else
                    {
                        body = message.FindFirstPlainTextVersion();
                        if(body != null){
                            email.Body = body.GetBodyAsText();
                        }
                    }
                    emails.Add(email);
                    counter++;
                    if(counter > 100){
                        break;
                    }
            }
            return emails;
        }*/
        //public async Task<JsonResult> checkReportmatch(string a)
        public async Task<(int,int,string,string,string,int,int)> checkReportmatch(string mailSubject, string mailBody)
        {
            //var sw = new Stopwatch();
            int reportID = 0;
            int typeJobID = 0;
            int reportKeyFrom = 0;
            int deviceKeyFrom = 0;
            string KeySuccess = null;
            string KeyFailed= null;
            string KeyWarning = null;
            int deviceId = 0;
            string contentChk = null;
            string chkDeviceFrom = null;

            //var db = new ndt_dbContext();
           //TEST USE LINQ
            var qryResult = await (from rp in db.TbConfigMailReports
                            where mailSubject.Contains(rp.MailSubject)
                            orderby rp.MailSubject ascending
                            select rp).Take(1).ToListAsync();

             if(qryResult.Count != 0 ){
                //sw.Start();
                 reportID = qryResult[0].MailReportId;
                 reportKeyFrom = qryResult[0].KeyWordFrom;
                 deviceKeyFrom = qryResult[0].DeviceKeyFrom;
                 string chkKeySuccess = qryResult[0].KeySuccess;
                 string chkKeyFailed = qryResult[0].KeyFailed;
                 string chkKeyWarning = qryResult[0].KeyWarning;
                 
                 if(reportKeyFrom == 1){ //if 1, find keyword from Subject.
                   contentChk = mailSubject;
                 }else if(reportKeyFrom == 2){
                     contentChk = mailBody;
                 }

                        if(chkKeySuccess != null){
                        var ks = await (from rp in db.TbConfigMailReports
                                             where contentChk.Contains(rp.KeySuccess) &&
                                                   rp.MailReportId == reportID
                                             select rp.KeySuccess).Take(1).ToListAsync();
                            KeySuccess = ks.Count != 0 ? ks[0].ToString() : null;}
                        if(chkKeyFailed != null){
                        var kf = await (from rp in db.TbConfigMailReports
                                             where contentChk.Contains(rp.KeyFailed) &&
                                                   rp.MailReportId == reportID
                                             select rp.KeyFailed).Take(1).ToListAsync();
                            KeyFailed = kf.Count != 0 ? kf[0].ToString() : null;}
                        if(chkKeyWarning != null){
                         var kw = await (from rp in db.TbConfigMailReports
                                             where contentChk.Contains(rp.KeyWarning) &&
                                                   rp.MailReportId == reportID
                                             select rp.KeyWarning).Take(1).ToListAsync();
                            KeyWarning = kw.Count != 0 ? kw[0].ToString() : null;}

                //start Check device ID
                if(deviceKeyFrom == 1){ //if 1, find keyword from Subject.
                   chkDeviceFrom = mailSubject;
                 }else if(deviceKeyFrom == 2){
                     chkDeviceFrom = mailBody;
                 }
                    var querydeviceId = await (  from cdr in db.TbConfigDeviceOfReports
                                            where chkDeviceFrom.Contains(cdr.KeyDevice)
                                            select cdr.DeviceId).Take(1).ToListAsync();
                    deviceId = querydeviceId.Count != 0 ? querydeviceId[0] : 0;

                    var querytypeId = await ( from tj in db.TbTypesofJobs
                                            where reportID == tj.ReportId &&
                                                  deviceId == tj.DeviceId
                                            select tj.KeyForm).ToArrayAsync();                       

                    foreach(var kf in querytypeId.ToList())
                    {
                        string chkTypeFrom = null;
                         if(kf == 1){ //if 1, find keyword from Subject.
                            chkTypeFrom = mailSubject;
                            }else if(kf == 2){
                                chkTypeFrom = mailBody;}
                            
                            var querytypeJKF = await ( from tj in db.TbTypesofJobs
                                                        //where chkTypeFrom.Contains(EF.Functions.Collate(tj.KeyTypes, "utf8mb3_bin")) &&
                                                         where chkTypeFrom.Contains(EF.Functions.Collate(tj.KeyTypes, "utf8mb4_bin")) &&
                                                            reportID == tj.ReportId &&
                                                            deviceId == tj.DeviceId
                                                        select tj.TypesofJobId).ToListAsync();
                                            
                            typeJobID = querytypeJKF.Count != 0 ? querytypeJKF[0] : 0;
                    }
            }
            return (reportID,deviceKeyFrom,KeySuccess,KeyFailed,KeyWarning,deviceId,typeJobID);
        }
        public async Task updateEmailLog(string pmailID,string dateST,string dateWithoutTime,int rpID,int dvID,int tjID,string mailBodyClean,string ks,string kf,string kw)
        {
            //var db = new ndt_dbContext();
            //Console.WriteLine("CALL InsertEmailLog("+pmailID+","+dateST+","+dateWithoutTime+","+dateWithoutTime+","+rpID+","+dvID+","+tjID+","+mailBodyClean+","+ks+","+kf+","+kw+")");

            //var callSPinsertMailLog = ( 
            await db.MailreportlogTbCollectionsYearMonths
           .FromSqlInterpolated($"CALL InsertEmailLog({pmailID},{dateST},{dateWithoutTime},{dateWithoutTime},{rpID},{dvID},{tjID},{mailBodyClean},{ks},{kf},{kw})").ToListAsync();
            //                           );
             
            //Console.WriteLine("CALL InsertEmailLog("+pmailID+","+dateST+","+dateWithoutTime+","+dateWithoutTime+","+rpID+","+dvID+","+tjID+","+mailBodyClean+","+ks+","+kf+","+kw+")");
        } 
      
        public IActionResult ReportTracking()
        {
            return View();
        }
        [HttpPost]
        public IEnumerable<dynamic> ReportTrackingResult(searchReport pReport)
        {
            string ReportID = string.IsNullOrEmpty(pReport.ReportID) ? "0" : pReport.ReportID;
            string Monthly = string.IsNullOrEmpty(pReport.Monthly) ? "0000-00-00" : pReport.Monthly;
            //var db = new ndt_dbContext();

            string connString = this.Configuration.GetConnectionString("DefaultConnection");
            MySql.Data.MySqlClient.MySqlConnection conn;

            string queryString = "call testSpEmaillog ('"+ReportID+"','"+Monthly+"')";

            conn = new MySql.Data.MySqlClient.MySqlConnection
            {
                ConnectionString = connString
            };

            //MySqlCommand command = new MySqlCommand(queryString,conn);
            MySqlCommand command = new(queryString, conn);

            conn.Open();
            
            MySqlDataReader rdr = command.ExecuteReader();
            while (rdr.Read())
                {
                    yield return ToExpandoObject(rdr);
                }
            conn.Close();
        } 
        private static dynamic ToExpandoObject(IDataRecord record)
            {
                var expandoObject = new ExpandoObject() as IDictionary<string, object>;

                for (var i = 0; i < record.FieldCount; i++)
                    expandoObject.Add(record.GetName(i), record[i]);
                
                return expandoObject;
            }
        [HttpPost]
        public JsonResult ReportTrackingDetailResult(searchReport pReport)
        {
            int x;
            x = 0;
            string iDate;
            DateTime oDatex;
            if (Int32.TryParse(pReport.ReportID, out x))
                {
                    int ReportID = Int32.Parse(pReport.ReportID);
                }
            string Monthly = string.IsNullOrEmpty(pReport.Monthly) ? "1900-01-01" : pReport.Monthly;
            if(Monthly =="1900-01-01"){
                oDatex = DateTime.Today;
            }else{
                iDate = Monthly;
                oDatex = DateTime.Parse(iDate);
            }
            //var db = new ndt_dbContext();
            var rslt = (  from mrcl in db.MailreportlogTbCollectionsYearMonths
                            where mrcl.LogStatus != "1" && mrcl.LogStatus != "0"
                            where mrcl.ReportId == x
                            where mrcl.Monthly.Month == oDatex.Month
                            select mrcl
                            /*{
                               MailLogId = mrcl.MailLogId,
                               Mailid = mrcl.Mailid,
                               Datetimest  = mrcl.Datetimest,
                               Monthly = mrcl.Monthly,
                                Yearly = mrcl.Yearly,
                                ReportId = mrcl.ReportId,
                                DeviceId = mrcl.DeviceId,
                                TypesofJobId = mrcl.TypesofJobId,
                                MailBody = mrcl.MailBody,
                                KeySuccess = mrcl.KeySuccess,
                                KeyFailed = mrcl.KeyFailed,
                                KeyWarning = mrcl.KeyWarning,
                            }*/).ToList();
     
            return Json(rslt);
            
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}