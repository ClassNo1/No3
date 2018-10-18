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
            if (this.User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Login","SysAdmin");
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "SysAdmin");
        }
    }
}