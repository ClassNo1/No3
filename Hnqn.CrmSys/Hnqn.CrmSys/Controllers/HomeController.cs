using Hnqn.CrmSys.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hnqn.CrmSys.Models;
using Hnqn.CrmSys.Common;

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
            return View();
        }
        public ActionResult Show()
        {
            return View();
        }
    }
}