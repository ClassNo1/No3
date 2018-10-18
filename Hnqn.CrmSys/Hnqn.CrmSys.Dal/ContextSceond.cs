using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hnqn.CrmSys.Dal
{
    public class ContextSceond
    {
        private static CrmDbContext _db = null;

        public static CrmDbContext GetContext()
        {
            if (_db == null)
            {
                return new CrmDbContext();
            }
            else
            {
                return _db;
            }
        }
    }
}
