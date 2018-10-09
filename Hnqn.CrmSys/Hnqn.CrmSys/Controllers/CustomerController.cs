using Hnqn.CrmSys.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hnqn.CrmSys.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult CustomerListPage()
        {
            WorkUnit unit = new WorkUnit();
            var customer = unit.CustomerInfo.Where(m => m.Lock == 1).ToList();
            var customerList = from cus in customer

                          select new
                          {
                              cus.Id,
                              cus.CusName,
                              cus.Age,
                              cus.Gender,
                              cus.Tel,
                              cus.WeChat,
                              cus.Address,
                              //cus.SchoolId,
                              cus.Record,
                              //cus.UserStatusID,
                              cus.CounselingTime,
                              //cus.AccountId,
                              //cus.ProfessionaId,
                              //cus.SourceID
                          };
            return Json(new { code = 0, msg = "", count = customerList.Count(), data = customerList.ToList() }, JsonRequestBehavior.AllowGet);
        }
    }
}