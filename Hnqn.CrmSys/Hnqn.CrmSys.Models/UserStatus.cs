using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hnqn.CrmSys.Models
{
    /// <summary>
    /// 客户状态
    /// </summary>
    public class UserStatus:EntityBase
    {

        public string UserStatusName { get; set; }

        public int Lock { get; set; }
    }
}
