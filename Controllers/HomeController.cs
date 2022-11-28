using System;
using Microsoft.AspNetCore.Authorization;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebNDTIT01.Models;
using Newtonsoft.Json;

namespace WebNDTIT01.Controllers
{
    public class HomeController : Controller
    {
        
        /*private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/
        [Authorize(Roles = "Administrator,User")]
        public IActionResult Index()
        {            
            //var db = new ndt_dbContext();
            //Get DATA Direct from Model
            //var tbComputerLists = db.TbComputerList.ToList();
            //var tbUser = db.tbUser.ToList();
            //var CCount = db.GetAll.ToList();
            return View();
        }
      /*public JsonResult GetAllComNotUpdate()
        {
            var db = new ndt_dbContext();
            var rslt = (  from cl in db.TbComputerList
                            join usr in db.tbUser on cl.UserId equals usr.IdUser into usrs 
                            from rsusr in usrs.DefaultIfEmpty()
                            join mt in db.tbMonitorList on cl.MonitorId equals mt.IdMonitorList into mts
                            from rsmt in mts.DefaultIfEmpty()
                            join cpasst in db.TbComputerAssetNo on cl.AssetNo equals cpasst.IdComputerAssetNo into cpassts
                            from rscpasst in cpassts.DefaultIfEmpty()
                            where cl.DataUpdate < DateTime.Now.AddDays(-5)
                            orderby cl.DataUpdate
                            select new GetAll
                            {
                               ComputerName = cl.ComputerName,
                               AssetNo = rscpasst.AssetNo,
                               Os = cl.Os,
                               Ostype = cl.Ostype,
                               ComManufacturer = cl.ComManufacturer,
                               ComModel = cl.ComModel,
                               ComSerialNo = cl.ComSerialNo,
                               CpuModel = cl.CpuModel,
                               Ramsize = cl.Ramsize,
                               Nictype = cl.Nictype,
                               Ipadds = cl.Ipadds,
                               MacAdds = cl.MacAdds,
                               Domain = cl.Domain,
                               UserName = rsusr.UserName,
                               UserLastname = rsusr.UserLastname,
                               MonitorManufacturer = rsmt.MonitorManufacturer,
                               MonitorModel = rsmt.MonitorModel,
                               MonitorSerialNo = rsmt.MonitorSerialNo,
                               MonitorAsset = rsmt.MonitorAsset,
                               DataUpdate = cl.DataUpdate,
                            }).ToList();
     
            return Json(rslt);
        }*/
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }
/*Get data all of Computer details on Database and Store procedure, Use to DataTable on Computer List page*/
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
