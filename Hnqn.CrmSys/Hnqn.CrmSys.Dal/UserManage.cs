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
        WorkUnit unit = new WorkUnit();
        
        public bool Login(UserInfo model)
        {
            string LoginPwd = Md5.GetMd5(model.LoginPwd);
            var Login = unit.UserInfo.Where(m => m.Account == model.Account && m.LoginPwd == LoginPwd).FirstOrDefault();
            if (Login!=null)
            {
                return true;
            }
            return false;
        }

       
    }
}
