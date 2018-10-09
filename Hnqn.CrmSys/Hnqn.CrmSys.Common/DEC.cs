using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Hnqn.CrmSys.Common
{
    public class DEC
    {
        public static string Encrypt(string val, string key, string iv)
        {

            byte[] bVal = Encoding.UTF8.GetBytes(val);
            byte[] bKey = Encoding.UTF8.GetBytes(key);
            byte[] bIv = Encoding.UTF8.GetBytes(iv);

            DESCryptoServiceProvider provider = new DESCryptoServiceProvider()
            {
                Mode = CipherMode.ECB,
                Key = bKey,
                IV = bIv
            };
            ICryptoTransform transform = provider.CreateEncryptor(provider.Key, provider.IV);

            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
            stream2.Write(bVal, 0, bVal.Length);
            stream2.FlushFinalBlock();
            stream2.Close();

            return Convert.ToBase64String(stream.ToArray());
        }
        public static string Decrypt(string val, string key, string IV)
        {
            try
            {
                byte[] buffer1 = Encoding.UTF8.GetBytes(key);
                byte[] buffer2 = Encoding.UTF8.GetBytes(IV);
                DESCryptoServiceProvider provider1 = new DESCryptoServiceProvider
                {
                    Mode = CipherMode.ECB,
                    Key = buffer1,
                    IV = buffer2
                };
                ICryptoTransform transform1 = provider1.CreateDecryptor(provider1.Key, provider1.IV);
                byte[] buffer3 = Convert.FromBase64String(val);
                MemoryStream stream1 = new MemoryStream();
                CryptoStream stream2 = new CryptoStream(stream1, transform1, CryptoStreamMode.Write);
                stream2.Write(buffer3, 0, buffer3.Length);
                stream2.FlushFinalBlock();
                stream2.Close();
                return Encoding.UTF8.GetString(stream1.ToArray());
            }
            catch (System.Exception ex)
            {
                return "";
            }
        }
    }
}
