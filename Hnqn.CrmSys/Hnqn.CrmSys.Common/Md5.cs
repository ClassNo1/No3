using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hnqn.CrmSys.Common
{
    public class Md5
    {
        public static string GetMd5(string val)
        {
            byte[] bVal = Encoding.UTF8.GetBytes(val);
            //将字节数组使用MD5加密
            bVal = new System.Security.Cryptography.MD5CryptoServiceProvider().ComputeHash(bVal);
            string str = "";
            for (int i = 0; i < bVal.Count(); i++)
            {
                str += bVal[i].ToString("X").PadLeft(2, '0');
            }
            return str;
        }
    }
}
