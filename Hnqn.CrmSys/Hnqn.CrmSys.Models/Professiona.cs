using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hnqn.CrmSys.Models
{
    /// <summary>
    /// 专业表
    /// </summary>
    public class Professiona : EntityBase
    {
        //id  专业名称   校区id 
        public string ProName { get; set; }

        public virtual SchoolInfo SchoolId { get; set; }

        public int Lock { get; set; }
    }
}
