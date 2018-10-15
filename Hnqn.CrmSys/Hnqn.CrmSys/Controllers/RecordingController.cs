using Hnqn.CrmSys.Dal;
using Hnqn.CrmSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hnqn.CrmSys.Controllers
{
    public class RecordingController : Controller
    {
        // GET: Recording
        WorkUnit unit = new WorkUnit();
        CrmDbContext db = new CrmDbContext();//获取数据源
       
        public ActionResult Recording()
        {
            return View();
        }
        /// <summary>
        ///  查询沟通记录
        /// </summary>
        /// <param name="index"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public ActionResult GetRecord(int index, int limit)
        {
            var cusId =Request.Params["cusId"];//查询条件
            int id = Convert.ToInt32(cusId);
            //如果有查询条件
            if (cusId != null)
            {
                var list = unit.Recording.GetPageEntitys(m => m.Lock == 1, limit, index - 1);
                var count = unit.Recording.Where(m => m.Lock == 1&&m.Id == id).ToList().Count();
                var recList = from rec in list
                              join cum in db.CustomerInfo
                              on rec.CustomerId.Id equals cum.Id
                              join usersta in db.UserStatus
                              on rec.UserStatusID.Id equals usersta.Id
                              join school in db.SchoolInfo
                              on rec.SchoolId.Id equals school.Id
                              where(rec.Id== Convert.ToInt16(cusId))
                              select new
                              {
                                  rec.Id,
                                  cum.CusName,
                                  rec.Method,
                                  rec.Degree,
                                  rec.Context,
                                  rec.Result,
                                  rec.RecTime,
                                  usersta.UserStatusName,
                                  school.SchoolName
                              };
                return Json(new { code = 0, msg = "", tatol = count, data = recList }, JsonRequestBehavior.AllowGet);//返回数据
            }
            //如果没有
            else
            {
                var list = unit.Recording.GetPageEntitys(m => m.Lock == 1, limit, index - 1);
                var count = unit.Recording.Where(m => m.Lock == 1).ToList().Count();
                var recList = from rec in list
                              join cum in db.CustomerInfo
                              on rec.CustomerId.Id equals cum.Id
                              join usersta in db.UserStatus
                              on rec.UserStatusID.Id equals usersta.Id
                              join school in db.SchoolInfo
                              on rec.SchoolId.Id equals school.Id
                              select new
                              {
                                  rec.Id,
                                  cum.CusName,
                                  rec.Method,
                                  rec.Degree,
                                  rec.Context,
                                  rec.Result,
                                  rec.RecTime,
                                  usersta.UserStatusName,
                                  school.SchoolName
                              };
                return Json(new { code = 0, msg = "", tatol = count, data = recList }, JsonRequestBehavior.AllowGet);//返回数据
            }      
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult Del(int Id)
        {
            string sql = $"update Recordings set lock=0 where Id={Id}";
            try
            {
                unit.Recording.ExecuteSql(sql);
                return View();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ActionResult RecordEdit()
        {
            return View("RecordEdit");
        }
        /// <summary>
        /// 编辑  （有问题）
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult RecordEdit(int Id)
        {
            var list = unit.Recording.Where(m => m.Lock == 1 && m.Id == Id).ToList();
            var reclists = from relist in list
                           select new
                           {
                               relist.Id,
                               relist.Method,
                               relist.Degree,
                               relist.Context,
                               relist.Result,
                               relist.RecTime,

                           };
            return Json(reclists,JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 校区数据显示
        /// </summary>
        /// <param name="locks"></param>
        /// <returns></returns>
        public ActionResult RecordEditAction(string locks)
        {
           var lockes = Convert.ToInt16(locks);
            var school = unit.SchoolInfo.Where(m => m.Lock == lockes).ToList();
            var schoollist = from sclist in school
                             select new
                             {
                                 sclist.Id,
                                 sclist.SchoolName
                             };
            return Json(schoollist,JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 客户状态数据显示
        /// </summary>
        /// <param name="locks"></param>
        /// <returns></returns>
        public ActionResult GetAllUserStatus(string locks)
        {
            var lockes = Convert.ToInt16(locks);
            var UserStatus = unit.UserStatus.Where(m => m.Lock == lockes).ToList();
            var UserStatuslist = from uslist in UserStatus
                                 select new
                             {
                                     uslist.Id,
                                     uslist.UserStatusName
                             };
            return Json(UserStatuslist, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <returns></returns>
        public ActionResult RecordingAddData()
        {
            return View();
        }
        /// <summary>
        /// 添加数据视图
        /// </summary>
        /// <returns></returns>
        public ActionResult RecordingAddDataView()
        {
            return View("RecordingAddData");
        }
        /// <summary>
        /// 添加数据方法
        /// </summary>
        /// <returns></returns>
        public ActionResult RecordingAddDataAction(Recording recording,string SchoolId,string StatusId,string RecordCustomerId,string locks)
        {
            int Lock = Convert.ToInt16(locks);
            Lock = 1;
            int schoolId = Convert.ToInt32(SchoolId);
            int statusId = Convert.ToInt32(StatusId);
            int customerId = Convert.ToInt32(RecordCustomerId);

            SchoolInfo schoolInfo = unit.SchoolInfo.Where(m => m.Id == schoolId).FirstOrDefault();
            UserStatus status = unit.UserStatus.Where(m => m.Id == statusId).FirstOrDefault();
            CustomerInfo customerInfo = unit.CustomerInfo.Where(m => m.Id == customerId).FirstOrDefault();
            recording.Lock = Lock;

            recording.UserStatusID = status;
            recording.SchoolId = schoolInfo;
            recording.CustomerId = customerInfo;

            try
            {
                unit.Recording.Insert(recording);
                unit.Save();
                return View("RecordingAddData");
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
        /// <summary>
        /// 客户数据
        /// </summary>
        /// <param name="locks"></param>
        /// <returns></returns>
        public ActionResult RecordCustomer(string locks)
        {
            var lockes = Convert.ToInt16(locks);
            var Customer = unit.CustomerInfo.Where(m => m.Lock == lockes).ToList();
            var Customerlist = from culist in Customer
                               select new
                             {
                                   culist.Id,
                                   culist.CusName
                             };
            return Json(Customerlist, JsonRequestBehavior.AllowGet);
        }
    }
}