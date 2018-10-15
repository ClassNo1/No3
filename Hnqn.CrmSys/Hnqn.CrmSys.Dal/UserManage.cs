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
            
            CrmDbContext db = new CrmDbContext();      
            var account = db.UserInfo.Where(m => m.Account == userInfo.Account&&m.LoginPwd==Md5.GetMd5(userInfo.LoginPwd));
            if (account!=null)
            {
                return true;
            }
            return false;
        }
    }
}
