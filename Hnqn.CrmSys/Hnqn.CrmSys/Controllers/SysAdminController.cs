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
            

            bool LoginWay = new UserManage().Login(model);
            if (Code.ToLower() == Session["code"].ToString().ToLower())
            {
                if (LoginWay)
                {
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