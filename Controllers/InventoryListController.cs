using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebNDTIT01.Models;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebNDTIT01.Controllers
{
    public class InventoryListController :Controller
    {
        /*[BindProperty]
        public int IdcomputerList { get; set; }
        [BindProperty]
        public sbyte compStatus { get; set; }**/

        private readonly ndt_dbContext db;
        public InventoryListController(ndt_dbContext context)
        {
             db = context;
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult ComputerList()
        {
            //var db = new ndt_dbContext();
            /*var rslt = (  from cl in db.TbComputerLists
                            join usr in db.TbUsers on cl.UserId equals usr.IdUser into usrs 
                            from rsusr in usrs.DefaultIfEmpty()
                            join mt in db.TbMonitorLists on cl.MonitorId equals mt.IdMonitorList into mts
                            from rsmt in mts.DefaultIfEmpty()
                            join cpasst in db.TbComputerAssetNos on cl.AssetNo equals cpasst.IdComputerAssetNo into cpassts
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
                            }).ToList();*/

            //return View(rslt);
            return View();
        }
        
        /*Get (HttpGet Method) data all of Computer details on Database, Use to DataTable on Computer List page*/
        [HttpGet]
        public JsonResult GetAllCom()
        {   //var db = new ndt_dbContext();
            var rslt = (  from cl in db.TbComputerLists
                            join usr in db.TbUsers on cl.UserId equals usr.IdUser into usrs 
                            from rsusr in usrs.DefaultIfEmpty()
                            join mt in db.TbMonitorLists on cl.MonitorId equals mt.IdMonitorList into mts
                            from rsmt in mts.DefaultIfEmpty()
                            join cpasst in db.TbComputerAssetNos on cl.AssetNo equals cpasst.IdComputerAssetNo into cpassts
                            from rscpasst in cpassts.DefaultIfEmpty()
                            orderby cl.DataUpdate
                            select new GetAll
                            {
                               IdcomputerList = cl.IdcomputerList,
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
                               Status = cl.Status,
                            }).ToList();
     
            return Json(rslt);
        }
        
        /*Get (HttpGet Method) data all of Computer do not update data on Database, Use Dashboard page*/
        [HttpGet]
        public async Task<JsonResult> GetAllComNotUpdate()
        {
            //var db = new ndt_dbContext();
            await db.Database.ExecuteSqlInterpolatedAsync($"CALL SelectDeviceNotUpdate()");

            var rslt = (  from cl in db.TbComputerLists
                            join usr in db.TbUsers on cl.UserId equals usr.IdUser into usrs 
                            from rsusr in usrs.DefaultIfEmpty()
                            join mt in db.TbMonitorLists on cl.MonitorId equals mt.IdMonitorList into mts
                            from rsmt in mts.DefaultIfEmpty()
                            join cpasst in db.TbComputerAssetNos on cl.AssetNo equals cpasst.IdComputerAssetNo into cpassts
                            from rscpasst in cpassts.DefaultIfEmpty()
                            //where cl.DataUpdate < DateTime.Now.AddDays(-7)
                            where cl.Status == '0' //Non-Active
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

            /*var rslt = (
                //db.Database.ExecuteSqlInterpolated($"CALL SelectDeviceNotUpdate()")
                db.TbComputerLists
                .FromSqlInterpolated($"CALL SelectDeviceNotUpdate()").ToList()) ;

            return Json(rslt);*/
            
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]

        [HttpPost]
        public async Task<IActionResult> UpdateComputerStatus(int IdcomputerList,sbyte compStatus)
        {
            await db.Database.ExecuteSqlInterpolatedAsync($"CALL UpdateStatus ({IdcomputerList},{compStatus})");
                                    
            return Json("Updated");
        }
        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}