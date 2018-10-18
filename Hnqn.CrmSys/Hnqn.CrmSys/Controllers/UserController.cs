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
        public ActionResult AddUser(UserInfo user,string SchoolId,string UserTypeId,string LoginPwd,string LoginPwd1)
        {
            user.Lock = 1;
            user.Status = true;
            try
            {
                int SchId = Convert.ToInt32(SchoolId);
                int TypeId = Convert.ToInt32(UserTypeId);

                SchoolInfo sch = unit.SchoolInfo.GetAll(m => m.Id == SchId).FirstOrDefault();
                UserType type = unit.UserType.GetAll(m => m.Id == TypeId).FirstOrDefault();

                user.SchoolId = sch;
                user.UserTypeId = type;
                user.LoginPwd = Md5.GetMd5(LoginPwd);

                if (LoginPwd == LoginPwd1 && user != null)
                {
                    unit.UserInfo.Insert(user);
                    unit.Save();
                }
                return Json(new { susser = true });
            }
            catch (Exception ex)
            {
                return Json(new { susser = false });
                throw ex;
            }                              
        }


        [HttpGet]
        public ActionResult UpdateUser(string Id)
        {
            UserId = Id;
            return View();
        }

        public ActionResult GetUser()
        {
            if (UserId != null)
            {
                int Id = Convert.ToInt32(UserId);
                var UserList = unit.UserInfo.Where(m => m.Id == Id).ToList();
                var user = from cus in UserList
                           join sco in db.UserType on
                           cus.UserTypeId.Id equals sco.Id
                           join sch in db.SchoolInfo on
                           cus.SchoolId.Id equals sch.Id
                           select new
                           {
                               cus.Id,
                               cus.Account,
                               cus.LoginPwd,
                               sch.SchoolName,
                               cus.Name,
                               cus.Gender,
                               cus.TelPhone,
                               cus.LoginCount,
                               cus.LastLoginTime,
                               sco.UserTypeName,
                               cus.Status
                           };
                return Json(user, JsonRequestBehavior.AllowGet);
            }
            return RedirectToRoute("UpdateUser", "User");
        }

        [HttpPost]
        public ActionResult UpdateUser(UserInfo user)
        {
            user.Id = Convert.ToInt32(UserId);
            user.Lock = 1;
            user.Status = true;
            string[] str = { "Account", "LoginPwd", "LoginCount" };
            try
            {
                unit.UserInfo.Update(user, str);
                unit.Save();
                return Json(new { susser =true});
            }
            catch (Exception ex)
            {
                return Json(new { susser = false });
                throw ex;
            }           
        }

        [HttpGet]
        public ActionResult GetAllUserType(string locks)
        {
            var user = unit.UserType.Where(m => m.Lock == 1).ToList();
            var userList = from sou in user
                           select new
                             {
                                 sou.Id,
                                 sou.UserTypeName
                             };
            return Json(userList, JsonRequestBehavior.AllowGet);
        }

    }
}