using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Hnqn.CrmSys.Common;
using Hnqn.CrmSys.Models;

namespace Hnqn.CrmSys.Dal
{
    public class UserManage
    {
        public bool Login(UserInfo userInfo)
        {
            
            WorkUnit db = new WorkUnit();      
            var account = db.UserInfo.Where(m => m.Account == userInfo.Account && m.LoginPwd==Md5.GetMd5(userInfo.LoginPwd) && m.Lock == 1);
            if (account!=null)
            {
                return true;
            }
            return false;
        }
    }
}
