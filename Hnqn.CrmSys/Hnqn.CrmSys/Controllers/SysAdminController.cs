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
        
        [HttpPost]
        public ActionResult Login(UserInfo model, string Code)
        {
            
            UserInfo userInfo = new UserInfo()
            {
                Account = model.Account,
                LoginPwd = model.LoginPwd
            };
            bool isLogin = new UserManage().Login(userInfo);
            Code = Session["code"].ToString();

            if (isLogin)
            {
                FormsAuthentication.SetAuthCookie(userInfo.Account.ToString(), false);
                
                return Redirect("/Home/Index");
             }
            else if (!(Session["code"].ToString().ToLower()==Code.ToLower()))
            {
                return Content("验证码错误");
            }
            return View("/SysAdmin/Login");
            
        }
        public ActionResult GetCodeImg(double? id)
        {
            string code = new ValidataCode().GetCode(4);
            Session["code"] = code;
            byte[] img = new ValidataCode().CreateValidateGraphic(code);
            return File(img, @"img/jpeg");
        }     
    }
}