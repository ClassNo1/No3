using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hnqn.CrmSys.Models
{
    /// <summary>
    /// 校区表
    /// </summary>
    public class SchoolInfo : EntityBase
    {
        //id 校区类型(写死) 学校名 负责人  电话1  电话2  学校地址 学校状态 添加时间
        public string SchoolTypeName { get; set; }

        public string SchoolName { get; set; }

        public string Head { get; set; }

        public string Tel1 { get; set; }

        public string Tel2 { get; set; }

        public string SchoolAddress { get; set; }

        public DateTime AddTime { get; set; }

        public bool Status { get; set; }

        public int Lock { get; set; }

    }
}
