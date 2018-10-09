using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hnqn.CrmSys.Models
{
    /// <summary>
    /// 用户信息表 
    /// </summary>
    public class UserInfo:EntityBase
    {
        //id 用户名、密码、用户类型，真实姓名、性别、电话、登录次数、最后登录时间？ 校区id（校区表的id）用户状态
        public string Account { get; set; }
        public string LoginPwd { get; set; }
        public virtual UserType UserTypeId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string TelPhone { get; set; }
        public int LoginCount { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public virtual SchoolInfo SchoolId { get; set; }
        public bool Status { get; set; }
        public int Lock { get; set; }
    }
}
