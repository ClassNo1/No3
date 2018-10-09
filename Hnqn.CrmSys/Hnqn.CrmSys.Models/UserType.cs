using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hnqn.CrmSys.Models
{
    /// <summary>
    /// 用户类型
    /// </summary>
    public class UserType : EntityBase
    {
        public string UserTypeName { get; set; }

        public int Lock { get; set; }

        public virtual ICollection<UserInfo> UserInfo { get; set; }
    }
}
