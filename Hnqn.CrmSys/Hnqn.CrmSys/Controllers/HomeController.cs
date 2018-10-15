using Hnqn.CrmSys.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hnqn.CrmSys.Models;
using Hnqn.CrmSys.Common;
using System.Web.Security;

namespace Hnqn.CrmSys.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            
            //CrmDbContext db = new CrmDbContext();
            //db.Database.CreateIfNotExists();
            WorkUnit unit = new WorkUnit();
            //添加用户类型模拟数据
            CrmDbContext db = new CrmDbContext();
            //客户模拟数据插入
            //沟通记录表插入数据////////////////////////////////////////////////////
            //List<Recording> recordings = new List<Recording>()
            //{
            //    new Recording(){
            //        CustomerId=db.CustomerInfo.Find(1),
            //        Method="电话沟通",
            //        UserStatusID=db.UserStatus.Find(1),
            //        Degree="高",
            //        Context="大一新生,计算机专业,已缴费",
            //        Result="成功",
            //        RecTime=Convert.ToDateTime("2018-08-09"),
            //        SchoolId=db.SchoolInfo.Find(1),
            //        Lock=1
            //    },
            //    new Recording(){
            //        CustomerId=db.CustomerInfo.Find(2),
            //        Method="当面沟通",
            //        UserStatusID=db.UserStatus.Find(2),
            //        Degree="中",
            //        Context="大二老生,未缴费",
            //        Result="成功",
            //        RecTime=Convert.ToDateTime("2018-08-11"),
            //        SchoolId=db.SchoolInfo.Find(1),
            //        Lock=1
            //    },
            //    new Recording(){
            //        CustomerId=db.CustomerInfo.Find(3),
            //        Method="当面沟通",
            //        UserStatusID=db.UserStatus.Find(3),
            //        Degree="低",
            //        Context="计算机专业,未缴费",
            //        Result="失败",
            //        RecTime=Convert.ToDateTime("2018-08-15"),
            //        SchoolId=db.SchoolInfo.Find(2),
            //        Lock=1
            //    }
            //};

            //db.Recording.AddRange(recordings);
            //db.SaveChanges();

            return View();
        }
        
       
    }
}