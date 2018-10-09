using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hnqn.CrmSys.Models
{
    /// <summary>
    /// 客户表
    /// </summary>
    public class CustomerInfo : EntityBase
    {
        //id 姓名 年龄 性别  电话  微信号 地址 来源（id）（） 沟通记录  跟进状态  咨询时间  录入者
        //咨询专业 所属校区（校区表ID）
        public string CusName { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string Tel { get; set; }

        public string WeChat { get; set; }

        public string Address { get; set; }

        public virtual SourceInfo SourceID { get; set; }

        public string Record { get; set; }//(沟通记录：有或无)

        public virtual UserStatus UserStatusID { get; set; }

        public DateTime CounselingTime { get; set; }

        public virtual UserInfo AccountId { get; set; }//（录入者）

        public virtual Professiona ProfessionaId { get; set; }//（专业id）

        public virtual SchoolInfo SchoolId { get; set; }

        public int Lock { get; set; }
        //public virtual ICollection<Students> Students { get; set; }
    }
}
