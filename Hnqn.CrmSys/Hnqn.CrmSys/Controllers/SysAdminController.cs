using Hnqn.CrmSys.Common;
using Hnqn.CrmSys.Dal;
using Hnqn.CrmSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Hnqn.CrmSys.Controllers
{
    public class SysAdminController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Login()
        {
            string Name = Request.Params["Name"];
            HttpCookie cookie = new HttpCookie(Name);
            cookie.Expires = DateTime.Now.AddHours(2);
            Response.Cookies.Add(cookie);
            return View();
        }
        WorkUnit unit = new WorkUnit();
        [HttpPost]
        public ActionResult Login(UserInfo model, string Code)
        {
            
            //比对数据
            bool LoginWay = new UserManage().Login(model);
            //判断验证码是否正确
            if (Code.ToLower() == Session["code"].ToString().ToLower())
            {
                //判断账号密码是否正确
                if (LoginWay)
                {
                    //改变登录次数与登录时间
                    var LoginPwd = Md5.GetMd5(model.LoginPwd);
                    var whereUser = unit.UserInfo.Where(m => m.Account == model.Account && m.LoginPwd == LoginPwd);
                    var user = from uc in whereUser
                               select new
                               {
                                   uc.Id,
                                   uc.LoginCount
                               };
                    int loginId = 0;
                    int loginCount = 0;
                    string LastLoginTime = DateTime.Now.ToString("G");
                    foreach (var item in user)
                    {
                        if (loginCount == 0)
                        {
                            loginCount = item.LoginCount + 1;
                            loginId = item.Id;
                        }
                    }
                    string sql = $"update UserInfoes set LoginCount = '{loginCount}',LastLoginTime = '{LastLoginTime}' where Id ={loginId}";
                    unit.UserInfo.ExecuteSql(sql);
                    unit.Save();
                    //给账号设置票证
                    FormsAuthentication.SetAuthCookie(model.Account.ToString(), false);
                    return Json(new { success = 1 });
                }
                else
                {
                    return Json(new { success = 2 });
                }
            }
            else 
            {
                return Json(new { success = 3 });
            }
            
        }
        public ActionResult GetCodeImg(double? id)
        {
            string code = new ValidataCode().GetCode(4);
            Session["code"] = code;
            Session.Timeout = 10;
            byte[] img = new ValidataCode().CreateValidateGraphic(code);
            return File(img, @"img/jpeg");
        }     
    }
}