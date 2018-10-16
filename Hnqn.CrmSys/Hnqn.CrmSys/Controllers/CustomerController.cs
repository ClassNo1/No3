using Hnqn.CrmSys.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hnqn.CrmSys.Models;
using Hnqn.CrmSys.Common;
using System.IO;
using System.Data;

namespace Hnqn.CrmSys.Controllers
{
    public class CustomerController : Controller
    {

        WorkUnit unit = new WorkUnit();
        CrmDbContext db = new CrmDbContext();
        private static string CusId;
        // GET: Customer
        /// <summary>
        /// 客户管理页面
        /// </summary>
        /// <returns></returns>
        public ActionResult CustomerListPage()
        {
            //if (this.User.Identity.IsAuthenticated)
            //{
            //    return View();
            //}
            //return RedirectToAction("CustomerListPage", "Customer");
            return View();
        }
        /// <summary>
        /// 修改客户页面
        /// </summary>
        /// <returns></returns>
        public ActionResult CustomerEditPage(string Id)
        {
            CusId = Id;
            return View();
        }
        /// <summary>
        /// 添加客户页面
        /// </summary>
        /// <returns></returns>
        public ActionResult CustomerAddPage()
        {
            return View();
        }
        /// <summary>
        /// 获取当前编辑客户信息
        /// </summary>
        /// <param name="locks"></param>
        /// <returns></returns>
        public ActionResult GetCustomerInfo(string locks)
        {
            if (CusId != null)
            {
                int Id = Convert.ToInt32(CusId);
                var customer = unit.CustomerInfo.Where(m => m.Id == Id).ToList();
                var cusinfo = from cus in customer
                               select new
                               {
                                   cus.Id,
                                   cus.CusName,
                                   cus.Age,
                                   cus.Gender,
                                   cus.Tel,
                                   cus.WeChat,
                                   cus.Address,
                                   cus.Record,
                                   cus.CounselingTime
                               };
                return Json(cusinfo, JsonRequestBehavior.AllowGet);
            }
            return RedirectToRoute("CustomerEditPage", "Customer");
        }
        /// <summary>
        /// 获取所有客户
        /// </summary>
        /// <param name="index">第几页</param>
        /// <param name="limit">每页多少条数据</param>
        /// <returns></returns>
        public ActionResult CusomerList(int index, int limit)
        {
            var cusName = Request.Params["cusName"] == "" ? null : Request.Params["cusName"];
            if (cusName != null)
            {
                var count = unit.CustomerInfo.Where(m => m.Lock == 1 && m.CusName.Contains(cusName)).ToList().Count();
                var list = unit.CustomerInfo.GetPageEntitys(m => m.Lock == 1 && m.CusName.Contains(cusName), limit, index - 1).ToList();
                var customerList = from cus in list
                                   join sco in db.SourceInfo on
                                   cus.SourceID.Id equals sco.Id
                                   join us in db.UserStatus on
                                   cus.UserStatusID.Id equals us.Id
                                   join act in db.UserInfo on
                                   cus.AccountId.Id equals act.Id
                                   where (cus.CusName.Contains(cusName) || cus.Tel == cusName)
                                   select new
                                   {
                                       cus.Id,
                                       cus.CusName,
                                       cus.Age,
                                       cus.Gender,
                                       cus.Tel,
                                       cus.WeChat,
                                       cus.Address,
                                       cus.Record,
                                       us.UserStatusName,
                                       cus.CounselingTime,
                                       act.Account,
                                       sco.Source
                                   };
                return Json(new { code = 0, msg = "", tatol = count, data = customerList }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var count = unit.CustomerInfo.Where(m => m.Lock == 1).ToList().Count();
                var list = unit.CustomerInfo.GetPageEntitys(m => m.Lock == 1, limit, index - 1).ToList();
                var customerList = from cus in list
                                   join sco in db.SourceInfo on
                                   cus.SourceID.Id equals sco.Id
                                   join us in db.UserStatus on
                                   cus.UserStatusID.Id equals us.Id
                                   join act in db.UserInfo on
                                   cus.AccountId.Id equals act.Id
                                   select new
                                   {
                                       cus.Id,
                                       cus.CusName,
                                       cus.Age,
                                       cus.Gender,
                                       cus.Tel,
                                       cus.WeChat,
                                       cus.Address,
                                       cus.Record,
                                       us.UserStatusName,
                                       cus.CounselingTime,
                                       act.Account,
                                       sco.Source
                                   };
                return Json(new { code = 0, msg = "", tatol = count, data = customerList }, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// 添加客户
        /// </summary>
        /// <param name="customer">用户信息</param>
        /// <param name="ProfessionaId"></param>
        /// <param name="AccountId"></param>
        /// <param name="UserStatusID"></param>
        /// <param name="SourceID"></param>
        /// <param name="SchoolId"></param>
        /// <returns></returns>
        public ActionResult AddCustomer(CustomerInfo customer, string ProfessionaId, string AccountId, string UserStatusID, string SourceID, string SchoolId)
        {
            customer.Lock = 1;
            try
            {
                int actId = Convert.ToInt32(AccountId);
                int proId = Convert.ToInt32(ProfessionaId);
                int ustId = Convert.ToInt32(UserStatusID);
                int souId = Convert.ToInt32(SourceID);
                int schId = Convert.ToInt32(SchoolId);

                UserInfo user = unit.UserInfo.GetAll(m => m.Id == actId).FirstOrDefault();
                Professiona professiona = unit.Professiona.GetAll(m => m.Id == proId).FirstOrDefault();
                UserStatus status = unit.UserStatus.GetAll(m => m.Id == ustId).FirstOrDefault();
                SourceInfo source = unit.SourceInfo.GetAll(m => m.Id == souId).FirstOrDefault();
                SchoolInfo school = unit.SchoolInfo.GetAll(m => m.Id == schId).FirstOrDefault();

                customer.AccountId = user;
                customer.ProfessionaId = professiona;
                customer.UserStatusID = status;
                customer.SourceID = source;
                customer.SchoolId = school;

                unit.CustomerInfo.Insert(customer);
                unit.Save();
                return Json(new { susser = true });
            }
            catch (Exception ex)
            {
                return Json(new { susser = false });
                throw ex;
            }
        }
        /// <summary>
        /// 修改客户
        /// </summary>
        /// <param name="customer">修改信息</param>
        /// <param name="ProfessionaId"></param>
        /// <param name="AccountId"></param>
        /// <param name="UserStatusID"></param>
        /// <param name="SourceID"></param>
        /// <param name="SchoolId"></param>
        /// <returns></returns>
        public ActionResult EditCustomer(CustomerInfo customer, string ProfessionaId, string AccountId, string UserStatusID, string SourceID, string SchoolId)
        {
            customer.Id = Convert.ToInt32(CusId);
            customer.Lock = 1;
            try
            {
                int actId = Convert.ToInt32(AccountId);
                int proId = Convert.ToInt32(ProfessionaId);
                int ustId = Convert.ToInt32(UserStatusID);
                int souId = Convert.ToInt32(SourceID);
                int schId = Convert.ToInt32(SchoolId);

                UserInfo user = unit.UserInfo.GetAll(m => m.Id == actId).FirstOrDefault();
                Professiona professiona = unit.Professiona.GetAll(m => m.Id == proId).FirstOrDefault();
                UserStatus status = unit.UserStatus.GetAll(m => m.Id == ustId).FirstOrDefault();
                SourceInfo source = unit.SourceInfo.GetAll(m => m.Id == souId).FirstOrDefault();
                SchoolInfo school = unit.SchoolInfo.GetAll(m => m.Id == schId).FirstOrDefault();

                customer.AccountId = user;
                customer.ProfessionaId = professiona;
                customer.UserStatusID = status;
                customer.SourceID = source;
                customer.SchoolId = school;

                unit.CustomerInfo.Update(customer);
                unit.Save();
                return Json(new { susser = true });
            }
            catch (Exception ex)
            {
                return Json(new { susser = false });
                throw ex;
            }
        }

        /// <summary>
        /// 删除客户
        /// </summary>
        /// <param name="Id">客户ID</param>
        /// <returns></returns>
        public ActionResult DeleteCustomer(string Id)
        {
            int cusId = Convert.ToInt32(Id);
            string sql = $"update CustomerInfoes set Lock = 0 where Id = {cusId}";
            try
            {
                unit.CustomerInfo.ExecuteSql(sql);
                unit.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return RedirectToRoute("CustomerListPage", "Customer");
        }
        /// <summary>
        /// 获取来源
        /// </summary>
        /// <param name="locks">锁（表状态）</param>
        /// <returns></returns>
        public ActionResult GetAllSource(string locks)
        {
            var source = unit.SourceInfo.Where(m => m.Lock == 1).ToList();
            var sourceList = from sou in source
                             select new
                             {
                                 sou.Id,
                                 sou.Source
                             };
            return Json(sourceList, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取跟进状态
        /// </summary>
        /// <param name="locks"></param>
        /// <returns></returns>
        public ActionResult GetAllUserStatus(string locks)
        {
            var userStatus = unit.UserStatus.Where(m => m.Lock == 1).ToList();
            var userStatusList = from sou in userStatus
                                 select new
                                 {
                                     sou.Id,
                                     sou.UserStatusName
                                 };
            return Json(userStatusList, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取用户
        /// </summary>
        /// <param name="locks"></param>
        /// <returns></returns>
        public ActionResult GetAllAccount(string locks)
        {
            var user = unit.UserInfo.Where(m => m.Lock == 1).ToList();
            var userList = from sou in user
                           select new
                           {
                               sou.Id,
                               sou.Account
                           };
            return Json(userList, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取专业
        /// </summary>
        /// <param name="locks"></param>
        /// <returns></returns>
        public ActionResult GetAllProfessiona(string locks)
        {
            var pro = unit.Professiona.Where(m => m.Lock == 1).ToList();
            var proList = from sou in pro
                          select new
                          {
                              sou.Id,
                              sou.ProName
                          };
            return Json(proList, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 获取校区
        /// </summary>
        /// <param name="locks"></param>
        /// <returns></returns>
        public ActionResult GetAllSchool(string locks)
        {
            var school = unit.SchoolInfo.Where(m => m.Lock == 1).ToList();
            var schoolList = from sou in school
                             select new
                             {
                                 sou.Id,
                                 sou.SchoolName
                             };
            return Json(schoolList, JsonRequestBehavior.AllowGet);
        } 
        #region 客户信息导出
        public ActionResult CustomerDown()
        {
            var list = unit.CustomerInfo.Where(m => m.Lock == 1).ToList();
            DataTable table = null;
            foreach (var item in list)
            {
                table.Columns.Add(item.CusName);
            }
            MemoryStream ms = ExcelHelper.DataTableToExcel(table);

            //以什么格式响应
            Response.ContentType = "application/vnd.ms-excel";

            //告诉浏览器这不是预览是下载 下载的文件名为
            Response.AddHeader("Content-Disposition", "attachment;Filename=客户信息.xlsx");

            //将内存流以2进制字符写入http输出流
            Response.BinaryWrite(ms.ToArray());
            //响应结束
            Response.End();

            return RedirectToRoute("CustomerListPage", "Customer");
        }
        #endregion 客户信息导出
    }
}