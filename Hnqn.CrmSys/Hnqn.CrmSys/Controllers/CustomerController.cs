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
using NPOI.SS.UserModel;

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
            return RedirectToAction("CustomerEditPage", "Customer");
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
            //var soucreSelected = Request.Params["soucreSelected"] == "" ? null : Request.Params["soucreSelected"];
            //var statusSelected = Request.Params["statusSelected"] == "" ? null : Request.Params["statusSelected"];
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
                                   where (cus.CusName.Contains(cusName))
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
                if (AccountId != null && ProfessionaId != null && UserStatusID != null && SourceID != null && SchoolId != null)
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
                    return Json(new { suses = true });
                }
                return Json(new { suses = false });
            }
            catch (Exception ex)
            {
                return RedirectToAction("CustomerAddPage", "Customer");
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
                if (AccountId != null && ProfessionaId != null && UserStatusID != null && SourceID != null && SchoolId != null)
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
                    return Json(new { suses = true });
                }
                return Json(new { suses = false });
            }
            catch (Exception ex)
            {
                return RedirectToAction("CustomerEditPage", "Customer");
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
            return RedirectToAction("CustomerListPage", "Customer");
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
            DataTable MyDt = new DataTable();
            DataColumn dc = new DataColumn();
            dc = MyDt.Columns.Add("编号", typeof(string));
            dc = MyDt.Columns.Add("姓名", typeof(string));
            dc = MyDt.Columns.Add("年龄", typeof(string));
            dc = MyDt.Columns.Add("性别", typeof(string));
            dc = MyDt.Columns.Add("电话", typeof(string));
            dc = MyDt.Columns.Add("微信", typeof(string));
            dc = MyDt.Columns.Add("地址", typeof(string));
            dc = MyDt.Columns.Add("沟通记录", typeof(string));
            dc = MyDt.Columns.Add("沟通时间", typeof(string));
            dc = MyDt.Columns.Add("录入者", typeof(string));
            dc = MyDt.Columns.Add("来源", typeof(string));
            dc = MyDt.Columns.Add("跟进状态", typeof(string));
            dc = MyDt.Columns.Add("校区", typeof(string));
            dc = MyDt.Columns.Add("专业", typeof(string));
            var list = unit.CustomerInfo.Where(m => m.Lock == 1).ToList();
            var cList = from cus in list
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
                            AccountName = cus.AccountId.Account,
                            UserStatusName = cus.UserStatusID.UserStatusName,
                            cus.CounselingTime,
                            Source = cus.SourceID.Source,
                            SchoolName = cus.SchoolId.SchoolName,
                            ProName = cus.ProfessionaId.ProName
                        };
            try
            {
                foreach (var item in cList)
                {
                    DataRow dr = MyDt.NewRow();
                    dr["编号"] = item.Id.ToString();
                    dr["姓名"] = item.CusName.ToString();
                    dr["年龄"] = item.Age.ToString();
                    dr["性别"] = item.Gender.ToString();
                    dr["电话"] = item.Tel.ToString();
                    dr["微信"] = item.WeChat.ToString();
                    dr["地址"] = item.Address.ToString();
                    dr["录入者"] = item.AccountName.ToString();
                    dr["沟通记录"] = item.Record.ToString();
                    dr["沟通时间"] = item.CounselingTime.ToString();
                    dr["跟进状态"] = item.UserStatusName.ToString();
                    dr["来源"] = item.Source.ToString();
                    dr["校区"] = item.SchoolName.ToString();
                    dr["专业"] = item.ProName.ToString();
                    MyDt.Rows.Add(dr);
                }
                IWorkbook workbook = ExcelHelper.DataTableToExcel(MyDt);
                string path = Server.MapPath("/File/导出.xlsx");
                FileStream fs = new FileStream(path, FileMode.Create);
                workbook.Write(fs);
                return File(path, "application/ms-excel", "信息.xlsx");
            }
            catch (Exception ex)
            {
                return Json(new { suses = false });
                throw ex;
            }
        }
        #endregion 客户信息导出

        #region 客户信息导入
        public ActionResult CustomerUploading()
        {
            #region + 变量
            //文件大小（字节数）
            long fileSize = 0;
            //重命名的文件名称
            string tempName = "";
            //物理路径+重命名的文件名称
            string fileName = "";
            //文件扩展名
            string extname = "";
            //虚拟路径
            string virtualPath = "/Uploads/Advs/Carousels/";
            //上传固定路径
            string path = Server.MapPath(virtualPath);
            //上传文件夹名称
            string dir = "";
            //获取提交的文件
            var file = Request.Files[0];
            #endregion
            #region 服务器本地文件上传处理
            try
            {
                if (file != null && !string.IsNullOrEmpty(file.FileName))
                {
                    dir = DateTime.Now.ToString("yyyy-MM-dd");
                    if (!Directory.Exists(path + dir))
                    {
                        Directory.CreateDirectory(path + dir);
                    }
                    extname = file.FileName.Substring(file.FileName.LastIndexOf('.'), (file.FileName.Length - file.FileName.LastIndexOf('.')));
                    tempName = Guid.NewGuid().ToString().Substring(0, 6) + extname;
                    fileName = path + dir + @"\" + tempName;
                    fileSize += file.ContentLength;
                    using (FileStream fs = System.IO.File.Create(fileName))
                    {
                        file.InputStream.CopyTo(fs);
                        fs.Flush();
                        fs.Close();
                        DataTable table = ExcelHelper.ExcelToDataTable(fileName);
                        string aa = table.Rows.Count.ToString();
                        foreach (DataRow item in table.Rows)
                        {
                            CustomerInfo stu = new CustomerInfo();
                            stu.CusName = item[1].ToString();
                            string age = item[2].ToString();
                            stu.Age = int.Parse(age);
                            stu.Lock = 1;
                            stu.Gender = item[3].ToString();
                            stu.Tel = item[4].ToString();
                            stu.WeChat = item[5].ToString();
                            stu.Address = item[6].ToString();
                            stu.Record = item[7].ToString();
                            stu.CounselingTime = DateTime.Now;
                            string sourceStr = item[10].ToString();
                            string statusStr = item[11].ToString();
                            string userStr = item[9].ToString();
                            string proStr = item[13].ToString();
                            string schoolStr = item[12].ToString();
                            SourceInfo source = unit.SourceInfo.Where(m => m.Source == sourceStr).FirstOrDefault();
                            UserStatus status = unit.UserStatus.Where(m => m.UserStatusName == statusStr).FirstOrDefault();
                            UserInfo user = unit.UserInfo.Where(m => m.Account == userStr).FirstOrDefault();
                            Professiona pro = unit.Professiona.Where(m => m.ProName == proStr).FirstOrDefault();
                            SchoolInfo school = unit.SchoolInfo.Where(m => m.SchoolName == schoolStr).FirstOrDefault();
                            stu.AccountId = user;
                            stu.ProfessionaId = pro;
                            stu.UserStatusID = status;
                            stu.SourceID = source;
                            stu.SchoolId = school;
                            unit.CustomerInfo.Insert(stu);
                            unit.Save();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return Json(new { suses = false });
                throw ex;
            }
            return Json(new { suses = false });
            #endregion
        }
        #endregion 客户信息导入
    }
}