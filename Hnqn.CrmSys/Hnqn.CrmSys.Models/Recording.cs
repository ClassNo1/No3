using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hnqn.CrmSys.Models
{
    /// <summary>
    /// 沟通记录表
    /// </summary>
    public class Recording : EntityBase
    {
        public virtual CustomerInfo CustomerId { get; set; }

        public string Method { get; set; }  //（沟通方法）

        public virtual UserStatus UserStatusID { get; set; }    //（客户状态）

        public string Degree { get; set; }//（意向程度）

        public string Context { get; set; }//（沟通内容）

        public string Result { get; set; }//（沟通结果）

        public DateTime RecTime { get; set; }//（沟通日期）

        public virtual SchoolInfo SchoolId { get; set; }

        public int Lock { get; set; }
    }
}
