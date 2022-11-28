using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebNDTIT01.Models;
using WebNDTIT01.Services;
using System.Runtime.Versioning;
using System.Collections.Generic;
using WebNDTIT01.Models.Workflows.ITRequestModels;
using WebNDTIT01.Workflows.ProcessITRequest;
using System.Linq;

namespace WebNDTIT01.Controllers
{
    public class ITDocumentsController : Controller
    {
        private readonly IWorkflowHost workflowHost;

        //private readonly ILogger<HomeController> _logger;
        //public ITDocumentsController(ILogger<HomeController> logger, IWorkflowHost workflowHost)
        public ITDocumentsController(IWorkflowHost workflowHost)
        {
            this.workflowHost = workflowHost;
            //_logger = logger;
        }

        [Authorize(Roles = "Administrator,User")]
        public IActionResult ITRequest()
        {
           
            return View();
        }

        [HttpPost]
        public IActionResult ITRequestsubmit(ApprovalData model)
        {
            if(ModelState.IsValid)
            {
                workflowHost.StartWorkflow(nameof(ProcessITRequestWorkflow), model);
                TempData["Message"] = @"Success for submit.";
                return RedirectToAction(nameof(ITRequest));
            }
            return View(model);
        }

        public IActionResult ITRequestapproval(ApprovalData model)
        {
            if (ModelState.IsValid)
            {
                var workflow = workflowHost.PersistenceStore.GetWorkflowInstance(model.WorkflowId).Result;
                var openItems = workflow.GetOpenUserActions();
                //string WorkflowId = workflowHost.StartWorkflow("ProcessITRequestWorkflow").Result;
                //var openItems = workflowHost.GetOpenUserActions(WorkflowId);
                //workflowHost.PublishUserAction(openItems.First().Key, "Sompol Nakhum", 1);
            }
            return View(model);
        }
        [AllowAnonymous]
        [SupportedOSPlatform("windows")]
        public JsonResult ITRequestUserAD(string para)
        {
            List<ADPerson> persons = LDAPUtil.FinduserAD(para);
            return Json(persons);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
