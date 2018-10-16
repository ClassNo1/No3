using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hnqn.CrmSys.Models;
using Hnqn.CrmSys.Common;
using Hnqn.CrmSys.Dal;

namespace Hnqn.CrmSys.Controllers
{
    public class SchoolController : Controller
    {
        CrmDbContext crm = new CrmDbContext();
        WorkUnit work = new WorkUnit();

        private static string SchoolId;
       
        // GET: School
        //校区列表页面
        public ActionResult Index()
        {          
            return View();
        }
        
       //按学校名称查找数据
        public ActionResult GetSchoolList(int index, int limit)
        {
            var schoolName = Request.Params["SchoolName"]==""?null:Request.Params["SchoolName"];

            if (schoolName==null)
            {
                var count = work.SchoolInfo.Where(m => m.Lock == 1).ToList().Count();
                var list1 = work.SchoolInfo.GetPageEntitys(m => m.Lock == 1, limit, index - 1).ToList();
                var SchList = crm.SchoolInfo.Where(m => m.Lock == 1).ToList();
                var list = from sch in SchList
                           select new
                           {
                               sch.Id,
                               sch.SchoolTypeName,
                               sch.SchoolName,
                               sch.Head,
                               sch.Tel1,
                               sch.Tel2,
                               sch.SchoolAddress,
                               sch.AddTime
                           };
                return Json(new { code = 0, msg = "", /*数据总数目*/count = list.Count(), data = list1 }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var count = work.SchoolInfo.Where(m => m.Lock == 1 && m.SchoolName.Contains(schoolName)).ToList().Count();
                var list1 = work.SchoolInfo.GetPageEntitys(m => m.Lock == 1 && m.SchoolName.Contains(schoolName), limit, index - 1).ToList();
                var SchList = work.SchoolInfo.Where(m => m.Lock == 1&&m.SchoolName==schoolName).ToList();
                var list = from sch in SchList
                           select new
                           {
                               sch.Id,
                               sch.SchoolTypeName,
                               sch.SchoolName,
                               sch.Head,
                               sch.Tel1,
                               sch.Tel2,
                               sch.SchoolAddress,
                               sch.AddTime
                           };
                return Json(new { code = 0, msg = "", count = list.Count(), data = list1 }, JsonRequestBehavior.AllowGet);
            }
           
        }
        
        //添加校区弹出页面
        [HttpGet]
        public ActionResult AddSchool()
        {         
            return View();
        }
        //添加校区方法
        [HttpPost]
        public ActionResult AddSchool(SchoolInfo school)
        {   //添加校区信息
            school.Lock = 1;
            school.AddTime = DateTime.Now;
            work.SchoolInfo.Insert(school);
            //保存到数据库
            work.Save();
            return RedirectToRoute("AddSchool","School");
        }

        //修改校区弹出页面
        [HttpGet]
        public ActionResult UpdateSchool(string Id)
        {
            SchoolId = Id;
            return View();
        }
        public ActionResult GetSchool()
        {
            if (SchoolId != null)
            {
                int Id = Convert.ToInt32(SchoolId);
                var SchList = work.SchoolInfo.Where(m => m.Id == Id).ToList();
                var list = from sch in SchList
                           select new
                           {
                               sch.Id,
                               sch.SchoolTypeName,
                               sch.SchoolName,
                               sch.Head,
                               sch.Tel1,
                               sch.Tel2,
                               sch.SchoolAddress,
                               sch.Status
                           };
                return Json(list, JsonRequestBehavior.AllowGet);
            }

            return RedirectToRoute("UpdateSchool", "School");
        }
        [HttpPost]
        public ActionResult UpdateSchool(SchoolInfo school)
        {   //修改校区信息
                school.Id = Convert.ToInt32(SchoolId);
                school.Lock = 1;
                string[] str = { "AddTime" };
                work.SchoolInfo.Update(school ,str);
                //保存到数据库
                work.Save();                          
            return RedirectToRoute("UpdateSchool", "School");
        }

        //通过ID（删除）改变数据状态
        public ActionResult Delete(string Id)
        {   
            int SchoolId = Convert.ToInt16(Id);
            string sql = $"update SchoolInfoes set Lock=0 where Id={SchoolId}";
            work.SchoolInfo.ExecuteSql(sql);
            work.Save();
            return RedirectToRoute("Index", "School");
        }

        
    }
}