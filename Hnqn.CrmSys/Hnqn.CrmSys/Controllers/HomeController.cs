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
            CrmDbContext db = new CrmDbContext();
            //db.Database.CreateIfNotExists();
            WorkUnit unit = new WorkUnit();


            ////客户状态模拟数据插入
            //List<UserStatus> userStatuslist = new List<UserStatus>
            //{
            //    new UserStatus{UserStatusName = "已缴费",Lock = 1},
            //    new UserStatus{UserStatusName = "考虑中",Lock = 1},
            //    new UserStatus{UserStatusName = "未缴费",Lock = 1},
            //};
            //db.UserStatus.AddRange(userStatuslist);
            //db.SaveChanges();

            ////来源状态模拟数据插入
            //List<SourceInfo> sourcelist = new List<SourceInfo>
            //{
            //    new SourceInfo{Source = "传单",Lock = 1},
            //    new SourceInfo{Source = "电话",Lock = 1},
            //    new SourceInfo{Source = "转介绍",Lock = 1},
            //    new SourceInfo{Source = "互联网",Lock = 1},
            //    new SourceInfo{Source = "广告",Lock = 1},
            //};
            //db.SourceInfo.AddRange(sourcelist);
            //db.SaveChanges();

            ////专业表模拟数据插入
            //List<Professiona> professionalist = new List<Professiona>
            //{
            //    new Professiona{ProName = "哲学",SchoolId = db.SchoolInfo.Find(1),Lock = 1},
            //    new Professiona{ProName = "经济学",SchoolId = db.SchoolInfo.Find(1),Lock = 1},
            //    new Professiona{ProName = "法学",SchoolId = db.SchoolInfo.Find(1),Lock = 1},
            //    new Professiona{ProName = "教育学",SchoolId = db.SchoolInfo.Find(1),Lock = 1},
            //    new Professiona{ProName = "文学",SchoolId = db.SchoolInfo.Find(1),Lock = 1},
            //    new Professiona{ProName = "历史学",SchoolId = db.SchoolInfo.Find(1),Lock = 1},
            //    new Professiona{ProName = "工学",SchoolId = db.SchoolInfo.Find(1),Lock = 1},
            //    new Professiona{ProName = "农学",SchoolId = db.SchoolInfo.Find(1),Lock = 1},
            //    new Professiona{ProName = "医学",SchoolId = db.SchoolInfo.Find(1),Lock = 1},
            //    new Professiona{ProName = "军事学",SchoolId = db.SchoolInfo.Find(1),Lock = 1},
            //    new Professiona{ProName = "计算机科学与技术",SchoolId = db.SchoolInfo.Find(1),Lock = 1},
            //    new Professiona{ProName = "哲学",SchoolId = db.SchoolInfo.Find(2),Lock = 1},
            //    new Professiona{ProName = "经济学",SchoolId = db.SchoolInfo.Find(2),Lock = 1},
            //    new Professiona{ProName = "法学",SchoolId = db.SchoolInfo.Find(2),Lock = 1},
            //    new Professiona{ProName = "教育学",SchoolId = db.SchoolInfo.Find(2),Lock = 1},
            //    new Professiona{ProName = "文学",SchoolId = db.SchoolInfo.Find(2),Lock = 1},
            //    new Professiona{ProName = "历史学",SchoolId = db.SchoolInfo.Find(2),Lock = 1},
            //    new Professiona{ProName = "工学",SchoolId = db.SchoolInfo.Find(2),Lock = 1},
            //    new Professiona{ProName = "农学",SchoolId = db.SchoolInfo.Find(2),Lock = 1},
            //    new Professiona{ProName = "医学",SchoolId = db.SchoolInfo.Find(2),Lock = 1},
            //    new Professiona{ProName = "军事学",SchoolId = db.SchoolInfo.Find(2),Lock = 1},
            //    new Professiona{ProName = "计算机科学与技术",SchoolId = db.SchoolInfo.Find(2),Lock = 1},
            //    new Professiona{ProName = "哲学",SchoolId = db.SchoolInfo.Find(3),Lock = 1},
            //    new Professiona{ProName = "经济学",SchoolId = db.SchoolInfo.Find(3),Lock = 1},
            //    new Professiona{ProName = "法学",SchoolId = db.SchoolInfo.Find(3),Lock = 1},
            //    new Professiona{ProName = "教育学",SchoolId = db.SchoolInfo.Find(3),Lock = 1},
            //    new Professiona{ProName = "文学",SchoolId = db.SchoolInfo.Find(3),Lock = 1},
            //    new Professiona{ProName = "历史学",SchoolId = db.SchoolInfo.Find(3),Lock = 1},
            //    new Professiona{ProName = "工学",SchoolId = db.SchoolInfo.Find(3),Lock = 1},
            //    new Professiona{ProName = "农学",SchoolId = db.SchoolInfo.Find(3),Lock = 1},
            //    new Professiona{ProName = "医学",SchoolId = db.SchoolInfo.Find(3),Lock = 1},
            //    new Professiona{ProName = "军事学",SchoolId = db.SchoolInfo.Find(3),Lock = 1},
            //    new Professiona{ProName = "计算机科学与技术",SchoolId = db.SchoolInfo.Find(3),Lock = 1},
            //};
            //db.Professiona.AddRange(professionalist);
            //db.SaveChanges();


            ////客户状态模拟数据插入
            //List<CustomerInfo> customerlist = new List<CustomerInfo>
            //{
            //    new CustomerInfo{CusName = "张三",Age = 20,Gender = "男",Tel = "18273331445",WeChat = "18273331445",Address = "衡山科学城",SourceID = db.SourceInfo.Find(1),Record = "有",UserStatusID = db.UserStatus.Find(1),CounselingTime = Convert.ToDateTime("2018-08-13"),AccountId = db.UserInfo.Find(1),ProfessionaId = db.Professiona.Find(1),SchoolId = db.SchoolInfo.Find(1),Lock = 1},
            //    new CustomerInfo{CusName = "海昌",Age = 20,Gender = "男",Tel = "18273431445",WeChat = "18273331445",Address = "衡山科学城",SourceID = db.SourceInfo.Find(2),Record = "有",UserStatusID = db.UserStatus.Find(2),CounselingTime = Convert.ToDateTime("2018-08-13"),AccountId = db.UserInfo.Find(2),ProfessionaId = db.Professiona.Find(2),SchoolId = db.SchoolInfo.Find(2),Lock = 1},
            //    new CustomerInfo{CusName = "辰钊",Age = 20,Gender = "男",Tel = "18275431445",WeChat = "18273331445",Address = "衡山科学城",SourceID = db.SourceInfo.Find(3),Record = "有",UserStatusID = db.UserStatus.Find(3),CounselingTime = Convert.ToDateTime("2018-08-13"),AccountId = db.UserInfo.Find(3),ProfessionaId = db.Professiona.Find(3),SchoolId = db.SchoolInfo.Find(3),Lock = 1},
            //    new CustomerInfo{CusName = "运凯",Age = 20,Gender = "男",Tel = "18274531445",WeChat = "18273331445",Address = "衡山科学城",SourceID = db.SourceInfo.Find(2),Record = "有",UserStatusID = db.UserStatus.Find(1),CounselingTime = Convert.ToDateTime("2018-08-13"),AccountId = db.UserInfo.Find(4),ProfessionaId = db.Professiona.Find(4),SchoolId = db.SchoolInfo.Find(1),Lock = 1},
            //    new CustomerInfo{CusName = "昂熙",Age = 20,Gender = "男",Tel = "18275651445",WeChat = "18273331445",Address = "衡山科学城",SourceID = db.SourceInfo.Find(3),Record = "有",UserStatusID = db.UserStatus.Find(2),CounselingTime = Convert.ToDateTime("2018-08-13"),AccountId = db.UserInfo.Find(5),ProfessionaId = db.Professiona.Find(5),SchoolId = db.SchoolInfo.Find(2),Lock = 1},
            //    new CustomerInfo{CusName = "宣朗",Age = 20,Gender = "男",Tel = "18277651445",WeChat = "18273331445",Address = "衡山科学城",SourceID = db.SourceInfo.Find(1),Record = "有",UserStatusID = db.UserStatus.Find(3),CounselingTime = Convert.ToDateTime("2018-01-13"),AccountId = db.UserInfo.Find(6),ProfessionaId = db.Professiona.Find(6),SchoolId = db.SchoolInfo.Find(3),Lock = 1},
            //    new CustomerInfo{CusName = "学智",Age = 20,Gender = "男",Tel = "18274651445",WeChat = "18273331445",Address = "衡山科学城",SourceID = db.SourceInfo.Find(3),Record = "有",UserStatusID = db.UserStatus.Find(2),CounselingTime = Convert.ToDateTime("2018-01-13"),AccountId = db.UserInfo.Find(2),ProfessionaId = db.Professiona.Find(7),SchoolId = db.SchoolInfo.Find(3),Lock = 1},
            //    new CustomerInfo{CusName = "昊磊",Age = 20,Gender = "男",Tel = "18278761445",WeChat = "18273331445",Address = "衡山科学城",SourceID = db.SourceInfo.Find(5),Record = "有",UserStatusID = db.UserStatus.Find(3),CounselingTime = Convert.ToDateTime("2018-02-13"),AccountId = db.UserInfo.Find(3),ProfessionaId = db.Professiona.Find(8),SchoolId = db.SchoolInfo.Find(2),Lock = 1},
            //    new CustomerInfo{CusName = "运恒",Age = 20,Gender = "男",Tel = "18279781445",WeChat = "18273331445",Address = "衡山科学城",SourceID = db.SourceInfo.Find(2),Record = "有",UserStatusID = db.UserStatus.Find(1),CounselingTime = Convert.ToDateTime("2018-02-13"),AccountId = db.UserInfo.Find(4),ProfessionaId = db.Professiona.Find(9),SchoolId = db.SchoolInfo.Find(1),Lock = 1},
            //    new CustomerInfo{CusName = "昂然",Age = 20,Gender = "男",Tel = "18276871445",WeChat = "18273331445",Address = "衡山科学城",SourceID = db.SourceInfo.Find(4),Record = "有",UserStatusID = db.UserStatus.Find(2),CounselingTime = Convert.ToDateTime("2018-01-13"),AccountId = db.UserInfo.Find(5),ProfessionaId = db.Professiona.Find(10),SchoolId = db.SchoolInfo.Find(1),Lock = 1},
            //    new CustomerInfo{CusName = "鸿朗",Age = 20,Gender = "男",Tel = "18277861445",WeChat = "18273331445",Address = "衡山科学城",SourceID = db.SourceInfo.Find(1),Record = "有",UserStatusID = db.UserStatus.Find(3),CounselingTime = Convert.ToDateTime("2018-01-13"),AccountId = db.UserInfo.Find(6),ProfessionaId = db.Professiona.Find(11),SchoolId = db.SchoolInfo.Find(2),Lock = 1},
            //    new CustomerInfo{CusName = "张鹏煊",Age = 20,Gender = "男",Tel = "18274661445",WeChat = "18274661445",Address = "衡山科学城",SourceID = db.SourceInfo.Find(5),Record = "无",UserStatusID = db.UserStatus.Find(1),CounselingTime = Convert.ToDateTime("2018-01-13"),AccountId = db.UserInfo.Find(2),ProfessionaId = db.Professiona.Find(2),SchoolId = db.SchoolInfo.Find(3),Lock = 1},
            //    new CustomerInfo{CusName = "张曜坤",Age = 20,Gender = "男",Tel = "18276541445",WeChat = "18276541445",Address = "衡山科学城",SourceID = db.SourceInfo.Find(3),Record = "有",UserStatusID = db.UserStatus.Find(1),CounselingTime = Convert.ToDateTime("2018-06-13"),AccountId = db.UserInfo.Find(3),ProfessionaId = db.Professiona.Find(3),SchoolId = db.SchoolInfo.Find(3),Lock = 1},
            //    new CustomerInfo{CusName = "张智阳",Age = 20,Gender = "男",Tel = "18278861445",WeChat = "18278861445",Address = "衡山科学城",SourceID = db.SourceInfo.Find(4),Record = "有",UserStatusID = db.UserStatus.Find(2),CounselingTime = Convert.ToDateTime("2018-08-13"),AccountId = db.UserInfo.Find(4),ProfessionaId = db.Professiona.Find(4),SchoolId = db.SchoolInfo.Find(2),Lock = 1},
            //    new CustomerInfo{CusName = "张学智",Age = 20,Gender = "男",Tel = "18275551445",WeChat = "18273331445",Address = "衡山科学城",SourceID = db.SourceInfo.Find(1),Record = "有",UserStatusID = db.UserStatus.Find(1),CounselingTime = Convert.ToDateTime("2018-04-13"),AccountId = db.UserInfo.Find(5),ProfessionaId = db.Professiona.Find(5),SchoolId = db.SchoolInfo.Find(1),Lock = 1},
            //    new CustomerInfo{CusName = "张瀚玥",Age = 20,Gender = "男",Tel = "18277821445",WeChat = "18277821445",Address = "衡山科学城",SourceID = db.SourceInfo.Find(3),Record = "有",UserStatusID = db.UserStatus.Find(2),CounselingTime = Convert.ToDateTime("2018-08-13"),AccountId = db.UserInfo.Find(6),ProfessionaId = db.Professiona.Find(6),SchoolId = db.SchoolInfo.Find(2),Lock = 1},
            //    new CustomerInfo{CusName = "张文景",Age = 20,Gender = "女",Tel = "18271571445",WeChat = "18273331445",Address = "湖南工学院",SourceID = db.SourceInfo.Find(2),Record = "有",UserStatusID = db.UserStatus.Find(1),CounselingTime = Convert.ToDateTime("2018-03-13"),AccountId = db.UserInfo.Find(7),ProfessionaId = db.Professiona.Find(7),SchoolId = db.SchoolInfo.Find(3),Lock = 1},
            //    new CustomerInfo{CusName = "张子昂",Age = 20,Gender = "女",Tel = "18275631445",WeChat = "18273331445",Address = "衡山科学城",SourceID = db.SourceInfo.Find(4),Record = "有",UserStatusID = db.UserStatus.Find(2),CounselingTime = Convert.ToDateTime("2018-02-13"),AccountId = db.UserInfo.Find(8),ProfessionaId = db.Professiona.Find(8),SchoolId = db.SchoolInfo.Find(3),Lock = 1},
            //    new CustomerInfo{CusName = "张幻莲",Age = 20,Gender = "女",Tel = "18274271445",WeChat = "18273331445",Address = "湖南工学院",SourceID = db.SourceInfo.Find(3),Record = "有",UserStatusID = db.UserStatus.Find(1),CounselingTime = Convert.ToDateTime("2018-07-13"),AccountId = db.UserInfo.Find(2),ProfessionaId = db.Professiona.Find(9),SchoolId = db.SchoolInfo.Find(2),Lock = 1},
            //    new CustomerInfo{CusName = "张丹蝶",Age = 20,Gender = "女",Tel = "18275321445",WeChat = "18273331445",Address = "湖南工学院",SourceID = db.SourceInfo.Find(5),Record = "有",UserStatusID = db.UserStatus.Find(1),CounselingTime = Convert.ToDateTime("2018-06-13"),AccountId = db.UserInfo.Find(8),ProfessionaId = db.Professiona.Find(10),SchoolId = db.SchoolInfo.Find(2),Lock = 1},
            //    new CustomerInfo{CusName = "张元瑶",Age = 20,Gender = "女",Tel = "18272301445",WeChat = "18273331445",Address = "湖南工学院",SourceID = db.SourceInfo.Find(4),Record = "有",UserStatusID = db.UserStatus.Find(2),CounselingTime = Convert.ToDateTime("2018-05-13"),AccountId = db.UserInfo.Find(9),ProfessionaId = db.Professiona.Find(2),SchoolId = db.SchoolInfo.Find(3),Lock = 1},
            //    new CustomerInfo{CusName = "张若翠",Age = 20,Gender = "女",Tel = "18272301445",WeChat = "18273331445",Address = "湖南工学院",SourceID = db.SourceInfo.Find(5),Record = "无",UserStatusID = db.UserStatus.Find(1),CounselingTime = Convert.ToDateTime("2018-05-13"),AccountId = db.UserInfo.Find(2),ProfessionaId = db.Professiona.Find(3),SchoolId = db.SchoolInfo.Find(2),Lock = 1},
            //    new CustomerInfo{CusName = "张晓山",Age = 20,Gender = "女",Tel = "18272351445",WeChat = "18273331445",Address = "湖南工学院",SourceID = db.SourceInfo.Find(2),Record = "无",UserStatusID = db.UserStatus.Find(1),CounselingTime = Convert.ToDateTime("2018-02-13"),AccountId = db.UserInfo.Find(3),ProfessionaId = db.Professiona.Find(4),SchoolId = db.SchoolInfo.Find(2),Lock = 1},
            //    new CustomerInfo{CusName = "张映雁",Age = 20,Gender = "女",Tel = "18274211445",WeChat = "18273331445",Address = "湖南工学院",SourceID = db.SourceInfo.Find(5),Record = "无",UserStatusID = db.UserStatus.Find(3),CounselingTime = Convert.ToDateTime("2018-04-13"),AccountId = db.UserInfo.Find(4),ProfessionaId = db.Professiona.Find(2),SchoolId = db.SchoolInfo.Find(2),Lock = 1},
            //    new CustomerInfo{CusName = "张白萱",Age = 20,Gender = "女",Tel = "18275431445",WeChat = "18273331445",Address = "湖南工学院",SourceID = db.SourceInfo.Find(2),Record = "无",UserStatusID = db.UserStatus.Find(3),CounselingTime = Convert.ToDateTime("2018-03-13"),AccountId = db.UserInfo.Find(5),ProfessionaId = db.Professiona.Find(3),SchoolId = db.SchoolInfo.Find(2),Lock = 1},
            //    new CustomerInfo{CusName = "张青旋",Age = 20,Gender = "女",Tel = "18274321445",WeChat = "18273331445",Address = "湖南工学院",SourceID = db.SourceInfo.Find(3),Record = "无",UserStatusID = db.UserStatus.Find(3),CounselingTime = Convert.ToDateTime("2018-02-13"),AccountId = db.UserInfo.Find(6),ProfessionaId = db.Professiona.Find(5),SchoolId = db.SchoolInfo.Find(2),Lock = 1},
            //    new CustomerInfo{CusName = "张易文",Age = 20,Gender = "女",Tel = "18273231445",WeChat = "18273331445",Address = "湖南工学院",SourceID = db.SourceInfo.Find(2),Record = "无",UserStatusID = db.UserStatus.Find(3),CounselingTime = Convert.ToDateTime("2018-07-13"),AccountId = db.UserInfo.Find(5),ProfessionaId = db.Professiona.Find(6),SchoolId = db.SchoolInfo.Find(2),Lock = 1},
            //    new CustomerInfo{CusName = "张碧菡",Age = 20,Gender = "女",Tel = "18273831445",WeChat = "18273331445",Address = "湖南工学院",SourceID = db.SourceInfo.Find(3),Record = "无",UserStatusID = db.UserStatus.Find(3),CounselingTime = Convert.ToDateTime("2018-06-13"),AccountId = db.UserInfo.Find(1),ProfessionaId = db.Professiona.Find(7),SchoolId = db.SchoolInfo.Find(3),Lock = 1},
            //    new CustomerInfo{CusName = "张初晴",Age = 20,Gender = "女",Tel = "18279331445",WeChat = "18273331445",Address = "湖南工学院",SourceID = db.SourceInfo.Find(4),Record = "无",UserStatusID = db.UserStatus.Find(3),CounselingTime = Convert.ToDateTime("2018-05-13"),AccountId = db.UserInfo.Find(1),ProfessionaId = db.Professiona.Find(8),SchoolId = db.SchoolInfo.Find(1),Lock = 1},
            //    new CustomerInfo{CusName = "张惜芹",Age = 20,Gender = "女",Tel = "18273731445",WeChat = "18273331445",Address = "湖南工学院",SourceID = db.SourceInfo.Find(5),Record = "无",UserStatusID = db.UserStatus.Find(3),CounselingTime = Convert.ToDateTime("2018-04-13"),AccountId = db.UserInfo.Find(1),ProfessionaId = db.Professiona.Find(1),SchoolId = db.SchoolInfo.Find(1),Lock = 1},
            //    new CustomerInfo{CusName = "张芷梦",Age = 20,Gender = "女",Tel = "18273631445",WeChat = "18273331445",Address = "湖南工学院",SourceID = db.SourceInfo.Find(1),Record = "无",UserStatusID = db.UserStatus.Find(1),CounselingTime = Convert.ToDateTime("2018-03-13"),AccountId = db.UserInfo.Find(1),ProfessionaId = db.Professiona.Find(2),SchoolId = db.SchoolInfo.Find(1),Lock = 1},
            //    new CustomerInfo{CusName = "张梦竹",Age = 20,Gender = "女",Tel = "18273131445",WeChat = "18273331445",Address = "湖南工学院",SourceID = db.SourceInfo.Find(1),Record = "无",UserStatusID = db.UserStatus.Find(1),CounselingTime = Convert.ToDateTime("2018-02-13"),AccountId = db.UserInfo.Find(1),ProfessionaId = db.Professiona.Find(1),SchoolId = db.SchoolInfo.Find(3),Lock = 1},
            //};
            //db.CustomerInfo.AddRange(customerlist);
            //db.SaveChanges();

            ////插入校区表数据/////////////////////////////////////////
            //List<SchoolInfo> schools = new List<SchoolInfo>()
            //{
            //    new SchoolInfo()
            //{
            //    SchoolTypeName="直营",
            //    SchoolName="师范大学",
            //    Head="张学良",
            //    Tel1="13611564788",
            //    Tel2="8835266",
            //    SchoolAddress="衡阳市蒸水路22号",
            //    Status=true,
            //    AddTime=DateTime.Now,
            //    Lock=1
            //},
            //     new SchoolInfo()
            //{
            //    SchoolTypeName="加盟",
            //    SchoolName="金华大学",
            //    Head="林彪",
            //    Tel1="13822264765",
            //    Tel2="8822355",
            //    SchoolAddress="衡阳市衡州大道232号",
            //    Status=true,
            //    AddTime=DateTime.Now,
            //    Lock=1
            //},
            //      new SchoolInfo()
            //{
            //    SchoolTypeName="直营",
            //    SchoolName="南华大学",
            //    Head="张飞",
            //    Tel1="13511288222",
            //    Tel2="8866234",
            //    SchoolAddress="衡阳市泰康大道22号",
            //    Status=true,
            //    AddTime=DateTime.Now,
            //    Lock=1
            //}
            //};

            //db.SchoolInfo.AddRange(schools);
            //db.SaveChanges();
            //沟通记录表插入数据////////////////////////////////////////////////////
            List<Recording> recordings = new List<Recording>()
            {
                new Recording(){
                    CustomerId=db.CustomerInfo.Find(1),
                    Method="电话沟通",
                    UserStatusID=db.UserStatus.Find(1),
                    Degree="高",
                    Context="大一新生,计算机专业,已缴费",
                    Result="成功",
                    RecTime=Convert.ToDateTime("2018-08-09"),
                    SchoolId=db.SchoolInfo.Find(1),
                    Lock=1
                },
                new Recording(){
                    CustomerId=db.CustomerInfo.Find(2),
                    Method="当面沟通",
                    UserStatusID=db.UserStatus.Find(2),
                    Degree="中",
                    Context="大二老生,未缴费",
                    Result="成功",
                    RecTime=Convert.ToDateTime("2018-08-11"),
                    SchoolId=db.SchoolInfo.Find(3),
                    Lock=1
                },
                new Recording(){
                    CustomerId=db.CustomerInfo.Find(3),
                    Method="当面沟通",
                    UserStatusID=db.UserStatus.Find(3),
                    Degree="低",
                    Context="计算机专业,未缴费",
                    Result="失败",
                    RecTime=Convert.ToDateTime("2018-08-15"),
                    SchoolId=db.SchoolInfo.Find(2),
                    Lock=1
                }
            };

            db.Recording.AddRange(recordings);
            db.SaveChanges();

            ////添加用户类型模拟数据
            //List<UserType> usertype = new List<UserType>
            //{
            //    new UserType{UserTypeName="教师",Lock=1},
            //    new UserType{UserTypeName="主任",Lock=1},
            //    new UserType{UserTypeName="校长",Lock=1}
            //};
            //db.UserType.AddRange(usertype);
            //db.SaveChanges();
            ////添加用户模拟数据
            //List<UserInfo> user = new List<UserInfo>
            //{
            //    new UserInfo{Account="张小三",LoginPwd=Md5.GetMd5("123456"),UserTypeId=db.UserType.Find(1),Name="张刚军",Gender="男",TelPhone="13256459654",LoginCount=1,LastLoginTime=DateTime.Now,SchoolId=db.SchoolInfo.Find(1),Status=true,Lock=1},
            //    new UserInfo{Account="李小四",LoginPwd=Md5.GetMd5("123456"),UserTypeId=db.UserType.Find(2),Name="张雨荨",Gender="女",TelPhone="13255459654",LoginCount=1,LastLoginTime=DateTime.Now,SchoolId=db.SchoolInfo.Find(3),Status=true,Lock=1},
            //    new UserInfo{Account="张大五",LoginPwd=Md5.GetMd5("123456"),UserTypeId=db.UserType.Find(2),Name="王艺博",Gender="男",TelPhone="13254459654",LoginCount=1,LastLoginTime=DateTime.Now,SchoolId=db.SchoolInfo.Find(2),Status=true,Lock=1},
            //    new UserInfo{Account="刘小六",LoginPwd=Md5.GetMd5("123456"),UserTypeId=db.UserType.Find(1),Name="王皓月",Gender="男",TelPhone="13256759654",LoginCount=1,LastLoginTime=DateTime.Now,SchoolId=db.SchoolInfo.Find(2),Status=true,Lock=1},
            //    new UserInfo{Account="罗大七",LoginPwd=Md5.GetMd5("123456"),UserTypeId=db.UserType.Find(1),Name="胡辰胤",Gender="女",TelPhone="13256459654",LoginCount=1,LastLoginTime=DateTime.Now,SchoolId=db.SchoolInfo.Find(3),Status=true,Lock=1},
            //    new UserInfo{Account="武小八",LoginPwd=Md5.GetMd5("123456"),UserTypeId=db.UserType.Find(2),Name="宋方圆",Gender="女",TelPhone="13256859654",LoginCount=1,LastLoginTime=DateTime.Now,SchoolId=db.SchoolInfo.Find(1),Status=true,Lock=1},
            //    new UserInfo{Account="朱大九",LoginPwd=Md5.GetMd5("123456"),UserTypeId=db.UserType.Find(1),Name="宋相瑞",Gender="男",TelPhone="13256429654",LoginCount=1,LastLoginTime=DateTime.Now,SchoolId=db.SchoolInfo.Find(2),Status=true,Lock=1},
            //    new UserInfo{Account="谭大十",LoginPwd=Md5.GetMd5("123456"),UserTypeId=db.UserType.Find(1),Name="柴波涛",Gender="男",TelPhone="13256453654",LoginCount=1,LastLoginTime=DateTime.Now,SchoolId=db.SchoolInfo.Find(3),Status=true,Lock=1},
            //    new UserInfo{Account="刘大壹",LoginPwd=Md5.GetMd5("123456"),UserTypeId=db.UserType.Find(2),Name="柴成化",Gender="女",TelPhone="13256457654",LoginCount=1,LastLoginTime=DateTime.Now,SchoolId=db.SchoolInfo.Find(1),Status=true,Lock=1},
            //    new UserInfo{Account="张大武",LoginPwd=Md5.GetMd5("123456"),UserTypeId=db.UserType.Find(1),Name="张武",Gender="男",TelPhone="13256452654",LoginCount=1,LastLoginTime=DateTime.Now,SchoolId=db.SchoolInfo.Find(1),Status=true,Lock=1}
            //};
            //db.UserInfo.AddRange(user);
            //db.SaveChanges();

            return View();
        }
        

            return View();
        }

    }
}