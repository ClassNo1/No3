using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hnqn.CrmSys.Models
{
    /// <summary>
    /// 来源表
    /// </summary>
    public class SourceInfo : EntityBase
    {
        public string Source { get; set; }

        public int Lock { get; set; }
    }
}
