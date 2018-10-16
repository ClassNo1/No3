using Hnqn.CrmSys.Common;
using Hnqn.CrmSys.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hnqn.CrmSys.Models;

namespace Hnqn.CrmSys.Controllers
{
    public class UserController : Controller
    {
        WorkUnit unit = new WorkUnit();
        CrmDbContext db = new CrmDbContext();
        private static string UserId;//用户Id
        // GET: User
        /// <summary>
        /// 用户管理页面
        /// </summary>
        /// <returns></returns>
        public ActionResult UserManagePage()
        {
            return View();
        }
        /// <summary>
        /// 用户密码修改页面
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult EditUserPwdPage(string Id)
        {
            UserId = Id;
            return View();
        }
        /// <summary>
        /// 修改用户密码
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public ActionResult EditPitchPwd(string wornPwd,string newPwd1,string newPwd2)
        {
            if (UserId != null)
            {
                int Id = Convert.ToInt32(UserId);
                string tempPwd = Md5.GetMd5(wornPwd);
                var user = unit.UserInfo.Where(m => m.LoginPwd == tempPwd && m.Id == Id).FirstOrDefault();
                if (newPwd1 == newPwd2 && user != null)
                {
                    string sql = $"update UserInfoes set LoginPwd = '{Md5.GetMd5(newPwd1)}' where Id = {Id}";
                    unit.UserInfo.ExecuteSql(sql);
                    unit.Save();
                    return Json(new { susser = true });
                }
            }
            return Json(new { susser = false });
        }
        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <param name="index"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public ActionResult UserList(int index, int limit)
        {
            var userName = Request.Params["cusName"] == "" ? null : Request.Params["cusName"];
            if (userName != null)
            {
                var count = unit.UserInfo.Where(m => m.Lock == 1 && m.Account.Contains(userName)).ToList().Count();
                var list = unit.UserInfo.GetPageEntitys(m => m.Lock == 1 && m.Account.Contains(userName), limit, index - 1).ToList();
                var userList = from cus in list
                                   join sco in db.UserType on
                                   cus.UserTypeId.Id equals sco.Id
                                   join sch in db.SchoolInfo on
                                   cus.SchoolId.Id equals sch.Id
                                   where (cus.Account.Contains(userName))
                                   select new
                                   {
                                       cus.Id,
                                       cus.Account,
                                       cus.Gender,
                                       cus.LoginCount,
                                       cus.LastLoginTime,
                                       cus.LoginPwd,
                                       cus.Name,
                                       cus.Status,
                                       cus.TelPhone,
                                       sco.UserTypeName,
                                       sch.SchoolName
                                   };
                return Json(new { code = 0, msg = "", tatol = count, data = userList }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var count = unit.UserInfo.Where(m => m.Lock == 1).ToList().Count();
                var list = unit.UserInfo.GetPageEntitys(m => m.Lock == 1, limit, index - 1).ToList();
                var userList = from cus in list
                                   join sco in db.UserType on
                                   cus.UserTypeId.Id equals sco.Id
                                   join sch in db.SchoolInfo on
                                   cus.SchoolId.Id equals sch.Id
                                   select new
                                   {
                                       cus.Id,
                                       cus.Account,
                                       cus.Gender,
                                       cus.LoginCount,
                                       cus.LastLoginTime,
                                       cus.LoginPwd,
                                       cus.Name,
                                       cus.Status,
                                       cus.TelPhone,
                                       sco.UserTypeName,
                                       sch.SchoolName
                                   };
                return Json(new { code = 0, msg = "", tatol = count, data = userList }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(UserInfo user)
        {
            return View();
        }


        [HttpGet]
        public ActionResult UpdateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UpdateUser(UserInfo user)
        {
            return View();
        }
    }
}